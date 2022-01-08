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
                updateMyServiceCommand.Id).NotEqual(0);
            RuleFor(updateMyServiceCommand =>
               updateMyServiceCommand.UserId).NotEqual(0);
            RuleFor(updateMyServiceCommand =>
               updateMyServiceCommand.BidId).NotEqual(0);

        }
    }
}
