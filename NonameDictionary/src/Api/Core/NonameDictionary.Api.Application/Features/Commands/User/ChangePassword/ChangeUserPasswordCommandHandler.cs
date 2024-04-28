using AutoMapper;
using MediatR;
using NonameDictionary.Api.Application.Interfaces.Repositories;
using NonameDictionary.Common.Events.User;
using NonameDictionary.Common.Infrastructure;
using NonameDictionary.Common.Infrastructure.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NonameDictionary.Api.Application.Features.Commands.User.ChangePassword
{
    public class ChangeUserPasswordCommandHandler : IRequestHandler<ChangeUserPasswordCommand, bool>
    {
        private readonly IMapper mapper;
        private readonly IUserRepository userRepository;
        public ChangeUserPasswordCommandHandler(IUserRepository userRepository, IMapper mapper)
        {
            this.userRepository = userRepository;
            this.mapper = mapper;
        }
        async Task<bool> IRequestHandler<ChangeUserPasswordCommand, bool>.Handle(ChangeUserPasswordCommand request, CancellationToken cancellationToken)
        {

            if(!request.UserId.HasValue)
                throw new ArgumentNullException(nameof(request.UserId));
            
            var dbUser = await userRepository.GetByIdAsync(request.UserId.Value);

            if (dbUser == null)
                throw new DatabaseValidationException("User not found!");

            var encPass = PasswordEncryptor.Encrpt(request.OldPassword);

            if(dbUser.Password !=encPass)
                throw new DatabaseValidationException("Old password wrong!");

            dbUser.Password = PasswordEncryptor.Encrpt(request.NewPassword);

            await userRepository.UpdateAsync(dbUser);

            return true;


        }
    }
}
