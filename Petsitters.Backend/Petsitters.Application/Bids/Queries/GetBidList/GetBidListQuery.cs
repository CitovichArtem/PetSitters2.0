using System;
using MediatR;

namespace Petsitters.Application.Bids.Queries.GetBidList
{
    public class GetBidListQuery : IRequest<BidListVm>
    {
        public int PetId { get; set; }
        public int MyServiceId { get; set; }
    }
}
