namespace ECommerce
{
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

			modelBuilder.Entity<Product>().HasData(new Product {
					Id = Guid.NewGuid(),
					Name = "product 1",
					NameSecondLanguage = "منتج ١",
					Description = " a detalied discription of Produce 1",
					DescriptionSecondLanguage = "وصف مفصل لمنتج ١",
					Price = 2345,
					Rate = 1,
					},
					new Product {
					Id = Guid.NewGuid(),
					Name = "product 2",
					NameSecondLanguage = "منتج ٢",
					Description = " a detalied discription of Produce 2",
					DescriptionSecondLanguage = "وصف مفصل لمنتج ٢",
					Price = 25,
					Rate = 3,
					}
					);
			modelBuilder.Entity<Category>().HasData(new Category {
					Id = Guid.NewGuid(),
					Name = "Category 1",
					NameSecondLanguage = "تصنيف  ١",
					},
					new Category {
					Id = Guid.NewGuid(),
					Name = "Category 2",
					NameSecondLanguage = "تصنيف  ٢",
					}
					);
        }
    }
}
