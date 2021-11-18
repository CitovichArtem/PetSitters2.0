using MediatR;
using System.Collections.Generic;

namespace Petsitters.Application.Bids.Commands.CreateBid
{
    public class CreateBidCommand : IRequest<int>
    {
        public int PetId { get; set; }
        public int MyServiceID { get; set; }


    }
}
