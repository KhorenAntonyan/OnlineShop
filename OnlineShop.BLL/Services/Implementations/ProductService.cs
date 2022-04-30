using AutoMapper;
using OnlineShop.BLL.DTOs.ProductDTOs;
using OnlineShop.BLL.Services.Abstractions;
using OnlineShop.DAL.Entities;
using OnlineShop.DAL.Repositories.Abstractions;

namespace OnlineShop.BLL.Services.Implementations
{
    public class ProductService : BaseService<Product>, IProductService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IPhotoService _photoService;

        public ProductService(IUnitOfWork unitOfWork, IMapper mapper, IPhotoService photoService)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _photoService = photoService;
        }
        public void Add(AddProductDTO addProductDTO)
        {
            var photos = _photoService.AddFiles(addProductDTO.PhotoFiles, addProductDTO.Id);
            var product = _mapper.Map<Product>(addProductDTO);
            product.Photos = photos;
            _unitOfWork.ProductRepository.Add(product);
            _unitOfWork.Save();
        }

        public GetProductDTO FindById(int productId)
        {
            var product = _mapper.Map<GetProductDTO>(_unitOfWork.ProductRepository.FindById(productId));
            return product;
        }

        public IEnumerable<GetProductDTO> GetAll()
        {
            var addProduct = _mapper.Map<List<GetProductDTO>>(_unitOfWork.ProductRepository.GetAll());

            return addProduct;
        }

        public void Remove(int productId)
        {
            Product product = _unitOfWork.ProductRepository.FindById(productId);
            _unitOfWork.ProductRepository.Remove(product);
            _unitOfWork.Save();
        }

        public void Update(UpdateProductDTO updateProductDTO)
        {
            var updateProduct = _mapper.Map<Product>(updateProductDTO);
            _unitOfWork.ProductRepository.Update(updateProduct);
            _unitOfWork.Save();
        }
    }
}
