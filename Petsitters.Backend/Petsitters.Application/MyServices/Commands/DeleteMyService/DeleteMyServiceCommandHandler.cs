using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Petsitters.Domain;
using Petsitters.Application.Interfaces;
using Petsitters.Application.Common.Exceptions;

namespace Petsitters.Application.MyServices.Commands.DeleteMyService
{
    public class DeleteMyServiceCommandHandler : IRequestHandler<DeleteMyServiceCommand>
    {
        private readonly IAppDbContext _dbContext;

        public DeleteMyServiceCommandHandler(IAppDbContext dbContext) =>
            _dbContext = dbContext;

        public async Task<Unit> Handle(DeleteMyServiceCommand request,
            CancellationToken cancellationToken)
        {
            var entity = await _dbContext.MyServices
                .FindAsync(new object[] { request.Id }, cancellationToken);

            if (entity == null || entity.UserId != request.UserId)
            {
                throw new NotFoundException(nameof(MyService), request.Id);
            }

            _dbContext.MyServices.Remove(entity);
            await _dbContext.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
