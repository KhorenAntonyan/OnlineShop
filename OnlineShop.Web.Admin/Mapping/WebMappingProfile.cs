using AutoMapper;
using OnlineShop.BLL.DTOs.CategoryDTOs;
using OnlineShop.BLL.DTOs.PhotoDTOs;
using OnlineShop.BLL.DTOs.ProductDTOs;
using OnlineShop.Web.Admin.ViewModels.CategoryViewModels;
using OnlineShop.Web.Admin.ViewModels.PhotoViewModels;
using OnlineShop.Web.Admin.ViewModels.ProductViewModels;

namespace OnlineShop.Web.Admin.Mapping
{
    public class WebMappingProfile : Profile
    {
        public WebMappingProfile()
        {
            CreateMap<AddProductViewModel, AddProductDTO>().ReverseMap();
            CreateMap<GetProductDTO, GetProductViewModel>().ForMember(dest => dest.Photos, opt => opt.MapFrom(src => GetPhotoViewModelList(src.Photos)));
            CreateMap<UpdateProductViewModel, UpdateProductDTO>().ReverseMap();
            CreateMap<GetProductDTO, UpdateProductViewModel>().ForMember(dest => dest.Photos, opt => opt.MapFrom(src => GetPhotoViewModelList(src.Photos)));

            CreateMap<GetCategoryViewModel, GetCategoryDTO>().ReverseMap();
            CreateMap<AddCategoryViewModel, AddCategoryDTO>().ReverseMap();
            CreateMap<UpdateCategoryViewModel, UpdateCategoryDTO>().ReverseMap();
            CreateMap<UpdateCategoryViewModel, UpdateCategoryDTO>().ReverseMap();
            CreateMap<GetCategoryDTO, UpdateCategoryViewModel>();

            CreateMap<GetPhotoViewModel, UpdatePhotoDTO>().ReverseMap();

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


        List<GetPhotoViewModel> GetPhotoViewModelList(List<GetPhotoDTO> photos)
        {
            List<GetPhotoViewModel> photoViewModelList = new List<GetPhotoViewModel>();

            foreach(GetPhotoDTO photo in photos)
            {
                photoViewModelList.Add(new GetPhotoViewModel
                {
                    Id = photo.Id,
                    PhotoURL = photo.PhotoURL,
                    ProductId = photo.ProductId,
                    IsMain = photo.IsMain
                });
            }

            return photoViewModelList;
        }
    }
}
