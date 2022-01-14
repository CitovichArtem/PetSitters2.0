using System;
using MediatR;

namespace Petsitters.Application.Pets.Commands.UpdatePet
{
    public class UpdatePetCommand : IRequest
    {
        public Guid UserId { get; set; }
        public Guid BidId { get; set; }
        public Guid Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
    }
}
