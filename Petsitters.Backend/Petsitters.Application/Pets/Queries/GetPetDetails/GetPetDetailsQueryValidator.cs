using System;
using FluentValidation;

namespace Petsitters.Application.Pets.Queries.GetPetDetails
{
    public class GetPetDetailsQueryValidator : AbstractValidator<GetPetDetailsQuery>
    {
        public GetPetDetailsQueryValidator()
        {
            RuleFor(pet => pet.Id).NotEqual(Guid.Empty);
            RuleFor(pet => pet.UserId).NotEqual(Guid.Empty);
        }

    }
}
