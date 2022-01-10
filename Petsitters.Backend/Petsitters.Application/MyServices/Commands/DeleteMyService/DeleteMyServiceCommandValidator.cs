using System;
using FluentValidation;

namespace Petsitters.Application.MyServices.Commands.DeleteMyService
{
    public class DeleteMyServiceCommandValidator : AbstractValidator<DeleteMyServiceCommand>
    {
        public DeleteMyServiceCommandValidator()
        {
            RuleFor(deleteMyServiceCommand => deleteMyServiceCommand.Id).NotEqual(Guid.Empty);
            RuleFor(deleteMyServiceCommand => deleteMyServiceCommand.UserId).NotEqual(Guid.Empty);
            RuleFor(deleteMyServiceCommand => deleteMyServiceCommand.BidId).NotEqual(Guid.Empty);
        }
    }
}
