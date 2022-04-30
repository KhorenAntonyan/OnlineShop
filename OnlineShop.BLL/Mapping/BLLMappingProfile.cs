using AutoMapper;
using OnlineShop.BLL.DTOs.CategoryDTOs;
using OnlineShop.BLL.DTOs.PhotoDTOs;
using OnlineShop.BLL.DTOs.ProductDTOs;
using OnlineShop.DAL.Entities;

namespace OnlineShop.BLL.Mapping
{
    public class BLLMappingProfile : Profile
    {
        public BLLMappingProfile()
        {
            CreateMap<Product, GetProductDTO>()
                .ForMember(dest => dest.Photos, opt => opt.MapFrom(src => GetPhotoList(src.Photos)))
                .ForMember(dest => dest.CategoryName, opt => opt.MapFrom(src => src.Category.CategoryName))
                .ForMember(dest => dest.CategoryId, opt => opt.MapFrom(src => src.Category.Id));
            //CreateMap<AddProductDTO, Product>().ForMember(dest => dest.Photos, opt => opt.MapFrom(src => GetPhotoList(src.Photos)));
            CreateMap<AddProductDTO, Product>();
            CreateMap<UpdateProductDTO, Product>().ForMember(dest => dest.Photos, opt => opt.MapFrom(src => GetPhotoList(src.Photos)));
            
            CreateMap<Category, GetCategoryDTO>().ReverseMap();
            CreateMap<AddCategoryDTO, Category>().ReverseMap();
            CreateMap<UpdateCategoryDTO, Category>().ReverseMap();
            
            CreateMap<Photo, GetPhotoDTO>().ReverseMap();
            CreateMap<AddPhotoDTO, Photo>().ReverseMap();
            CreateMap<UpdatePhotoDTO, Photo>().ReverseMap();
        }

        List<GetPhotoDTO> GetPhotoList(List<Photo> photos)
        {
            List<GetPhotoDTO> photoList = new List<GetPhotoDTO>();

            foreach (Photo photo in photos)
            {
                photoList.Add(new GetPhotoDTO
                {
                    Id = photo.Id,
                    PhotoURL = photo.PhotoURL,
                    ProductId = photo.ProductId,
                    IsMain = photo.IsMain
                });
            }

            return photoList;
        }

        List<Photo> GetPhotoList(List<string> photos)
        {
            List<Photo> photoList = new List<Photo>();

            foreach (string photo in photos)
            {
                Photo newPhoto = new Photo
                {
                    PhotoURL = photo
                };
                photoList.Add(newPhoto);
            }

            return photoList;
        }
    }
}
