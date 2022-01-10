using AutoMapper;
using Petsitters.Application.Common.Mappings;
using Petsitters.Application.MyServices.Commands.UpdateMyService;
using System;

namespace Petsitters.WebApi.Models.MyService
{
    public class UpdateMyServiceDto : IMapWith<UpdateMyServiceCommand>
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Details { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<UpdateMyServiceDto, UpdateMyServiceCommand>()
                .ForMember(myserviceCommand => myserviceCommand.Id,
                    opt => opt.MapFrom(myserviceDto => myserviceDto.Id))
                .ForMember(myserviceCommand => myserviceCommand.Name,
                    opt => opt.MapFrom(myserviceDto => myserviceDto.Name))
                .ForMember(myserviceCommand => myserviceCommand.Details,
                    opt => opt.MapFrom(myserviceDto => myserviceDto.Details));
        }
    }
}
