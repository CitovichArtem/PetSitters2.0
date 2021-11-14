using MediatR;
using Microsoft.EntityFrameworkCore;
using Petsitters.Application.Common.Exceptions;
using Petsitters.Application.Interfaces;
using Petsitters.Domain;
using System.Threading;
using System.Threading.Tasks;

namespace Petsitters.Application.Pets.Commands.UpdatePet
{
    public class UpdatePetCommandHandler
        : IRequestHandler<UpdatePetCommand>
    {
        private readonly IAppDbContext _dbContext;
        public UpdatePetCommandHandler(IAppDbContext dbContext) =>
            _dbContext = dbContext;
        public async Task<Unit> Handle(UpdatePetCommand request,
            CancellationToken cancellationToken)
        {
            var entity =
                await _dbContext.Pets.FirstOrDefaultAsync(pet =>
                pet.Id == request.Id, cancellationToken);

            if(entity == null || entity.User.Id != request.UserId)
            {
                throw new NotFoundException(nameof(Pet), request.Id);
            }

            entity.Age = request.Age;
            entity.Name = request.Name;

            await _dbContext.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
