using AutoMapper;
using Petsitters.Application.Common.Mappings;
using Petsitters.Application.Pets.Commands.UpdatePet;

namespace Petsitters.WebApi.Models.Pet
{
    public class UpdatePetDto : IMapWith<UpdatePetCommand>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<UpdatePetDto, UpdatePetCommand>()
                .ForMember(petCommand => petCommand.Id,
                    opt => opt.MapFrom(petDto => petDto.Id))
                .ForMember(petCommand => petCommand.Name,
                    opt => opt.MapFrom(petDto => petDto.Name))
                .ForMember(petCommand => petCommand.Age,
                    opt => opt.MapFrom(petDto => petDto.Age));
        }
    }
}
