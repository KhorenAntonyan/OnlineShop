using AutoMapper;
using OnlineShop.BLL.DTOs.CategoryDTOs;
using OnlineShop.BLL.DTOs.ProductDTOs;
using OnlineShop.Web.Admin.ViewModels.CategoryViewModels;
using OnlineShop.Web.Admin.ViewModels.ProductViewModels;

namespace OnlineShop.Web.Admin.Mapping
{
    public class WebMappingProfile : Profile
    {
        public WebMappingProfile()
        {
            CreateMap<AddProductViewModel, AddProductDTO>().ReverseMap();
            CreateMap<GetProductDTO, GetProductViewModel>().ForMember(dest => dest.Photos, opt => opt.MapFrom(src => GetPhotoStringList(src.Photos)));
            CreateMap<UpdateProductViewModel, UpdateProductDTO>().ReverseMap();
            CreateMap<GetProductDTO, UpdateProductViewModel>();

            CreateMap<GetCategoryViewModel, GetCategoryDTO>().ReverseMap();
            CreateMap<AddCategoryViewModel, AddCategoryDTO>().ReverseMap();
            CreateMap<UpdateCategoryViewModel, UpdateCategoryDTO>().ReverseMap();
            CreateMap<UpdateCategoryViewModel, UpdateCategoryDTO>().ReverseMap();
            CreateMap<GetCategoryDTO, UpdateCategoryViewModel>();

        }

        List<string> GetPhotoStringList(List<string> photos)
        {
            List<string> stringList = new List<string>();

            foreach (string photo in photos)
            {
                stringList.Add(photo);
            }

            return stringList;
        }
    }
}
