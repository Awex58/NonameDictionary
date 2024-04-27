using AutoMapper;
using MediatR;
using NonameDictionary.Api.Application.Interfaces.Repositories;
using NonameDictionary.Common.Events.User;
using NonameDictionary.Common.Infrastructure;
using NonameDictionary.Common;
using NonameDictionary.Common.Infrastructure.Exceptions;
using NonameDictionary.Common.Models.RequestModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NonameDictionary.Api.Application.Features.Commands.User.Update
{
    public class UpdateUserCommandHandler : IRequestHandler<UpdateUserCommand, Guid>
    {
        private readonly IMapper mapper;
        private readonly IUserRepository userRepository;
        public UpdateUserCommandHandler(IUserRepository userRepository, IMapper mapper)
        {
            this.userRepository = userRepository;
            this.mapper = mapper;
        }

        public async Task<Guid> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
        {
            var dbUser = await userRepository.GetByIdAsync(request.Id);


            if (dbUser == null)
            {
                throw new DatabaseValidationException("User not found!");
            }
            var dbEmailAddress = dbUser.EmailAddress;

            var emailChanged = string.CompareOrdinal(dbEmailAddress, request.EmailAddress) != 0; //ordinal büyük küçük harf problem çıkarmasın diye kullanıldı ve aynı mı değilmi ona göre true false veriyor

            mapper.Map(request, dbUser);

            var rows = await userRepository.UpdateAsync(dbUser);


            //check if email changed

            if (emailChanged && rows > 0)
            {
                var @event = new UserEmailChangedEvent()
                {
                    OldEmailAddress = null,
                    NewEmailAddress = dbUser.EmailAddress
                };
                QueueFactory.SendMessageToExchange(exchangeName: NonameConstants.UserExchangeName, exchangeType: NonameConstants.DefaultExchangeType, queueName: NonameConstants.UserEmailChangedQueueName, obj: @event);
            }



            return dbUser.Id;
        }   
    }
}
