using System;
using MediatR;

namespace Petsitters.Application.MyServices.Queries.GetMyServiceDetails
{
    public class GetMyServiceDetailsQuery : IRequest<MyServiceDetailsVm>
    {
        public Guid UserId { get; set; }
        public Guid Id { get; set; }
        public Guid BidId { get; set; }
    }
}
