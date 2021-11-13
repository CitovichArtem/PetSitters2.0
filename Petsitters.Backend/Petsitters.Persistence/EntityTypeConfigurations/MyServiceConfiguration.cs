using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Petsitters.Domain;

namespace Petsitters.Persistence.EntityTypeConfigurations
{
    public class MyServiceConfiguration :IEntityTypeConfiguration<MyService>
    {
        public void Configure(EntityTypeBuilder<MyService> builder)
        {
            builder.HasKey(myservice => myservice.Id);
            builder.HasIndex(myservice => myservice.Id).IsUnique();
            builder.Property(myservice => myservice.Name).HasMaxLength(250);
        }
    }
}
