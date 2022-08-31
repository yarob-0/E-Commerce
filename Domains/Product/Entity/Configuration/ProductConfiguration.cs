namespace Domains.Product
{
    using Common;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class ProductConfiguration : BaseEntityconfiguration<Product>
    {
        public override void Configure(EntityTypeBuilder<Product> builder)
        {
			builder.Property(p => p.Price).HasDefaultValue(-1);
			builder.Property(p => p.Rate).HasDefaultValue(-1);
        }
    }
}
