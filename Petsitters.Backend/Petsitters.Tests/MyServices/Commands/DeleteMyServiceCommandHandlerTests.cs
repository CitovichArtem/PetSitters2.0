using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Xunit;
using Petsitters.Application.MyServices.Commands.DeleteMyService;
using Petsitters.Application.MyServices.Commands.CreateMyService;
using Petsitters.Application.Common.Exceptions;
using Petsitters.Tests.Common;

namespace Petsitters.Tests.MyServices.Commands
{
    public class DeleteMyServiceCommandHandlerTests : TestCommandBase
    {
        [Fact]
        public async Task DeleteMyServiceCommandHandler_Success()
        {
            // Arrange
            var handler = new DeleteMyServiceCommandHandler(Context);

            // Act
            await handler.Handle(new DeleteMyServiceCommand
            {
                Id = PetsittersContextFactory.PetIdForDelete,
                UserId = PetsittersContextFactory.UserAId,
                BidId = PetsittersContextFactory.BidAId
            }, CancellationToken.None);

            // Assert
            Assert.Null(Context.MyServices.SingleOrDefault(myservice =>
                myservice.Id == PetsittersContextFactory.MyServiceIdForDelete));
        }

        [Fact]
        public async Task DeleteMyServiceCommandHandler_FailOnWrongId()
        {
            // Arrange
            var handler = new DeleteMyServiceCommandHandler(Context);

            // Act
            // Assert
            await Assert.ThrowsAsync<NotFoundException>(async () =>
                await handler.Handle(
                    new DeleteMyServiceCommand
                    {
                        Id = Guid.NewGuid(),
                        UserId = PetsittersContextFactory.UserAId,
                        BidId = PetsittersContextFactory.BidAId
                    },
                    CancellationToken.None));
        }

        [Fact]
        public async Task DeleteMyServiceCommandHandler_FailOnWrongUserId()
        {
            // Arrange
            var deleteHandler = new DeleteMyServiceCommandHandler(Context);
            var createHandler = new CreateMyServiceCommandHandler(Context);
            var myserviceId = await createHandler.Handle(
                new CreateMyServiceCommand
                {
                    Name = "MyServiceName",
                    UserId = PetsittersContextFactory.UserAId,
                    BidId = PetsittersContextFactory.BidAId
                }, CancellationToken.None);

            // Act
            // Assert
            await Assert.ThrowsAsync<NotFoundException>(async () =>
                await deleteHandler.Handle(
                    new DeleteMyServiceCommand
                    {
                        Id = myserviceId,
                        UserId = PetsittersContextFactory.UserBId,
                        BidId = PetsittersContextFactory.BidBId
                    }, CancellationToken.None));
        }
    }
}
