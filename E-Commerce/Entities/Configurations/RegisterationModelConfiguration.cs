namespace ECommerce.Entities.Configurations
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class RegistrationModelConfiguration : IEntityTypeConfiguration<RegisterationModel>
    {
        public void Configure(EntityTypeBuilder<RegisterationModel> builder)
        {
			builder.HasNoKey();
			builder.Property(p => p.UserName).IsRequired();
			builder.Property(p => p.Email).IsRequired();
			builder.Property(p => p.Password).IsRequired();
        }
    }
}
