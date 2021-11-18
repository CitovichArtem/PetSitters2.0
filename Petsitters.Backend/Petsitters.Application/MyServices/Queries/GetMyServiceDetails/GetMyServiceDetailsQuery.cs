using System;
using System.Collections.Generic;
using MediatR;

namespace Petsitters.Application.MyServices.Queries.GetMyServiceDetails
{
    public class GetMyServiceDetailsQuery : IRequest<MyServiceDetailsVm>
    {
        public int UserId { get; set; }
        public int Id { get; set; }
        public List<int> BidId { get; set; }
    }
}
