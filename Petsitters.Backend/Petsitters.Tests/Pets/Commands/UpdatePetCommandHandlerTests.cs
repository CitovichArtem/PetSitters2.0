using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Xunit;
using Petsitters.Application.Common.Exceptions;
using Petsitters.Application.Pets.Commands.UpdatePet;
using Petsitters.Tests.Common;

namespace Petsitters.Tests.Pets.Commands
{
    public class UpdatePetCommandHandlerTests : TestCommandBase
    {
        [Fact]
        public async Task UpdatePetCommandHandler_Success()
        {
            // Arrange
            var handler = new UpdatePetCommandHandler(Context);
            var updatedName = "new name";

            // Act
            await handler.Handle(new UpdatePetCommand
            {
                Id = PetsittersContextFactory.PetIdForUpdate,
                UserId = PetsittersContextFactory.UserBId,
                Name = updatedName
            }, CancellationToken.None);

            // Assert
            Assert.NotNull(await Context.Pets.SingleOrDefaultAsync(pet =>
                pet.Id == PetsittersContextFactory.PetIdForUpdate &&
                pet.Name == updatedName));
        }

        [Fact]
        public async Task UpdatePetCommandHandler_FailOnWrongId()
        {
            // Arrange
            var handler = new UpdatePetCommandHandler(Context);

            // Act
            // Assert
            await Assert.ThrowsAsync<NotFoundException>(async () =>
                await handler.Handle(
                    new UpdatePetCommand
                    {
                        Id = Guid.NewGuid(),
                        UserId = PetsittersContextFactory.UserAId
                    },
                    CancellationToken.None));
        }

        [Fact]
        public async Task UpdatePetCommandHandler_FailOnWrongUserId()
        {
            // Arrange
            var handler = new UpdatePetCommandHandler(Context);

            // Act
            // Assert
            await Assert.ThrowsAsync<NotFoundException>(async () =>
            {
                await handler.Handle(
                    new UpdatePetCommand
                    {
                        Id = PetsittersContextFactory.PetIdForUpdate,
                        UserId = PetsittersContextFactory.UserAId
                    },
                    CancellationToken.None);
            });
        }
    }
}
