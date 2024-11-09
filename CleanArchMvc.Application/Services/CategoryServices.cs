using AutoMapper;
using CleanArchMvc.Application.DTOs;
using CleanArchMvc.Application.Interfaces;
using CleanArchMvc.Domain.Entities;
using CleanArchMvc.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchMvc.Application.Services
{
    public class CategoryServices : ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IMapper _mapper;

        public CategoryServices(ICategoryRepository categoryRepository, IMapper mapper)
        {
            _categoryRepository = categoryRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<CategoryDTO>> GetCategoriesAsync()
        {
            var categoriesEntity = await _categoryRepository.GetCategoriesAsync();
            return _mapper.Map<IEnumerable<CategoryDTO>>(categoriesEntity);
        }

        public async Task<CategoryDTO> GetCategoryByIdAsync(int id)
        {
            var categoryEntity = await _categoryRepository.GetCategoryByIdAsync(id);
            return _mapper.Map<CategoryDTO>(categoryEntity);
        }

        public async Task CreateCategoryAsync(CategoryDTO category)
        {
            var categoryEntity = _mapper.Map<Category>(category);
             await _categoryRepository.CreateCategoryAsync(categoryEntity);
        }

        public async Task UpdateCategoryAsync(CategoryDTO category)
        {
            var categoryEntity = _mapper.Map<Category>(category);
            await _categoryRepository.UpdateCategoryAsync(categoryEntity);
        }

        public async Task DeleteCategoryAsync(int? id)
        {
            var categoryEntity = await _categoryRepository.GetCategoryByIdAsync(id);
            await _categoryRepository.DeleteCategoryAsync(categoryEntity);
        }
    }
}
