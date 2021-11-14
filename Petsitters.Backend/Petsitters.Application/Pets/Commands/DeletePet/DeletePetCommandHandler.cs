using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Petsitters.Domain;
using Petsitters.Application.Interfaces;
using Petsitters.Application.Common.Exceptions;

namespace Petsitters.Application.Pets.Commands.DeletePet
{
    public class DeletePetCommandHandler : IRequestHandler<DeletePetCommand>
    {
        private readonly IAppDbContext _dbContext;

        public DeletePetCommandHandler(IAppDbContext dbContext) =>
            _dbContext = dbContext;

        public async Task<Unit> Handle(DeletePetCommand request,
            CancellationToken cancellationToken)
        {
            var entity = await _dbContext.Pets
                .FindAsync(new object[] { request.Id }, cancellationToken);

            if (entity == null || entity.UserId != request.UserId)
            {
                throw new NotFoundException(nameof(Pet), request.Id);
            }

            _dbContext.Pets.Remove(entity);
            await _dbContext.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
