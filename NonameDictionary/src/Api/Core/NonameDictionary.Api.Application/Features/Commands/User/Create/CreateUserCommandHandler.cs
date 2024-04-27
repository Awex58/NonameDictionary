using AutoMapper;
using MediatR;
using NonameDictionary.Api.Application.Interfaces.Repositories;
using NonameDictionary.Common;
using NonameDictionary.Common.Events.User;
using NonameDictionary.Common.Infrastructure;
using NonameDictionary.Common.Infrastructure.Exceptions;
using NonameDictionary.Common.Models.RequestModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NonameDictionary.Api.Application.Features.Commands.User.Create
{
    public class CreateUserCommandHandler:IRequestHandler<CreateUserCommand, Guid>
    {
        private readonly IMapper mapper;
        private readonly IUserRepository userRepository;
        public CreateUserCommandHandler(IUserRepository userRepository, IMapper mapper)
        {
            this.userRepository = userRepository;
            this .mapper = mapper;
        }

       

        public async Task<Guid> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            var existUser = await userRepository.GetSingleAsync(i=>i.EmailAddress == request.EmailAddress);

            if (existUser != null)
            {
                throw new DatabaseValidationException("User already exists!");
            }
            var pass = PasswordEncryptor.Encrpt(request.Password);
            var dbUser = mapper.Map<Domain.Models.User>(request);
            dbUser.Password = pass;
            var rows = await userRepository.AddAsync(dbUser);
            //email changed/created
            if (rows > 0)
            {
                var @event = new UserEmailChangedEvent()
                {
                    OldEmailAddress = null,
                    NewEmailAddress = dbUser.EmailAddress
                };
                QueueFactory.SendMessageToExchange(exchangeName:NonameConstants.UserExchangeName,exchangeType:NonameConstants.DefaultExchangeType,queueName:NonameConstants.UserEmailChangedQueueName,obj:@event);
                dbUser.EmailConfirmed = false;
                await userRepository.UpdateAsync(dbUser);
            }
            return dbUser.Id;
        }
    }
}
