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
                createBidCommand.MyServiceID).NotEqual(null);
            RuleFor(createBidCommand =>
                createBidCommand.PetId).NotEqual(null);
        }
    }
}
