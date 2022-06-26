using AutoMapper;
using OnlineShop.BLL.DTOs.ProductDTOs;
using OnlineShop.BLL.Services.Abstractions;
using OnlineShop.Core.Enums;
using OnlineShop.DAL.Entities;
using OnlineShop.DAL.Repositories.Abstractions;

namespace OnlineShop.BLL.Services.Implementations
{
    public class ProductService : BaseService<Product>, IProductService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IPhotoService _photoService;
        private readonly IFilterService _filterService;

        public ProductService(IUnitOfWork unitOfWork, IMapper mapper, IPhotoService photoService, IFilterService filterService)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _photoService = photoService;
            _filterService = filterService;
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

        public async Task<IEnumerable<GetProductDTO>> GetAll()
        {
            var products = _mapper.Map<List<GetProductDTO>>(_unitOfWork.ProductRepository.GetAll());

            return products;
        }

        public void Delete(int productId)
        {
            Product product = _unitOfWork.ProductRepository.FindById(productId);
            _unitOfWork.ProductRepository.Delete(product);
            _unitOfWork.Save();
        }

        public void Update(UpdateProductDTO updateProductDTO)
        {
            var updateProduct = _mapper.Map<Product>(updateProductDTO);
            _unitOfWork.ProductRepository.Update(updateProduct);
            _unitOfWork.Save();
        }

        public async Task<List<GetProductDTO>> ProductSorting(string sortingBy)
        {
            var products = _mapper.Map<List<GetProductDTO>>(_unitOfWork.ProductRepository.GetAll());

            switch (sortingBy)
            {
                case "price":
                    if (_filterService.Price.OrderBy == SortingOrder.Asc)
                    {
                        products = products.OrderBy(p => p.Price).ToList();
                        _filterService.Price.OrderBy = SortingOrder.Desc;
                    }
                    else
                    {
                        products = products.OrderByDescending(p => p.Price).ToList();
                        _filterService.Price.OrderBy = SortingOrder.Asc;
                    }
                    break;
                case "quantity":
                    if (_filterService.Quantity.OrderBy == SortingOrder.Asc)
                    {
                        products = products.OrderBy(p => p.Quantity).ToList();
                        _filterService.Quantity.OrderBy = SortingOrder.Desc;
                    }
                    else
                    {
                        products = products.OrderByDescending(p => p.Quantity).ToList();
                        _filterService.Quantity.OrderBy = SortingOrder.Asc;
                    }
                    break;
                case "createdDate":
                    if (_filterService.CreatedDate.OrderBy == SortingOrder.Asc)
                    {
                        products = products.OrderBy(p => p.CreatedDate).ToList();
                        _filterService.CreatedDate.OrderBy = SortingOrder.Desc;
                    }
                    else
                    {
                        products = products.OrderByDescending(p => p.CreatedDate).ToList();
                        _filterService.CreatedDate.OrderBy = SortingOrder.Asc;
                    }
                    break;
                case "reset":
                    _filterService.Price.OrderBy = SortingOrder.Asc;
                    _filterService.Quantity.OrderBy = SortingOrder.Asc;
                    _filterService.CreatedDate.OrderBy = SortingOrder.Asc;
                    break;
            }

            return products;
        }
    }
}
