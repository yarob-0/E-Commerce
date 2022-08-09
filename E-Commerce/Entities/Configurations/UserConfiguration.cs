namespace ECommerce.Entities.Configurations
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(p => p.Id);
			builder.Property(p => p.UserName).IsRequired().HasMaxLength(50);
			builder.Property(p => p.Email).IsRequired();
			builder.Property(p => p.EmailConfirmed).HasDefaultValue(0);
			builder.Property(p => p.PhoneNumber).IsRequired(false);
			builder.Property(p => p.PhoneNumberConfirmed).HasDefaultValue(0);
			builder.Property(p => p.TwoFactorEnabled).HasDefaultValue(0);
			builder.Property(p => p.LockoutEnabled).HasDefaultValue(0);
			builder.Property(p => p.AccessFailedCount).HasDefaultValue(0);
			builder.Property(p => p.PasswordHash).IsRequired();
        }
    }
}
