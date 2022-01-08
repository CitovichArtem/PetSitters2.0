using System;
using FluentValidation;

namespace Petsitters.Application.Pets.Commands.UpdatePet
{
    public class UpdatePetCommandValidator : AbstractValidator<UpdatePetCommand>
    {
        public UpdatePetCommandValidator()
        {
            RuleFor(updatePetCommand =>
                updatePetCommand.Name).NotEmpty().MaximumLength(250);
            RuleFor(updatePetCommand =>
                updatePetCommand.UserId).NotEqual(null);
            RuleFor(updatePetCommand =>
                updatePetCommand.Id).NotEqual(null);
        }
    }
}
