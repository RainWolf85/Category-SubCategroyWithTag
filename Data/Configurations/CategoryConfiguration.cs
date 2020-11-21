using Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.Configurations
{
    public class CategoryConfiguration : IEntityTypeConfiguration<Category>, IEntityConfiguration
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.Property(row => row.Name).HasMaxLength(256);
            builder.HasIndex(row => row.Name).IsUnique();
        }
    }
}