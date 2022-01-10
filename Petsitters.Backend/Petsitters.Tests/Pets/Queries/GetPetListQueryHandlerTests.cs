using AutoMapper;
using System.Threading;
using System.Threading.Tasks;
using Petsitters.Application.Pets.Queries.GetPetList;
using Petsitters.Persistence;
using Petsitters.Tests.Common;
using Shouldly;
using Xunit;

namespace Petsitters.Tests.Pets.Queries
{
    [Collection("QueryCollection")]
    public class GetPetListQueryHandlerTests
    {
        private readonly AppDbContext Context;
        private readonly IMapper Mapper;

        public GetPetListQueryHandlerTests(QueryTestFixture fixture)
        {
            Context = fixture.Context;
            Mapper = fixture.Mapper;
        }

        [Fact]
        public async Task GetPetListQueryHandler_Success()
        {
            // Arrange
            var handler = new GetPetListQueryHandler(Context, Mapper);

            // Act
            var result = await handler.Handle(
                new GetPetListQuery
                {
                    UserId = PetsittersContextFactory.UserBId
                },
                CancellationToken.None);

            // Assert
            result.ShouldBeOfType<PetListVm>();
            result.Pets.Count.ShouldBe(2);
        }
    }
}
