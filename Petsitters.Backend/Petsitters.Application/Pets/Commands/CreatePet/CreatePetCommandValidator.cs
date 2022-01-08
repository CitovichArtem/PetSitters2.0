using System;
using FluentValidation;

namespace Petsitters.Application.Pets.Commands.CreatePet
{
    public class CreatePetCommandValidator : AbstractValidator<CreatePetCommand>
    {
        public CreatePetCommandValidator()
        {
            RuleFor(createPetCommand =>
                createPetCommand.Name).NotEmpty().MaximumLength(250);
            RuleFor(createPetCommand =>
                createPetCommand.UserId).NotEqual(null);
            RuleFor(createPetCommand =>
                createPetCommand.BidId).NotEqual(null);
        }
    }
}
