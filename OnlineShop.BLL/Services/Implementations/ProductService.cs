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

        public async Task Add(AddProductDTO addProductDTO)
        {
            var photos = await _photoService.AddFiles(addProductDTO.PhotoFiles, addProductDTO.Id);
            var product = _mapper.Map<Product>(addProductDTO);
            product.Photos = photos;
            await _unitOfWork.ProductRepository.Add(product);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task<GetProductDTO> FindById(int productId)
        {
            var product = _mapper.Map<GetProductDTO>(await _unitOfWork.ProductRepository.FindById(productId));
            return product;
        }

        public async Task<IEnumerable<GetProductDTO>> GetAll()
        {
            var products = _mapper.Map<List<GetProductDTO>>(await _unitOfWork.ProductRepository.GetAll());
            return products;
        }

        public async Task Delete(int productId)
        {
            Product product = await _unitOfWork.ProductRepository.FindById(productId);
            await _unitOfWork.ProductRepository.Delete(product);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task Update(UpdateProductDTO updateProductDTO)
        {
            var updateProduct = _mapper.Map<Product>(updateProductDTO);
            await _unitOfWork.ProductRepository.Update(updateProduct);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task<IEnumerable<GetProductDTO>> ProductSorting(string sortingBy)
        {
            var products = _mapper.Map<List<GetProductDTO>>(await _unitOfWork.ProductRepository.GetAll());

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
