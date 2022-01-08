using System;
using FluentValidation;

namespace Petsitters.Application.Pets.Commands.DeletePet
{
    public class DeletePetCommandValidator : AbstractValidator<DeletePetCommand>
    {
        public DeletePetCommandValidator()
        {
            RuleFor(deletePetCommand => deletePetCommand.Id).NotEqual(null);
            RuleFor(deletePetCommand => deletePetCommand.UserId).NotEqual(null);
        }
    }
}
