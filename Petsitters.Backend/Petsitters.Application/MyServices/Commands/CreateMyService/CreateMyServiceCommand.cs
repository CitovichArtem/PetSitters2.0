using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace Petsitters.Application.MyServices.Commands.CreateMyService
{
    public class CreateMyServiceCommand : IRequest<int>
    {
        public int UserId { get; set; }
        public int BidId { get; set; }
        public string Name { get; set; }
        public string Details { get; set; }
    }
}
