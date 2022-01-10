using MediatR;
using System;

namespace Petsitters.Application.Pets.Commands.CreatePet
{
    public class CreatePetCommand : IRequest<Guid>
    {
        public Guid UserId { get; set; }
        public Guid BidId { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }

    }
}
