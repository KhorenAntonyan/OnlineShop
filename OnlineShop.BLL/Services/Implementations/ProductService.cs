using AutoMapper;
using OnlineShop.BLL.DTOs.PhotoDTOs;
using OnlineShop.BLL.DTOs.ProductDTOs;
using OnlineShop.BLL.Services.Abstractions;
using OnlineShop.DAL.Entities;
using OnlineShop.DAL.Repositories.Abstractions;

namespace OnlineShop.BLL.Services.Implementations
{
    public class ProductService : BaseService<Product>, IProductService
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper _mapper;

        public ProductService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public void Add(AddProductDTO addProductDTO)
        {
            var product = _mapper.Map<Product>(addProductDTO);
            unitOfWork.ProductRepository.Add(product);
            unitOfWork.Save();
        }

        public GetProductDTO FindById(int productId)
        {
            var product = _mapper.Map<GetProductDTO>(unitOfWork.ProductRepository.FindById(productId));
            return product;
        }

        public IEnumerable<GetProductDTO> GetAll()
        {
            var addProduct = _mapper.Map<List<GetProductDTO>>(unitOfWork.ProductRepository.GetAll());

            return addProduct;
        }

        public void Remove(int productId)
        {
            Product product = unitOfWork.ProductRepository.FindById(productId);
            unitOfWork.ProductRepository.Remove(product);
            unitOfWork.Save();
        }

        public void Update(UpdateProductDTO updateProductDTO)
        {
            var updateProduct = _mapper.Map<Product>(updateProductDTO);
            unitOfWork.ProductRepository.Update(updateProduct);
            unitOfWork.Save();
        }
    }
}
