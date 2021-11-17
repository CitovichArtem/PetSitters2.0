using AutoMapper;
using Petsitters.Application.Common.Mappings;
using Petsitters.Application.Pets.Commands.CreatePet;

namespace Petsitters.WebApi.Models.Pet
{
    public class CreatePetDto : IMapWith<CreatePetCommand>
    {
        public string Name { get; set; }
        public int Age { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<CreatePetDto, CreatePetCommand>()
                .ForMember(petCommand => petCommand.Name,
                    opt => opt.MapFrom(petDto => petDto.Name))
                .ForMember(petCommand => petCommand.Age,
                    opt => opt.MapFrom(petDto => petDto.Age));
        }
    }
}
