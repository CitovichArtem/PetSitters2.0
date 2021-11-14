using AutoMapper;
using AutoMapper.QueryableExtensions;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Petsitters.Application.Interfaces;

namespace Petsitters.Application.Pets.Queries.GetPetList
{
    public class GetPetListQueryHandler
        : IRequestHandler<GetPetListQuery, PetListVm>
    {
        private readonly IAppDbContext _dbContext;
        private readonly IMapper _mapper;

        public GetPetListQueryHandler(IAppDbContext dbContext,
            IMapper mapper) =>
            (_dbContext, _mapper) = (dbContext, mapper);

        public async Task<PetListVm> Handle(GetPetListQuery request,
            CancellationToken cancellationToken)
        {
            var petsQuery = await _dbContext.Pets
                .Where(pets => pets.UserId == request.UserId)
                .ProjectTo<PetLookupDto>(_mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken);

            return new PetListVm { Pets = petsQuery };
        }
    }
}
