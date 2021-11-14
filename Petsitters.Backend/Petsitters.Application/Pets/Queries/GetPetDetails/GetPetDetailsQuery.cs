using System;
using MediatR;

namespace Petsitters.Application.Pets.Queries.GetPetDetails
{
    public class GetPetDetailsQuery : IRequest<PetDetailsVm>
    {
        public int UserId { get; set; }
        public int Id { get; set; }
    }
}
