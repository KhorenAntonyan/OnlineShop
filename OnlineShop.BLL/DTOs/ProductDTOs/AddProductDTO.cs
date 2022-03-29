namespace OnlineShop.BLL.DTOs.ProductDTOs
{
    public class AddProductDTO
    {
        public string ProductName { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
    }
}
