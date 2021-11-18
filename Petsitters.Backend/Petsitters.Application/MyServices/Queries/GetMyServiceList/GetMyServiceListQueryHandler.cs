//using AutoMapper;
//using AutoMapper.QueryableExtensions;
//using System.Linq;
//using System.Threading;
//using System.Threading.Tasks;
//using MediatR;
//using Microsoft.EntityFrameworkCore;
//using Petsitters.Application.Interfaces;

//namespace Petsitters.Application.MyServices.Queries.GetMyServiceList
//{
//    public class GetMyServiceListQueryHandler //TO DO
//        : IRequestHandler<GetMyServiceListQuery, MyServiceListVm>
//    {
//        private readonly IAppDbContext _dbContext;
//        private readonly IMapper _mapper;

//        public GetMyServiceListQueryHandler(IAppDbContext dbContext,
//            IMapper mapper) =>
//            (_dbContext, _mapper) = (dbContext, mapper);

//        public async Task<MyServiceListVm> Handle(GetMyServiceListQuery request,
//            CancellationToken cancellationToken)
//        {
//            var myServicesQuery = await _dbContext.MyServices
//                .Where(myServices => myServices.UserId == request.UserId )
//                .ProjectTo<MyServiceLookupDto>(_mapper.ConfigurationProvider)
//                .ToListAsync(cancellationToken);

//            return new MyServiceListVm { MyServices = myServicesQuery };
//        }
//    }
//}
