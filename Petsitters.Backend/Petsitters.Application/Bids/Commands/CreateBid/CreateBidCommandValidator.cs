using System;
using FluentValidation;

namespace Petsitters.Application.Bids.Commands.CreateBid
{
    public class CreateBidCommandValidator : AbstractValidator<CreateBidCommand>
    {
        public CreateBidCommandValidator()
        {
            RuleFor(createBidCommand =>
                createBidCommand.Name).NotEmpty().MaximumLength(250);
            RuleFor(createBidCommand =>
                createBidCommand.MyServiceID).NotEqual(Guid.Empty);
            RuleFor(createBidCommand =>
                createBidCommand.PetId).NotEqual(Guid.Empty);
        }
    }
}
