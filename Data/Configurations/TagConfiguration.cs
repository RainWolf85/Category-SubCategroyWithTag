using Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.Configurations
{
    public class TagConfiguration : IEntityTypeConfiguration<Tag>, IEntityConfiguration
    {
        public void Configure(EntityTypeBuilder<Tag> builder)
        {
            builder.Property(row => row.Name).HasMaxLength(256);
            builder.HasIndex(row => row.Name).IsUnique();

            builder.HasMany(e => e.Categories)
                .WithOne(e => e.Tag)
                .HasForeignKey(e => e.TagId);
        }
    }
}