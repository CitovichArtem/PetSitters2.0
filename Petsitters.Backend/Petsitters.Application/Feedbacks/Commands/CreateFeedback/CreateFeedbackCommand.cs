using MediatR;

namespace Petsitters.Application.Feedbacks.Commands.CreateFeedback
{
    public class CreateFeedbackCommand  : IRequest<int>
    {
        public string Name { get; set; }
        public int Mark { get; set; }
        public string Text { get; set; }
        public int OwnerUserId { get; set; }
        public int WorkerUserId { get; set; }

    }
}
