using AutoMapper;
using AutoMapper.QueryableExtensions;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Petsitters.Application.Interfaces;

namespace Petsitters.Application.Feedbacks.Queries.GetFeedbackList
{
    public class GetFeedbackListQueryHandler
        : IRequestHandler<GetFeedbackListQuery, FeedbackListVm>
    {
        private readonly IAppDbContext _dbContext;
        private readonly IMapper _mapper;

        public GetFeedbackListQueryHandler(IAppDbContext dbContext,
            IMapper mapper) =>
            (_dbContext, _mapper) = (dbContext, mapper);

        public async Task<FeedbackListVm> Handle(GetFeedbackListQuery request,
            CancellationToken cancellationToken)
        {
            var feedbacksQuery = await _dbContext.Feedbacks
                .Where(feedbacks => feedbacks.WorkerUserId == feedbacks.WorkerUserId)
                .ProjectTo<FeedbackLookupDto>(_mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken);

            return new FeedbackListVm { Feedbacks = feedbacksQuery };
        }
    }
}
