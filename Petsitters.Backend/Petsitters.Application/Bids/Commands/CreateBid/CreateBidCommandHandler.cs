using MediatR;
using Petsitters.Application.Interfaces;
using Petsitters.Domain;
using System.Threading;
using System.Threading.Tasks;
using System;

namespace Petsitters.Application.Bids.Commands.CreateBid
{
    public class CreateBidCommandHandler
        : IRequestHandler<CreateBidCommand, int>
    {
        private readonly IAppDbContext _dbContext;
        public CreateBidCommandHandler(IAppDbContext dbContext) =>
            _dbContext = dbContext;
        public async Task<int> Handle(CreateBidCommand request,
            CancellationToken cancellationToken)
        {
            var bid = new Bid
            {
                Name = request.Name,
                PetId = request.PetId,
                MyServiceId = request.MyServiceID,
                CreationDate = DateTime.Now,
                EditDate = null,
                Id = new int()
            };

            await _dbContext.Bids.AddAsync(bid, cancellationToken);
            await _dbContext.SaveChangesAsync(cancellationToken);

            return bid.Id;
        }
    }
}
