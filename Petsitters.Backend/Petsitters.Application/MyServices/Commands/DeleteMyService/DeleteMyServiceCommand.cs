﻿using MediatR;

namespace Petsitters.Application.MyServices.Commands.DeleteMyService
{
    public class DeleteMyServiceCommand : IRequest
    {
        public int UserId { get; set; }
        public int BidId { get; set; }
        public int Id { get; set; }
    }
}