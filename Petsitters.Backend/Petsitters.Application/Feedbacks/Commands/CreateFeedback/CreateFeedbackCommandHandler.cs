using MediatR;
using Petsitters.Application.Interfaces;
using Petsitters.Domain;
using System.Threading;
using System.Threading.Tasks;

namespace Petsitters.Application.Feedbacks.Commands.CreateFeedback
{
    public class CreateFeedbackCommandHandler
        : IRequestHandler<CreateFeedbackCommand, int>
    {
        private readonly IAppDbContext _dbContext;
        public CreateFeedbackCommandHandler(IAppDbContext dbContext) =>
            _dbContext = dbContext;
        public async Task<int> Handle(CreateFeedbackCommand request,
            CancellationToken cancellationToken)
        {
            var feedback = new Feedback
            {
                OwnerUserId = request.OwnerUserId,
                WorkerUserId = request.WorkerUserId,
                Mark = request.Mark,
                Text = request.Text,
                Id = new int()
            };

            await _dbContext.Feedbacks.AddAsync(feedback, cancellationToken);
            await _dbContext.SaveChangesAsync(cancellationToken);

            return feedback.Id;
        }
    }
}
