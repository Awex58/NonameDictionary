using MediatR;
using NonameDictionary.Api.Application.Interfaces.Repositories;
using NonameDictionary.Common.Infrastructure.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NonameDictionary.Api.Application.Features.Commands.User.ConfirmEmail
{
    public class ConfirmEmailCommandHandler : IRequestHandler<ConfirmEmailCommand, bool>
    {
        private readonly IUserRepository userRepository;
        private readonly IEmailConfirmationRepository emailConfirmationRepository;
        public async Task<bool> Handle(ConfirmEmailCommand request, CancellationToken cancellationToken)
        {
            var confirmation = await emailConfirmationRepository.GetByIdAsync(request.ConfirmationId);

            if (confirmation == null)
            {
                throw new DatabaseValidationException("Confirmation not found!");
            }
            var dbUser = await userRepository.GetSingleAsync(i => i.EmailAddress == confirmation.NewEmailAddress);
            if (dbUser == null)
            {
                throw new DatabaseValidationException("User not found with this email address!");
            }
            if (dbUser.EmailConfirmed)
            {
                throw new DatabaseValidationException("Email address is already confirmed!");

            }
            dbUser.EmailConfirmed = true;
            await userRepository.UpdateAsync(dbUser);

            return true;
        }
    }
}
