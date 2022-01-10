using System;
using FluentValidation;

namespace Petsitters.Application.Bids.Queries.GetBidList
{
    public class GetBidListQueryValidator : AbstractValidator<GetBidListQuery>
    {
        public GetBidListQueryValidator()
        {
            RuleFor(bid => bid.MyServiceId).NotEqual(Guid.Empty);
            RuleFor(bid => bid.PetId).NotEqual(Guid.Empty);
        }
    }
}
