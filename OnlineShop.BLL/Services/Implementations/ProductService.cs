using AutoMapper;
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
        public Task Add(AddProductDTO addProductDTO)
        {
            var product = _mapper.Map<Product>(addProductDTO);

            unitOfWork.ProductRepository.Add(product);
            unitOfWork.Save();

            return Task.CompletedTask;
        }

        public IEnumerable<AddProductDTO> GetAll()
        {
            var addProduct = _mapper.Map<List<AddProductDTO>>(unitOfWork.ProductRepository.GetAll());

            return addProduct;
        }

        public void Remove(int productId)
        {
            Product product = unitOfWork.ProductRepository.FindById(productId);
            unitOfWork.ProductRepository.Remove(product);
            unitOfWork.Save();
        }

        public void Update(int productId)
        {
            Product updateProduct = unitOfWork.ProductRepository.FindById(productId);

            unitOfWork.ProductRepository.Update(updateProduct);
            unitOfWork.Save();
        }
    }
}
