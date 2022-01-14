using AutoMapper;
using System;
using System.Threading;
using System.Threading.Tasks;
using Petsitters.Application.MyServices.Queries.GetMyServiceDetails;
using Petsitters.Persistence;
using Petsitters.Tests.Common;
using Shouldly;
using Xunit;

namespace Petsitters.Tests.MyServices.Queries
{
    [Collection("QueryCollection")]
    public class GetMyServiceDetailsQueryHandlerTests
    {
        private readonly AppDbContext Context;
        private readonly IMapper Mapper;

        public GetMyServiceDetailsQueryHandlerTests(QueryTestFixture fixture)
        {
            Context = fixture.Context;
            Mapper = fixture.Mapper;
        }

        [Fact]
        public async Task GetMyServiceDetailsQueryHandler_Success()
        {
            // Arrange
            var handler = new GetMyServiceDetailsQueryHandler(Context, Mapper);

            // Act
            var result = await handler.Handle(
                new GetMyServiceDetailsQuery
                {
                    UserId = PetsittersContextFactory.UserBId,
                    Id = Guid.Parse("2601C5F8-9EB9-4C0D-AE75-10A50B196EC9")
                },
                CancellationToken.None);

            // Assert
            result.ShouldBeOfType<MyServiceDetailsVm>();
            result.Name.ShouldBe("Name2");
        }
    }
}
