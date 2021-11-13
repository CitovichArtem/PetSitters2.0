using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Petsitters.Domain;

namespace Petsitters.Application.Interfaces
{
    public interface IAppDbContext
    {
        DbSet<User> Users { get; set; }
        DbSet<Pet> Pets { get; set; } 
        DbSet<Feedback> Feedbacks { get; set; }
        DbSet<MyService> MyServices { get; set; }
        DbSet<Bid> Bids { get; set; }
        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
