using System;
using FluentValidation;

namespace Petsitters.Application.MyServices.Queries.GetMyServiceList
{
    public class GetMyServiceListQueryValidator : AbstractValidator<GetMyServiceListQuery>
    {
        public GetMyServiceListQueryValidator()
        {
            RuleFor(myservice => myservice.UserId).NotEqual(0);
            RuleFor(myservice => myservice.BidId).NotEqual(0);
        }
    }
}
