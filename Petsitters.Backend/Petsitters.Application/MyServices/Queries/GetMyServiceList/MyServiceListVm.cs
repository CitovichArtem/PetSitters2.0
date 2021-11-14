using System.Collections.Generic;

namespace Petsitters.Application.MyServices.Queries.GetMyServiceList
{
    public class MyServiceListVm
    {
        public IList<MyServiceLookupDto> MyServices { get; set; }
    }
}
