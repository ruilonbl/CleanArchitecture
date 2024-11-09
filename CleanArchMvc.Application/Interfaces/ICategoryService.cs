using CleanArchMvc.Application.DTOs;
using CleanArchMvc.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchMvc.Application.Interfaces
{
    public interface ICategoryService
    {
        Task<IEnumerable<CategoryDTO>> GetCategoriesAsync();

        Task<CategoryDTO> GetCategoryByIdAsync(int id);

        Task CreateCategoryAsync(CategoryDTO category);

        Task UpdateCategoryAsync(CategoryDTO category);

        Task DeleteCategoryAsync(int? id);
    }
}
