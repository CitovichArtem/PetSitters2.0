﻿using MediatR;
using Petsitters.Application.Interfaces;
using Petsitters.Domain;
using System.Threading;
using System.Threading.Tasks;

namespace Petsitters.Application.MyServices.Commands.CreateMyService
{
    public class CreateMyServiceCommandHandler
        : IRequestHandler<CreateMyServiceCommand, int>
    {
        private readonly IAppDbContext _dbContext;
        public CreateMyServiceCommandHandler(IAppDbContext dbContext) =>
            _dbContext = dbContext;
        public async Task<int> Handle(CreateMyServiceCommand request,
            CancellationToken cancellationToken)
        {
            var myService = new MyService
            {
                UserId = request.UserId,

                Name = request.Name,
                Details = request.Details,
                Id = new int()
            };

            await _dbContext.MyServices.AddAsync(myService, cancellationToken);
            await _dbContext.SaveChangesAsync(cancellationToken);

            return myService.Id;
        }
    }
}
