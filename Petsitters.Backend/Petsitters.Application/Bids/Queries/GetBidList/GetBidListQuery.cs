using System;
using MediatR;

namespace Petsitters.Application.Bids.Queries.GetBidList
{
    public class GetBidListQuery : IRequest<BidListVm>
    {
        public Guid PetId { get; set; }
        public Guid MyServiceId { get; set; }
    }
}
