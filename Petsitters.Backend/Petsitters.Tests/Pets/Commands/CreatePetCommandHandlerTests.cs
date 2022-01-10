using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Xunit;
using Petsitters.Application.Pets.Commands.CreatePet;
using Petsitters.Tests.Common;

namespace Petsitters.Tests.Pets.Commands
{
    public class CreatePetCommandHandlerTests : TestCommandBase
    {
        [Fact]
        public async Task CreatePetCommandHandler_Success()
        {
            // Arrange
            var handler = new CreatePetCommandHandler(Context);
            var petName = "pet name";

            // Act
            var petId = await handler.Handle(
                new CreatePetCommand
                {
                    Name = petName,
                    UserId = PetsittersContextFactory.UserAId
                },
                CancellationToken.None);

            // Assert
            Assert.NotNull(
                await Context.Pets.SingleOrDefaultAsync(pet =>
                    pet.Id == petId && pet.Name == petName ));
        }
    }
}
