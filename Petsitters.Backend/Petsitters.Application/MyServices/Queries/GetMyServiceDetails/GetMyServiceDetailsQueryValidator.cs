using System;
using FluentValidation;

namespace Petsitters.Application.MyServices.Queries.GetMyServiceDetails
{
    public class GetMyServiceDetailsQueryValidator : AbstractValidator<GetMyServiceDetailsQuery>
    {
        public GetMyServiceDetailsQueryValidator() 
        {
            RuleFor(myservice => myservice.Id).NotEqual(0);
            RuleFor(myservice => myservice.BidId).NotEqual(0);
            RuleFor(myservice => myservice.UserId).NotEqual(0);
        }
    }
}
