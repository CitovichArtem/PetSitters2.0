using System;
using AutoMapper;
using Petsitters.Domain;
using Petsitters.Application.Common.Mappings;

namespace Petsitters.Application.Bids.Queries.GetBidList
{
    public class BidLookupDto : IMapWith<Bid>
    {
        public Guid Id { get; set; }
        public string Name { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Bid, BidLookupDto>()
                .ForMember(bidDto => bidDto.Id,
                    opt => opt.MapFrom(bid => bid.Id))
                .ForMember(bidDto => bidDto.Name,
                    opt => opt.MapFrom(bid => bid.Name));
        }
    }
}
