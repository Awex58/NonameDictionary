using FluentValidation;
using NonameDictionary.Common.Models.RequestModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NonameDictionary.Api.Application.Features.Commands.User
{
    public class LoginUserCommandValidator : AbstractValidator<LoginUserCommand>
    {
        public LoginUserCommandValidator()
        {
            RuleFor(i => i.EmailAddress).NotNull()
                .EmailAddress(FluentValidation.Validators.EmailValidationMode.AspNetCoreCompatible)
                .WithMessage("{PropertyName} Not a valid email address");

            RuleFor(i => i.Password).NotNull()
                .MinimumLength(6)
                .WithMessage("{PropertyName} should at least be {MinLength} characters");

        }
    }
}
