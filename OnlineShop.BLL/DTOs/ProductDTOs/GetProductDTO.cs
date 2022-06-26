
using OnlineShop.BLL.DTOs.PhotoDTOs;

namespace OnlineShop.BLL.DTOs.ProductDTOs
{
    public class GetProductDTO
    {
        public int Id { get; set; }
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
        public string ProductName { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
        public DateTime CreatedDate { get; set; }
        public List<GetPhotoDTO> Photos { get; set; }
    }
}
