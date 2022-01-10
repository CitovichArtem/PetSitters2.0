using System;
using Petsitters.Persistence;

namespace Petsitters.Tests.Common
{
    public abstract class TestCommandBase : IDisposable
    {
        protected readonly AppDbContext Context;

        public TestCommandBase()
        {
            Context = PetsittersContextFactory.Create();
        }

        public void Dispose()
        {
            PetsittersContextFactory.Destroy(Context);
        }
    }
}
