namespace ECommerce
{
	using Microsoft.EntityFrameworkCore;
	using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class BaseEntityconfiguration<T> : IEntityTypeConfiguration<T> where
        T : BaseEntity
    {
        public BaseEntityconfiguration()
        {
        }

        public virtual void Configure(EntityTypeBuilder<T> builder)
        {
            builder.HasKey(e => e.Id);

            builder.Property(e => e.Name).IsRequired().HasMaxLength(400);
            builder.Property(e => e.NameSecondLanguage).IsRequired().HasMaxLength(400);

            builder.Property(e => e.Description).IsRequired(false).HasMaxLength(5000).HasDefaultValue("nil");
            builder.Property(e => e.DescriptionSecondLanguage).IsRequired(false).HasMaxLength(5000).HasDefaultValue("nil");
        }
    }
}
