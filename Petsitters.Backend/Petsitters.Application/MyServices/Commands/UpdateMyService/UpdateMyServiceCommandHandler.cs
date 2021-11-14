using MediatR;
using Microsoft.EntityFrameworkCore;
using Petsitters.Application.Common.Exceptions;
using Petsitters.Application.Interfaces;
using Petsitters.Domain;
using System.Threading;
using System.Threading.Tasks;

namespace Petsitters.Application.MyServices.Commands.UpdateMyService
{
    public class UpdateMyServiceCommandHandler
        : IRequestHandler<UpdateMyServiceCommand>
    {
        private readonly IAppDbContext _dbContext;
        public UpdateMyServiceCommandHandler(IAppDbContext dbContext) =>
            _dbContext = dbContext;
        public async Task<Unit> Handle(UpdateMyServiceCommand request,
            CancellationToken cancellationToken)
        {
            var entity =
                await _dbContext.MyServices.FirstOrDefaultAsync(myServices =>
                myServices.Id == request.Id, cancellationToken);

            if (entity == null || entity.Worker.Id != request.UserId)
            {
                throw new NotFoundException(nameof(Pet), request.Id);
            }

            entity.Details = request.Details;
            entity.Name = request.Name;

            await _dbContext.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
