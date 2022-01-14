using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Xunit;
using Petsitters.Application.Pets.Commands.DeletePet;
using Petsitters.Application.Pets.Commands.CreatePet;
using Petsitters.Application.Common.Exceptions;
using Petsitters.Tests.Common;

namespace Petsitters.Tests.Pets.Commands
{
    public class DeletePetCommandHandlerTests : TestCommandBase
    {
        [Fact]
        public async Task DeletePetCommandHandler_Success()
        {
            // Arrange
            var handler = new DeletePetCommandHandler(Context);

            // Act
            await handler.Handle(new DeletePetCommand
            {
                Id = PetsittersContextFactory.PetIdForDelete,
                UserId = PetsittersContextFactory.UserAId,
            }, CancellationToken.None);

            // Assert
            Assert.Null(Context.Pets.SingleOrDefault(pet =>
                pet.Id == PetsittersContextFactory.PetIdForDelete));
        }

        [Fact]
        public async Task DeletePetCommandHandler_FailOnWrongId()
        {
            // Arrange
            var handler = new DeletePetCommandHandler(Context);

            // Act
            // Assert
            await Assert.ThrowsAsync<NotFoundException>(async () =>
                await handler.Handle(
                    new DeletePetCommand
                    {
                        Id = Guid.NewGuid(),
                        UserId = PetsittersContextFactory.UserAId
                    },
                    CancellationToken.None));
        }

        [Fact]
        public async Task DeletePetCommandHandler_FailOnWrongUserId()
        {
            // Arrange
            var deleteHandler = new DeletePetCommandHandler(Context);
            var createHandler = new CreatePetCommandHandler(Context);
            var petId = await createHandler.Handle(
                new CreatePetCommand
                {
                    Name = "PetName",
                    UserId = PetsittersContextFactory.UserAId
                }, CancellationToken.None);

            // Act
            // Assert
            await Assert.ThrowsAsync<NotFoundException>(async () =>
                await deleteHandler.Handle(
                    new DeletePetCommand
                    {
                        Id = petId,
                        UserId = PetsittersContextFactory.UserBId
                    }, CancellationToken.None));
        }
    }
}
