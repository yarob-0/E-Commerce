
namespace ECommerce
{
	using Microsoft.EntityFrameworkCore;
    using Domains.Product;
    using Domains.Category;

    public class ApplicationDbContext : DbContext
    {
		public ApplicationDbContext(DbContextOptions<ApplicationDbContext>
				options) : base(options)
        {
        }
		
        protected override void OnModelCreating(ModelBuilder modelBuilder){
        	
            modelBuilder.Entity<Product>().HasData(
			new Product {
                Id = Guid.NewGuid(),
                Name = "product 1",
                NameSecondLanguage = "منتج ١",
                Description = " a detalied discription of Produce 1",
                DescriptionSecondLanguage = "وصف مفصل لمنتج ١",
                Price = 2345,
                Rate = 1
            },
			new Product {
				Id = Guid.NewGuid(),
				Name = "product 2",
				NameSecondLanguage = "منتج ٢",
				Description = " a detalied discription of Produce 2",
				DescriptionSecondLanguage = "وصف مفصل لمنتج ٢",
				Price = 25,
				Rate = 3
			});

            modelBuilder.Entity<Category>().HasData(
			new Category {
                Id = Guid.NewGuid(),
                Name = "Category 1",
                NameSecondLanguage = "تصنيف  ١"
            },
			new Category {
				Id = Guid.NewGuid(),
				Name = "Category 2",
				NameSecondLanguage = "تصنيف  ٢"});
        }
    }

}
