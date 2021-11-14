using System;
using MediatR;

namespace Petsitters.Application.Pets.Commands.DeletePet
{
    public class DeletePetCommand : IRequest
    {
        public int UserId { get; set; }
        public int Id { get; set; }
    }
}
