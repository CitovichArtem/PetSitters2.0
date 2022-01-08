using System;
using FluentValidation;

namespace Petsitters.Application.Bids.Queries.GetBidList
{
    public class GetBidListQueryValidator : AbstractValidator<GetBidListQuery>
    {
        public GetBidListQueryValidator()
        {
            RuleFor(bid => bid.MyServiceId).NotEqual(0);
            RuleFor(bid => bid.PetId).NotEqual(0);
        }
    }
}
