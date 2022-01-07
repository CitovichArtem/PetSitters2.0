using AutoMapper;
using Petsitters.Application.Common.Mappings;
using Petsitters.Application.Bids.Commands.CreateBid;

namespace Petsitters.WebApi.Models.Bid
{
    public class CreateBidDto : IMapWith<CreateBidCommand>
    {
        public string Name { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<CreateBidDto, CreateBidCommand>()
                .ForMember(bidCommand => bidCommand.Name,
                    opt => opt.MapFrom(bidDto => bidDto.Name));
        }
    }
}
