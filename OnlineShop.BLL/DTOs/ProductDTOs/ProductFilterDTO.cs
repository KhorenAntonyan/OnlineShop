﻿
namespace OnlineShop.BLL.DTOs.ProductDTOs
{
    public class ProductFilterDTO
    {
        public int? PriceRange { get; set; }
        public int? CategoryId { get; set; }
        public DateTime? DateTimeFrom { get; set; }
        public DateTime? DateTimeTo { get; set; }
    }
}
