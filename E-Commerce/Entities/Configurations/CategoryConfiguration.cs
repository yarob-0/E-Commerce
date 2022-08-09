namespace ECommerce.Entities.Configurations
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class CategoryConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.HasKey(c => c.Id);

            builder.Property(c => c.Name).IsRequired().HasMaxLength(400);
            builder.Property(c => c.NameSecondLanguage).IsRequired().HasMaxLength(400);

            builder.Property(p => p.Description).IsRequired(false).HasMaxLength(5000).HasDefaultValue("nil");
            builder.Property(p => p.DescriptionSecondLanguage).IsRequired(false).HasMaxLength(5000).HasDefaultValue("nil");
        }
    }
}
