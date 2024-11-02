using CleanArchMvc.Domain.Entities;

namespace CleanArchMvc.Domain.Interfaces;

public interface IProductRepository
{
    Task<IEnumerable<Product>> GetProductsAsync();
    
    Task<Product> GetProductByIdAsync(int? id);
    
    Task<Product> GetProductByCategoryAsync(int? categoryId);
    
    Task<Product> CreateProductAsync(Product product);
    
    Task<Product> UpdateProductAsync(Product product);
    
    Task<Product> DeleteProductAsync(Product product);
}