using System;
using Microsoft.EntityFrameworkCore;
using Petsitters.Domain;
using Petsitters.Persistence;

namespace Petsitters.Tests.Common
{
    public class PetsittersContextFactory
    {
        public static Guid UserAId = Guid.NewGuid();
        public static Guid UserBId = Guid.NewGuid();

        public static Guid PetIdForDelete = Guid.NewGuid();
        public static Guid PetIdForUpdate = Guid.NewGuid();

        public static AppDbContext Create()
        {
            var options = new DbContextOptionsBuilder<AppDbContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                .Options;
            var context = new AppDbContext(options);
            context.Database.EnsureCreated();
            context.Pets.AddRange(
                new Pet
                {
                    
                    Name = "Name1",        
                    Id = Guid.Parse("{6E17B4B6-56AA-4E50-9A40-4EDE2E91F221}"),                    
                    UserId = UserAId
                },
                new Pet
                {
                    Name = "Name2",
                    Id = Guid.Parse("{F568DBCF-91C9-44B4-ABC6-EF9C292A4B51}"),
                    UserId = UserBId
                },
                new Pet
                {
                    Name = "Name3",
                    Id = PetIdForDelete,
                    UserId = UserAId
                },
                new Pet
                {
                    Name = "Name4",
                    Id = PetIdForUpdate,
                    UserId = UserBId
                }
            );
            context.SaveChanges();
            return context;
        }

        public static void Destroy(AppDbContext context)
        {
            context.Database.EnsureDeleted();
            context.Dispose();
        }
    }
}

