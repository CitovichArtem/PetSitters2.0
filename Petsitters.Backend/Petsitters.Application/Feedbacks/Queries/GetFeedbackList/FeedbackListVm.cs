using System.Collections.Generic;

namespace Petsitters.Application.Feedbacks.Queries.GetFeedbackList
{
    public class FeedbackListVm
    {
        public IList<FeedbackLookupDto> Feedbacks { get; set; }
    }
}
