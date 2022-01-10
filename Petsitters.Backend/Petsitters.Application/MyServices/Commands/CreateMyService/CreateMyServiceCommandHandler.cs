using MediatR;
using Petsitters.Application.Interfaces;
using Petsitters.Domain;
using System.Threading;
using System.Threading.Tasks;
using System;

namespace Petsitters.Application.MyServices.Commands.CreateMyService
{
    public class CreateMyServiceCommandHandler
        : IRequestHandler<CreateMyServiceCommand, Guid>
    {
        private readonly IAppDbContext _dbContext;
        public CreateMyServiceCommandHandler(IAppDbContext dbContext) =>
            _dbContext = dbContext;
        public async Task<Guid> Handle(CreateMyServiceCommand request,
            CancellationToken cancellationToken)
        {
            var myService = new MyService
            {
                UserId = request.UserId,
                BidId = request.BidId,
                Name = request.Name,
                Details = request.Details,
                Id = Guid.NewGuid()
            };

            await _dbContext.MyServices.AddAsync(myService, cancellationToken);
            await _dbContext.SaveChangesAsync(cancellationToken);

            return myService.Id;
        }
    }
}
