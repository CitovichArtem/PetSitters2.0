using System;
using MediatR;

namespace Petsitters.Application.Pets.Commands.UpdatePet
{
    public class UpdatePetCommand : IRequest
    {
        public int UserId { get; set; }
        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
    }
}
