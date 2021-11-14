using System;
using MediatR;

namespace Petsitters.Application.Feedbacks.Queries.GetFeedbackList
{
    public class GetFeedbackListQuery : IRequest<FeedbackListVm>
    {
        public int OwnerUserId { get; set; }
        public int WorkerUserId { get; set; }
    }
}
