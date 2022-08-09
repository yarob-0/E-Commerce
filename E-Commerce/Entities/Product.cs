namespace ECommerce
{
    public class Product : BaseEntity<Product>
    {
        public string ImagePath { get; set; }
        //public byte[] Image { get; set; }
        public decimal Price { get; set; }
        public float Rate { get; set; }

        public List<ProductCategory> ProductCategories { get; set; }
    }
}
