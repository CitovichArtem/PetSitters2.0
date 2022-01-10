using MediatR;
using System;

namespace Petsitters.Application.MyServices.Commands.DeleteMyService
{
    public class DeleteMyServiceCommand : IRequest
    {
        public Guid UserId { get; set; }
        public Guid BidId { get; set; }
        public Guid Id { get; set; }
    }
}
