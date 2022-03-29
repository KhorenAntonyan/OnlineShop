using AutoMapper;
using OnlineShop.BLL.DTOs.CategoryDTOs;
using OnlineShop.BLL.DTOs.ProductDTOs;
using OnlineShop.Web.Admin.ViewModels;

namespace OnlineShop.Web.Admin.Mapping
{
    public class WebMappingProfile : Profile
    {
        public WebMappingProfile()
        {
            CreateMap<ProductViewModel, AddProductDTO>().ReverseMap();
            CreateMap<CategoryViewModel, CategoryDTO>().ReverseMap();
            CreateMap<CategoryViewModel, GetCategoryDTO>().ReverseMap();
        }
    }
}
