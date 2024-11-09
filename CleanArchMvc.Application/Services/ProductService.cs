using AutoMapper;
using CleanArchMvc.Application.DTOs;
using CleanArchMvc.Application.Interfaces;
using CleanArchMvc.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchMvc.Application.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _repository;
        private readonly Mapper _mapper;

        public ProductService(IProductRepository repository, Mapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public Task CreateProductAsync(ProductDTO product)
        {
            throw new NotImplementedException();
        }

        public Task DeleteProductAsync(int? id)
        {
            throw new NotImplementedException();
        }

        public Task<ProductDTO> GetProductByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<ProductDTO> GetProductCategoryByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<ProductDTO>> GetProductsAsync()
        {
            throw new NotImplementedException();
        }

        public Task UpdateProductAsync(ProductDTO product)
        {
            throw new NotImplementedException();
        }
    }
}
