using MediatR;
using System;

namespace Petsitters.Application.Feedbacks.Commands.CreateFeedback
{
    public class CreateFeedbackCommand  : IRequest<Guid>
    {
        public string Name { get; set; }
        public int Mark { get; set; }
        public string Text { get; set; }
        public Guid OwnerUserId { get; set; }
        public Guid WorkerUserId { get; set; }

    }
}
