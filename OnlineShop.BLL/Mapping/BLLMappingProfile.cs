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
                .ForMember(dest => dest.Photos, opt => opt.MapFrom(src => GetPhotoStringList(src.Photos)))
                .ForMember(dest => dest.CategoryName, opt => opt.MapFrom(src => src.Category.CategoryName))
                .ForMember(dest => dest.CategoryId, opt => opt.MapFrom(src => src.Category.Id));
            CreateMap<AddProductDTO, Product>().ForMember(dest => dest.Photos, opt => opt.MapFrom(src => GetPhotoList(src.Photos)));
            CreateMap<UpdateProductDTO, Product>().ForMember(dest => dest.Photos, opt => opt.MapFrom(src => GetPhotoList(src.Photos)));
            
            CreateMap<Category, GetCategoryDTO>().ReverseMap();
            CreateMap<AddCategoryDTO, Category>().ReverseMap();
            CreateMap<UpdateCategoryDTO, Category>().ReverseMap();
            
            CreateMap<Photo, GetPhotoDTO>().ReverseMap();
            CreateMap<AddPhotoDTO, Photo>().ReverseMap();
        }

        List<string> GetPhotoStringList(List<Photo> photos)
        {
            List<string> stringList = new List<string>();

            foreach(Photo photo in photos)
            {
                stringList.Add(photo.PhotoURL);
            }

            return stringList;
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
