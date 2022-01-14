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

        public static Guid BidAId = Guid.NewGuid();
        public static Guid BidBId = Guid.NewGuid();

        public static Guid PetIdForDelete = Guid.NewGuid();
        public static Guid PetIdForUpdate = Guid.NewGuid();

        public static Guid MyServiceIdForDelete = Guid.NewGuid();
        public static Guid MyServiceIdForUpdate = Guid.NewGuid();



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
                    UserId = UserAId,
                    BidId = BidAId,
                },
                new Pet
                {
                    Name = "Name2",
                    Id = Guid.Parse("{F568DBCF-91C9-44B4-ABC6-EF9C292A4B51}"),
                    UserId = UserBId,
                    BidId = BidBId,
                },
                new Pet
                {
                    Name = "Name3",
                    Id = PetIdForDelete,
                    UserId = UserAId,
                    BidId = BidAId,
                },
                new Pet
                {
                    Name = "Name4",
                    Id = PetIdForUpdate,
                    UserId = UserBId,
                    BidId= BidBId,
                }
            );
            context.MyServices.AddRange(
                new MyService
                {

                    Name = "Name1",
                    Details = "Details1",
                    Id = Guid.Parse("{88354015-DBF4-4145-B903-63334625D645}"),
                    UserId = UserAId,
                    BidId = BidAId,
                },
                new MyService
                {
                    Name = "Name2",
                    Details = "Details2",
                    Id = Guid.Parse("{2601C5F8-9EB9-4C0D-AE75-10A50B196EC9}"),
                    UserId = UserBId,
                    BidId = BidBId,
                },
                new MyService
                {
                    Name = "Name3",
                    Details = "Details3",
                    Id = PetIdForDelete,
                    UserId = UserAId,
                    BidId = BidAId,
                },
                new MyService
                {
                    Name = "Name4",
                    Details = "Details4",
                    Id = PetIdForUpdate,
                    UserId = UserBId,
                    BidId = BidBId,
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

