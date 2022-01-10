using AutoMapper;
using System;
using System.Threading;
using System.Threading.Tasks;
using Petsitters.Application.Pets.Queries.GetPetDetails;
using Petsitters.Persistence;
using Petsitters.Tests.Common;
using Shouldly;
using Xunit;

namespace Petsitters.Tests.Pets.Queries
{
    [Collection("QueryCollection")]
    public class GetPetDetailsQueryHandlerTests
    {
        private readonly AppDbContext Context;
        private readonly IMapper Mapper;

        public GetPetDetailsQueryHandlerTests(QueryTestFixture fixture)
        {
            Context = fixture.Context;
            Mapper = fixture.Mapper;
        }

        [Fact]
        public async Task GetPetDetailsQueryHandler_Success()
        {
            // Arrange
            var handler = new GetPetDetailsQueryHandler(Context, Mapper);

            // Act
            var result = await handler.Handle(
                new GetPetDetailsQuery
                {
                    UserId = PetsittersContextFactory.UserBId,
                    Id = Guid.Parse("F568DBCF-91C9-44B4-ABC6-EF9C292A4B51")
                },
                CancellationToken.None);

            // Assert
            result.ShouldBeOfType<PetDetailsVm>();
            result.Name.ShouldBe("Name2");
        }
    }
}
