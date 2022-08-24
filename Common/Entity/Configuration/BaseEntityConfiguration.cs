namespace Common
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class BaseEntityconfiguration<T> : IEntityTypeConfiguration<T> where
        T : BaseEntity
    {
        public virtual void Configure(EntityTypeBuilder<T> builder)
        {
            builder.HasKey(e => e.Id);

            builder.Property(e => e.Name).IsRequired().HasMaxLength(50);
            builder.Property(e => e.NameSecondLanguage).IsRequired().HasMaxLength(50);

            builder.Property(e => e.Description)
				.IsRequired(false).HasMaxLength(500).HasDefaultValue("null");
            builder.Property(e => e.DescriptionSecondLanguage)
				.IsRequired(false).HasMaxLength(500).HasDefaultValue("null");
        }
    }
}
