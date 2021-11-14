using AutoMapper;
using AutoMapper.QueryableExtensions;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Petsitters.Application.Interfaces;

namespace Petsitters.Application.Bids.Queries.GetBidList
{
    public class GetBidListQueryHandler
        : IRequestHandler<GetBidListQuery, BidListVm>
    {
        private readonly IAppDbContext _dbContext;
        private readonly IMapper _mapper;

        public GetBidListQueryHandler(IAppDbContext dbContext,
            IMapper mapper) =>
            (_dbContext, _mapper) = (dbContext, mapper);

        public async Task<BidListVm> Handle(GetBidListQuery request,
            CancellationToken cancellationToken)
        {
            var bidsQuery = await _dbContext.Bids
                .Where(bids => bids.PetId == request.PetId && bids.MyServiceId == request.MyServiceId)
                .ProjectTo<BidLookupDto>(_mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken);

            return new BidListVm { Bids = bidsQuery };
        }
    }
}
