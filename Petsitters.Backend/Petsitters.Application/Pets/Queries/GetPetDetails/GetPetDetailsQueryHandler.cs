using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Petsitters.Application.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Petsitters.Application.Common.Exceptions;
using Petsitters.Domain;

namespace Petsitters.Application.Pets.Queries.GetPetDetails
{
    public class GetPetDetailsQueryHandler
        : IRequestHandler<GetPetDetailsQuery, PetDetailsVm>
    {
        private readonly IAppDbContext _dbContext;
        private readonly IMapper _mapper;

        public GetPetDetailsQueryHandler(IAppDbContext dbContext,
            IMapper mapper) => (_dbContext, _mapper) = (dbContext, mapper);

        public async Task<PetDetailsVm> Handle(GetPetDetailsQuery request,
            CancellationToken cancellationToken)
        {
            var entity = await _dbContext.Pets
                .FirstOrDefaultAsync(pet =>
                pet.Id == request.Id, cancellationToken);

            if (entity == null || entity.UserId != request.UserId)
            {
                throw new NotFoundException(nameof(Pet), request.Id);
            }

            return _mapper.Map<PetDetailsVm>(entity);
        }
    }
}
