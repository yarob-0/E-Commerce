namespace ECommerce
{
    using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
    using Microsoft.AspNetCore.Identity;
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

            User admin = new User
            {
                Id = Guid.NewGuid().ToString(),
                ConcurrencyStamp = Guid.NewGuid().ToString(),
                UserName = Names.Admin.Value,
                NormalizedUserName = Names.Admin.Value.ToUpper(),
                Email = Emails.Admin.Value,
                NormalizedEmail = Emails.Admin.Value.ToUpper(),
            };

            User user = new User
            {
                Id = Guid.NewGuid().ToString(),
                ConcurrencyStamp = Guid.NewGuid().ToString(),
                UserName = Names.User.Value,
                NormalizedUserName = Names.User.Value.ToUpper(),
                Email = Emails.User.Value,
                NormalizedEmail = Emails.User.Value.ToUpper(),
            };

            IdentityRole userRole = new IdentityRole
            {
                Id = Guid.NewGuid().ToString(),
                ConcurrencyStamp = Guid.NewGuid().ToString(),
                Name = ECommerce.Roles.Admin.Value,
                NormalizedName = ECommerce.Roles.Admin.Value.ToUpper()
            };

            IdentityRole adminRole = new IdentityRole
            {
                Id = Guid.NewGuid().ToString(),
                ConcurrencyStamp = Guid.NewGuid().ToString(),
                Name = ECommerce.Roles.User.Value,
                NormalizedName = ECommerce.Roles.User.Value.ToUpper()
            };

            user.PasswordHash = new PasswordHasher<User>().HashPassword(user, Passwords.User.Value);
            admin.PasswordHash = new PasswordHasher<User>().HashPassword(admin, Passwords.Admin.Value);

            modelBuilder.Entity<User>().HasData(user, admin);

            modelBuilder.Entity<IdentityRole>().HasData(userRole, adminRole);

            modelBuilder.Entity<IdentityUserRole<string>>().HasData(
                    new IdentityUserRole<string>
                    {
                        UserId = admin.Id,
                        RoleId = adminRole.Id
                    },
                    new IdentityUserRole<string>
                    {
                        UserId = user.Id,
                        RoleId = userRole.Id
                    }
                    );

        }
    }
}
