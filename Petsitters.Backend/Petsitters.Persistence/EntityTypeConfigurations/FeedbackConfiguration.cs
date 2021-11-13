using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Petsitters.Domain;

namespace Petsitters.Persistence.EntityTypeConfigurations
{
    public class FeedbackConfiguration : IEntityTypeConfiguration<Feedback>
    {
        public void Configure(EntityTypeBuilder<Feedback> builder)
        {
            builder.HasKey(feedback => feedback.Id);
            builder.HasIndex(feedback => feedback.Id).IsUnique();
        }
    }
}
