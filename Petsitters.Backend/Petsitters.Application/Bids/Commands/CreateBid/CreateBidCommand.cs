using MediatR;

namespace Petsitters.Application.Bids.Commands.CreateBid
{
    public class CreateBidCommand : IRequest<int>
    {
        public int PetId { get; set; }
        public int MyServiceID { get; set; }
        public string Name { get; set; }


    }
}
