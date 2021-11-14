using System;
using AutoMapper;
using Petsitters.Domain;
using Petsitters.Application.Common.Mappings;

namespace Petsitters.Application.MyServices.Queries.GetMyServiceList
{
    public class MyServiceLookupDto : IMapWith<MyService>
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<MyService, MyServiceLookupDto>()
                .ForMember(myServiceDto => myServiceDto.Id,
                    opt => opt.MapFrom(myService => myService.Id))
                .ForMember(myServiceDto => myServiceDto.Name,
                    opt => opt.MapFrom(myService => myService.Name));
        }
    }
}
