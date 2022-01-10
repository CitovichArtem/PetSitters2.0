using MediatR;
using System;
using Petsitters.Application.Interfaces;
using Petsitters.Domain;
using System.Threading;
using System.Threading.Tasks;

namespace Petsitters.Application.Pets.Commands.CreatePet
{
    public class CreatePetCommandHandler 
        :IRequestHandler<CreatePetCommand, Guid>
    {
        private readonly IAppDbContext _dbContext;
        public CreatePetCommandHandler(IAppDbContext dbContext) =>
            _dbContext = dbContext;
        public async Task<Guid> Handle(CreatePetCommand request,
            CancellationToken cancellationToken)
        {
            var pet = new Pet
            {
                UserId = request.UserId,
                Name = request.Name,
                Age = request.Age,
                Id = Guid.NewGuid()
            };

            await _dbContext.Pets.AddAsync(pet, cancellationToken);
            await _dbContext.SaveChangesAsync(cancellationToken);

            return pet.Id;
        }
    }
}
