using System;
using MediatR;

namespace Petsitters.Application.Pets.Queries.GetPetDetails
{
    public class GetPetDetailsQuery : IRequest<PetDetailsVm>
    {
        public Guid UserId { get; set; }
        public Guid Id { get; set; }
    }
}
