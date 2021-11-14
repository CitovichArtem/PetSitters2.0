using System;
using AutoMapper;
using Petsitters.Domain;
using Petsitters.Application.Common.Mappings;

namespace Petsitters.Application.MyServices.Queries.GetMyServiceDetails
{
    public class MyServiceDetailsVm : IMapWith<MyService>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Details { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<MyService, MyServiceDetailsVm>()
                .ForMember(myServiceVm => myServiceVm.Name,
                    opt => opt.MapFrom(myService => myService.Name))
                .ForMember(myServiceVm => myServiceVm.Details,
                    opt => opt.MapFrom(myService => myService.Details))
                .ForMember(myServiceVm => myServiceVm.Id,
                    opt => opt.MapFrom(myService => myService.Id));
        }
    }
}
