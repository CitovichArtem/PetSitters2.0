using System;
using FluentValidation;

namespace Petsitters.Application.MyServices.Queries.GetMyServiceList
{
    public class GetMyServiceListQueryValidator : AbstractValidator<GetMyServiceListQuery>
    {
        public GetMyServiceListQueryValidator()
        {
            RuleFor(myservice => myservice.UserId).NotEqual(Guid.Empty);
            RuleFor(myservice => myservice.BidId).NotEqual(Guid.Empty);
        }
    }
}
