using Microsoft.EntityFrameworkCore;
using Petsitters.Application.Interfaces;
using Petsitters.Domain;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Design;
using Petsitters.Persistence.EntityTypeConfigurations;

namespace Petsitters.Persistence
{
    public class AppDbContext : DbContext, IAppDbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Pet> Pets { get; set; }
        public DbSet<Feedback> Feedbacks { get; set; }
        public DbSet<MyService> MyServices { get; set; }
        public DbSet<Bid> Bids { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options) { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new UserConfiguration());
            builder.ApplyConfiguration(new PetConfiguration());
            builder.ApplyConfiguration(new FeedbackConfiguration());
            builder.ApplyConfiguration(new MyServiceConfiguration());
            builder.ApplyConfiguration(new BidConfiguration());

            base.OnModelCreating(builder);
        }
    }
}
