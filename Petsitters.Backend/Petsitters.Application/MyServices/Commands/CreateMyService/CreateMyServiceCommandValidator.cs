using System;
using FluentValidation;

namespace Petsitters.Application.MyServices.Commands.CreateMyService
{
    public class CreateMyServiceCommandValidator : AbstractValidator<CreateMyServiceCommand>
    {
        public CreateMyServiceCommandValidator()
        {
            RuleFor(createMyServiceCommand =>
                createMyServiceCommand.Name).NotEmpty().MaximumLength(250);
            RuleFor(createMyServiceCommand =>
                createMyServiceCommand.Details).NotEmpty().MaximumLength(1000);
            RuleFor(createMyServiceCommand =>
                createMyServiceCommand.UserId).NotEqual(Guid.Empty);
            RuleFor(createMyServiceCommand =>
                createMyServiceCommand.BidId).NotEqual(Guid.Empty);
        }
    }
}
