using System;
using MediatR;

namespace Petsitters.Application.Feedbacks.Queries.GetFeedbackList
{
    public class GetFeedbackListQuery : IRequest<FeedbackListVm>
    {
        public Guid OwnerUserId { get; set; }
        public Guid WorkerUserId { get; set; }
    }
}
