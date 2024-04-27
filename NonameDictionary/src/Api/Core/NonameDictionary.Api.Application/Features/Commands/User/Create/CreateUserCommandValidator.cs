using FluentValidation;
using NonameDictionary.Common.Models.RequestModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NonameDictionary.Api.Application.Features.Commands.User.Create
{
    public class CreateUserCommandValidator : AbstractValidator<CreateUserCommand>
    {
        public CreateUserCommandValidator()
        {
            RuleFor(i => i.EmailAddress).NotNull()
                .EmailAddress(FluentValidation.Validators.EmailValidationMode.AspNetCoreCompatible)
                .WithMessage("{PropertyName} Not a valid email address");

            RuleFor(i => i.Password).NotNull()
                .MinimumLength(6)
                .WithMessage("{PropertyName} should at least be {MinLength} characters");

            RuleFor(i => i.UserName).NotNull()
                .MinimumLength(6)
                .WithMessage("{PropertyName} should at least be {MinLength} characters");

            RuleFor(i => i.FirstName).NotNull()
                .WithMessage("{PropertyName} should at least be {MinLength} characters");

            RuleFor(i => i.LastName).NotNull()
                .WithMessage("{PropertyName} should at least be {MinLength} characters");
        }
    }
}
