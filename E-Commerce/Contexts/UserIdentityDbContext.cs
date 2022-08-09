namespace ECommerce
{
    using ECommerce.Entities.Configurations;
    using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore;

    public class UserIdentityDbContext : IdentityDbContext<User>
    {
        //private readonly string connectionString;
        public UserIdentityDbContext(DbContextOptions<UserIdentityDbContext>
                options) : base(options)
        {
        }

        //public UserIdentityDbContext(string connectionString)
        //{
            //this.connectionString = connectionString;
        //}

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
            //optionsBuilder.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString))
            //.EnableDetailedErrors().EnableSensitiveDataLogging()
            //.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
        //}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfigurationsFromAssembly(
                    typeof(UserIdentityDbContext).Assembly);
        }
    }
}
