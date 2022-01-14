using AutoMapper;
using System.Threading;
using System.Threading.Tasks;
using Petsitters.Application.MyServices.Queries.GetMyServiceList;
using Petsitters.Persistence;
using Petsitters.Tests.Common;
using Shouldly;
using Xunit;

namespace Petsitters.Tests.MyServices.Queries
{
    [Collection("QueryCollection")]
    public class GetMyServiceListQueryHandlerTests
    {
        private readonly AppDbContext Context;
        private readonly IMapper Mapper;

        public GetMyServiceListQueryHandlerTests(QueryTestFixture fixture)
        {
            Context = fixture.Context;
            Mapper = fixture.Mapper;
        }

        [Fact]
        public async Task GetMyServiceListQueryHandler_Success()
        {
            // Arrange
            var handler = new GetMyServiceListQueryHandler(Context, Mapper);

            // Act
            var result = await handler.Handle(
                new GetMyServiceListQuery
                {
                    UserId = PetsittersContextFactory.UserBId
                },
                CancellationToken.None);

            // Assert
            result.ShouldBeOfType<MyServiceListVm>();
            result.MyServices.Count.ShouldBe(2);
        }
    }
}
