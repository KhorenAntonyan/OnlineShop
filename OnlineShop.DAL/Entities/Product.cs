
namespace OnlineShop.DAL.Entities
{
    public class Product : BaseEntity
    {
        public string ProductName { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
        public int? CategoryId { get; set; }
        public Category? Category { get; set; }
        public List<Photo> Photos { get; set; }
    }
}
