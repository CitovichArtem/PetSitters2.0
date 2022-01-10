using MediatR;
using System;

namespace Petsitters.Application.Bids.Commands.CreateBid
{
    public class CreateBidCommand : IRequest<Guid>
    {
        public Guid PetId { get; set; }
        public Guid MyServiceID { get; set; }
        public string Name { get; set; }


    }
}
