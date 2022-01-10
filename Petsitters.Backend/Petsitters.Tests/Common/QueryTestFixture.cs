using AutoMapper;
using System;
using Petsitters.Application.Interfaces;
using Petsitters.Application.Common.Mappings;
using Petsitters.Persistence;
using Xunit;

namespace Petsitters.Tests.Common
{
    public class QueryTestFixture : IDisposable
    {
        public AppDbContext Context;
        public IMapper Mapper;

        public QueryTestFixture()
        {
            Context = PetsittersContextFactory.Create();
            var configurationProvider = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new AssemblyMappingProfile(
                    typeof(IAppDbContext).Assembly));
            });
            Mapper = configurationProvider.CreateMapper();
        }

        public void Dispose()
        {
            PetsittersContextFactory.Destroy(Context);
        }
    }

    [CollectionDefinition("QueryCollection")]
    public class QueryCollection : ICollectionFixture<QueryTestFixture> { }
}
