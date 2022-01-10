using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Petsitters.Application.MyServices.Queries.GetMyServiceList
{
    public class GetMyServiceListQuery : IRequest<MyServiceListVm>
    {
        public Guid UserId { get; set; }
        public Guid BidId { get; set; }
    }
}
