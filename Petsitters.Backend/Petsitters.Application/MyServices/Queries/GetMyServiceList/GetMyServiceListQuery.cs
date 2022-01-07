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
        public int UserId { get; set; }
        public int BidId { get; set; }
    }
}
