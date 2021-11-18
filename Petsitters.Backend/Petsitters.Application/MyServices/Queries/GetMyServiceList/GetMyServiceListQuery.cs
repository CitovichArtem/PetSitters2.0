using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Petsitters.Application.MyServices.Queries.GetMyServiceList
{
    public class GetMyServiceListQuery
    {
        public int UserId { get; set; }
        public List<int> BidId { get; set; }
    }
}
