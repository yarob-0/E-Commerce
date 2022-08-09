namespace ECommerce
{
    public class Category : BaseEntity<Category>
    {
        public List<ProductCategory> ProductCategories { get; set; }
    }
}
