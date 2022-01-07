using AutoMapper;
using Petsitters.Application.Common.Mappings;
using Petsitters.Application.MyServices.Commands.CreateMyService;

namespace Petsitters.WebApi.Models.MyService
{
    public class CreateMyServiceDto : IMapWith<CreateMyServiceCommand>
    {
        public string Name { get; set; }
        public string Details { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<CreateMyServiceDto, CreateMyServiceCommand>()
                .ForMember(myserviceCommand => myserviceCommand.Name,
                    opt => opt.MapFrom(myserviceDto => myserviceDto.Name))
                .ForMember(myserviceCommand => myserviceCommand.Details,
                    opt => opt.MapFrom(myserviceDto => myserviceDto.Details));
        }
    }
}
