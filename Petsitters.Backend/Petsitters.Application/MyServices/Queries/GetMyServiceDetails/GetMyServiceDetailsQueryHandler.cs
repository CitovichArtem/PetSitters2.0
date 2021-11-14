using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Petsitters.Application.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Petsitters.Application.Common.Exceptions;
using Petsitters.Domain;

namespace Petsitters.Application.MyServices.Queries.GetMyServiceDetails
{
    public class GetMyServiceDetailsQueryHandler
    : IRequestHandler<GetMyServiceDetailsQuery, MyServiceDetailsVm>
    {
        private readonly IAppDbContext _dbContext;
        private readonly IMapper _mapper;

        public GetMyServiceDetailsQueryHandler(IAppDbContext dbContext,
            IMapper mapper) => (_dbContext, _mapper) = (dbContext, mapper);

        public async Task<MyServiceDetailsVm> Handle(GetMyServiceDetailsQuery request,
            CancellationToken cancellationToken)
        {
            var entity = await _dbContext.MyServices
                .FirstOrDefaultAsync(myService =>
                myService.Id == request.Id, cancellationToken);

            if (entity == null || entity.UserId != request.UserId)
            {
                throw new NotFoundException(nameof(MyService), request.Id);
            }

            return _mapper.Map<MyServiceDetailsVm>(entity);
        }
    }
}
