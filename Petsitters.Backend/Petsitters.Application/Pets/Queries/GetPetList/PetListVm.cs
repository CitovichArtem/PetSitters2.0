using System.Collections.Generic;

namespace Petsitters.Application.Pets.Queries.GetPetList
{
    public class PetListVm
    {
        public IList<PetLookupDto> Pets { get; set; }
    }
}
