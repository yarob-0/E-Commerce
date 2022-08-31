using Common;

namespace Domains.Product
{
    public class Product : BaseEntity
    {
        public string? ImagePath { get; set; }
        //public byte[] Image { get; set; }
        public decimal Price { get; set; }
        public float Rate { get; set; }
    }
}
