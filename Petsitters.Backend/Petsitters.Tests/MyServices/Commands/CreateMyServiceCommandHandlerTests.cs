using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Xunit;
using Petsitters.Application.MyServices.Commands.CreateMyService;
using Petsitters.Tests.Common;

namespace Petsitters.Tests.MyServices.Commands
{
    public class CreateMyServiceCommandHandlerTests : TestCommandBase
    {
        [Fact]
        public async Task CreateMyServiceCommandHandler_Success()
        {
            // Arrange
            var handler = new CreateMyServiceCommandHandler(Context);
            var myserviceName = "myservice name";

            // Act
            var myserviceId = await handler.Handle(
                new CreateMyServiceCommand
                {
                    Name = myserviceName,
                    UserId = PetsittersContextFactory.UserAId,
                    BidId = PetsittersContextFactory.BidAId
                },
                CancellationToken.None);

            // Assert
            Assert.NotNull(
                await Context.MyServices.SingleOrDefaultAsync(myservice =>
                    myservice.Id == myserviceId && myservice.Name == myserviceName));
        }
    }
}
