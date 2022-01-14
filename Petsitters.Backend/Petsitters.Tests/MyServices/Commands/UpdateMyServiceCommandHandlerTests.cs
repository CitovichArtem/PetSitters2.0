using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Xunit;
using Petsitters.Application.Common.Exceptions;
using Petsitters.Application.MyServices.Commands.UpdateMyService;
using Petsitters.Tests.Common;

namespace Petsitters.Tests.MyServices.Commands
{
    public class UpdateMyServiceCommandHandlerTests : TestCommandBase
    {
        [Fact]
        public async Task UpdateMyServiceCommandHandler_Success()
        {
            // Arrange
            var handler = new UpdateMyServiceCommandHandler(Context);
            var updatedName = "new name";

            // Act
            await handler.Handle(new UpdateMyServiceCommand
            {
                Id = PetsittersContextFactory.MyServiceIdForUpdate,
                UserId = PetsittersContextFactory.UserBId,
                BidId = PetsittersContextFactory.BidBId,
                Name = updatedName
            }, CancellationToken.None);

            // Assert
            Assert.NotNull(await Context.MyServices.SingleOrDefaultAsync(myservice =>
                myservice.Id == PetsittersContextFactory.MyServiceIdForUpdate &&
                myservice.Name == updatedName));
        }

        [Fact]
        public async Task UpdateMyServiceCommandHandler_FailOnWrongId()
        {
            // Arrange
            var handler = new UpdateMyServiceCommandHandler(Context);

            // Act
            // Assert
            await Assert.ThrowsAsync<NotFoundException>(async () =>
                await handler.Handle(
                    new UpdateMyServiceCommand
                    {
                        Id = Guid.NewGuid(),
                        UserId = PetsittersContextFactory.UserAId,
                        BidId = PetsittersContextFactory.BidAId
                    },
                    CancellationToken.None));
        }

        [Fact]
        public async Task UpdateMyServiceCommandHandler_FailOnWrongUserId()
        {
            // Arrange
            var handler = new UpdateMyServiceCommandHandler(Context);

            // Act
            // Assert
            await Assert.ThrowsAsync<NotFoundException>(async () =>
            {
                await handler.Handle(
                    new UpdateMyServiceCommand
                    {
                        Id = PetsittersContextFactory.MyServiceIdForUpdate,
                        UserId = PetsittersContextFactory.UserAId,
                        BidId = PetsittersContextFactory.BidAId
                    },
                    CancellationToken.None);
            });
        }
    }
}
