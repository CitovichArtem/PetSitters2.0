using System;
using MediatR;

namespace Petsitters.Application.Pets.Queries.GetPetList
{
    public class GetPetListQuery : IRequest<PetListVm>
    {
        public Guid UserId { get; set; }
    }
}
