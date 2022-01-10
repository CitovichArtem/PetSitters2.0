using System;
using MediatR;

namespace Petsitters.Application.MyServices.Commands.UpdateMyService
{
    public class UpdateMyServiceCommand : IRequest
    {
        public Guid UserId { get; set; }
        public Guid BidId { get; set; }
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Details { get; set; }
    }
}
