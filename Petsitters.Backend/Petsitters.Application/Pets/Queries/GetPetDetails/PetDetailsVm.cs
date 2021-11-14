using System;
using AutoMapper;
using Petsitters.Domain;
using Petsitters.Application.Common.Mappings;

namespace Petsitters.Application.Pets.Queries.GetPetDetails
{
    public class PetDetailsVm: IMapWith<Pet>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Pet, PetDetailsVm>()
                .ForMember(petVm => petVm.Name,
                    opt => opt.MapFrom(pet => pet.Name))
                .ForMember(petVm => petVm.Age,
                    opt => opt.MapFrom(pet => pet.Age))
                .ForMember(petVm => petVm.Id,
                    opt => opt.MapFrom(pet => pet.Id));
        }
    }
}
