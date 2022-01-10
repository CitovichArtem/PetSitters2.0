using System;
using FluentValidation;

namespace Petsitters.Application.Feedbacks.Queries.GetFeedbackList
{
    public class GetFeedbackListQueryValidator : AbstractValidator<GetFeedbackListQuery>
    {
        public GetFeedbackListQueryValidator()
        {
            RuleFor(feedback => feedback.OwnerUserId).NotEqual(Guid.Empty);
            RuleFor(feedback => feedback.WorkerUserId).NotEqual(Guid.Empty);
        }
    }
}
