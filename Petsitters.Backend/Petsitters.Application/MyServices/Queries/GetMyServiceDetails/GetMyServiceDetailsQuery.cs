using System;
using MediatR;

namespace Petsitters.Application.MyServices.Queries.GetMyServiceDetails
{
    public class GetMyServiceDetailsQuery : IRequest<MyServiceDetailsVm>
    {
        public int UserId { get; set; }
        public int Id { get; set; }
        public int BidId { get; set; }
    }
}
