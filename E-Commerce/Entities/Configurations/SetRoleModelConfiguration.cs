
namespace ECommerce.Entities.Configurations
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class SetRoleModelConriguration : IEntityTypeConfiguration<SetRoleModel>
    {
        public void Configure(EntityTypeBuilder<SetRoleModel> builder)
        {
			builder.HasNoKey();
			builder.Property(p => p.Email).IsRequired();
			builder.Property(p => p.RoleName).IsRequired();
        }
    }
}
