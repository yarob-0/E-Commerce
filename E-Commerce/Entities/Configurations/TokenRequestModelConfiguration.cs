namespace ECommerce.Entities.Configurations
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class TokenRequestModelConfiguration : IEntityTypeConfiguration<TokenRequestModel>
    {
        public void Configure(EntityTypeBuilder<TokenRequestModel> builder)
        {
			builder.HasNoKey();
			builder.Property(p => p.Email).IsRequired();
			builder.Property(p => p.Password).IsRequired();
        }
    }
}
