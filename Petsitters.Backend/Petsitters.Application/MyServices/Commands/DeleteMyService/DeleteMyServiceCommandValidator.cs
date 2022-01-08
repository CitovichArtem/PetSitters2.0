using System;
using FluentValidation;

namespace Petsitters.Application.MyServices.Commands.DeleteMyService
{
    public class DeleteMyServiceCommandValidator : AbstractValidator<DeleteMyServiceCommand>
    {
        public DeleteMyServiceCommandValidator()
        {
            RuleFor(deleteMyServiceCommand => deleteMyServiceCommand.Id).NotEqual(null);
            RuleFor(deleteMyServiceCommand => deleteMyServiceCommand.UserId).NotEqual(null);
            RuleFor(deleteMyServiceCommand => deleteMyServiceCommand.BidId).NotEqual(null);
        }
    }
}
