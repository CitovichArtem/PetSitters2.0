using MediatR;
using Petsitters.Application.Interfaces;
using Petsitters.Domain;
using System.Threading;
using System.Threading.Tasks;
using System;

namespace Petsitters.Application.Feedbacks.Commands.CreateFeedback
{
    public class CreateFeedbackCommandHandler
        : IRequestHandler<CreateFeedbackCommand, Guid>
    {
        private readonly IAppDbContext _dbContext;
        public CreateFeedbackCommandHandler(IAppDbContext dbContext) =>
            _dbContext = dbContext;
        public async Task<Guid> Handle(CreateFeedbackCommand request,
            CancellationToken cancellationToken)
        {
            var feedback = new Feedback
            {
                OwnerUserId = request.OwnerUserId,
                WorkerUserId = request.WorkerUserId,
                Mark = request.Mark,
                Text = request.Text,
                Id = Guid.NewGuid()
            };

            await _dbContext.Feedbacks.AddAsync(feedback, cancellationToken);
            await _dbContext.SaveChangesAsync(cancellationToken);

            return feedback.Id;
        }
    }
}
