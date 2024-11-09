using CleanArchMvc.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchMvc.Application.Interfaces
{
    public interface IProductService
    {
        Task<IEnumerable<ProductDTO>> GetProductsAsync();

        Task<ProductDTO> GetProductByIdAsync(int id);

        Task<ProductDTO> GetProductCategoryByIdAsync(int id);

        Task CreateProductAsync(ProductDTO product);

        Task UpdateProductAsync(ProductDTO product);

        Task DeleteProductAsync(int? id);
    }
}
