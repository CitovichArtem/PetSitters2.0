using System;
using FluentValidation;

namespace Petsitters.Application.MyServices.Commands.UpdateMyService
{
    public class UpdateMyServiceCommandValidator : AbstractValidator<UpdateMyServiceCommand>
    {
        public UpdateMyServiceCommandValidator()
        {
            RuleFor(updateMyServiceCommand =>
                updateMyServiceCommand.Name).NotEmpty().MaximumLength(250);
            RuleFor(updateMyServiceCommand =>
                updateMyServiceCommand.Details).NotEmpty().MaximumLength(1000);
            RuleFor(updateMyServiceCommand =>
                updateMyServiceCommand.Id).NotEqual(Guid.Empty);
            RuleFor(updateMyServiceCommand =>
               updateMyServiceCommand.UserId).NotEqual(Guid.Empty);
            RuleFor(updateMyServiceCommand =>
               updateMyServiceCommand.BidId).NotEqual(Guid.Empty);

        }
    }
}
