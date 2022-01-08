using System;
using FluentValidation;

namespace Petsitters.Application.Feedbacks.Queries.GetFeedbackList
{
    public class GetFeedbackListQueryValidator : AbstractValidator<GetFeedbackListQuery>
    {
        public GetFeedbackListQueryValidator()
        {
            RuleFor(feedback => feedback.OwnerUserId).NotEqual(0);
            RuleFor(feedback => feedback.WorkerUserId).NotEqual(0);
        }
    }
}
