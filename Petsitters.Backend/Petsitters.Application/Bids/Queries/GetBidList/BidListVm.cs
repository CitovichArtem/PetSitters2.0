using System.Collections.Generic;

namespace Petsitters.Application.Bids.Queries.GetBidList
{
    public class BidListVm
    {
        public IList<BidLookupDto> Bids { get; set; }
    }
}
