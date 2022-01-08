using System;
using FluentValidation;

namespace Petsitters.Application.Pets.Queries.GetPetList
{
    public class GetPetListQueryValidator : AbstractValidator<GetPetListQuery>
    {
        public GetPetListQueryValidator()
        {
            RuleFor(pet => pet.UserId).NotEqual(0);
        }
    }
}
