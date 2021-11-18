using MediatR;
using System.Collections.Generic;

namespace Petsitters.Application.MyServices.Commands.DeleteMyService
{
    public class DeleteMyServiceCommand : IRequest
    {
        public int UserId { get; set; }
        public List<int> BidId { get; set; }
        public int Id { get; set; }
    }
}
