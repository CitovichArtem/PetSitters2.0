using System;
using MediatR;

namespace Petsitters.Application.MyServices.Commands.UpdateMyService
{
    public class UpdateMyServiceCommand : IRequest
    {
        public int UserId { get; set; }
        public int BidId { get; set; }
        public int Id { get; set; }
        public string Name { get; set; }
        public string Details { get; set; }
    }
}
