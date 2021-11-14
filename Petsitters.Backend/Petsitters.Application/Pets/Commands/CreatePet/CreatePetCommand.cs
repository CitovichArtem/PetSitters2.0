using MediatR;

namespace Petsitters.Application.Pets.Commands.CreatePet
{
    public class CreatePetCommand : IRequest<int>
    {
        public int UserId { get; set; }
        public int BidId { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }

    }
}
