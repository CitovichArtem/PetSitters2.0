using System;
using FluentValidation;

namespace Petsitters.Application.MyServices.Queries.GetMyServiceDetails
{
    public class GetMyServiceDetailsQueryValidator : AbstractValidator<GetMyServiceDetailsQuery>
    {
        public GetMyServiceDetailsQueryValidator() 
        {
            RuleFor(myservice => myservice.Id).NotEqual(Guid.Empty);
            RuleFor(myservice => myservice.BidId).NotEqual(Guid.Empty);
            RuleFor(myservice => myservice.UserId).NotEqual(Guid.Empty);
        }
    }
}
