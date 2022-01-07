using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Petsitters.Domain;

namespace Petsitters.Persistence.EntityTypeConfigurations
{
    public class BidConfiguration : IEntityTypeConfiguration<Bid>
    {
        public void Configure(EntityTypeBuilder<Bid> builder)
        {
            builder.HasKey(bid => bid.Id);
            builder.HasIndex(bid => bid.Id).IsUnique();
            builder.HasOne(bid => bid.MyService).WithOne(myservice => myservice.Bid);
        }
    }
}
