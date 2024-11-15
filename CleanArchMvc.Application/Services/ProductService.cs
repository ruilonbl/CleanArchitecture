using AutoMapper;
using CleanArchMvc.Application.DTOs;
using CleanArchMvc.Application.Interfaces;
using CleanArchMvc.Domain.Entities;
using CleanArchMvc.Domain.Interfaces;

namespace CleanArchMvc.Application.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _repository;
        private readonly IMapper _mapper;

        public ProductService(IProductRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task CreateProductAsync(ProductDTO productDto)
        {
            var product = _mapper.Map<Product>(productDto);
            await _repository.CreateProductAsync(product);
        }

        public async Task UpdateProductAsync(ProductDTO productDto)
        {
            var product = _mapper.Map<Product>(productDto);
            await _repository.UpdateProductAsync(product);
        }

        public async Task DeleteProductAsync(int? id)
        {
            var prodct = await _repository.GetProductByIdAsync(id);
            await _repository.DeleteProductAsync(prodct);
        }

        public async Task<ProductDTO> GetProductCategoryByIdAsync(int id)
        {
            var product = await _repository.GetProductCategoryAsync(id);
            return _mapper.Map<ProductDTO>(product);
        }

        public async Task<ProductDTO> GetProductByIdAsync(int? id)
        {
            var product = await _repository.GetProductByIdAsync(id);
            return _mapper.Map<ProductDTO>(product);
        }

        public async Task<IEnumerable<ProductDTO>> GetProductsAsync()
        {
            var products = await _repository.GetProductsAsync();
            return _mapper.Map<IEnumerable<ProductDTO>>(products);
        }

    }
}
