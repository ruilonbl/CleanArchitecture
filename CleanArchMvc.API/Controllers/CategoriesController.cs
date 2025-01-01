using CleanArchMvc.Application.DTOs;
using CleanArchMvc.Application.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CleanArchMvc.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly ICategoryService _categoryService;

        public CategoriesController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<CategoryDTO>>> Get()
        {
            var categories = await _categoryService.GetCategoriesAsync();

            if(categories == null)
                return NotFound("Categories not found");

            return Ok(categories);
        }

        [HttpGet("{id:int}", Name = "GetCategory")]
        public async Task<ActionResult<CategoryDTO>> Get(int id)
        {
            var category = await _categoryService.GetCategoryByIdAsync(id);

            if (category == null)
                return NotFound("Category not found");

            return Ok(category);
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] CategoryDTO categoryDTO)
        {
            if (categoryDTO == null || !ModelState.IsValid)
                return BadRequest("Invalid Data");

            await _categoryService.CreateCategoryAsync(categoryDTO);

            return new CreatedAtRouteResult("GetCategory", new { id = categoryDTO.Id }, categoryDTO);
        }

        [HttpPut]
        public async Task<ActionResult> Put([FromBody] CategoryDTO categoryDTO)
        {
            if(categoryDTO == null || !ModelState.IsValid)
                return BadRequest();

            await _categoryService.UpdateCategoryAsync(categoryDTO);

            return Ok(categoryDTO);
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Delete(int id)
        {
            var category = await _categoryService.GetCategoryByIdAsync(id);

            if(category == null)
                return NotFound("Category not found");

            await _categoryService.DeleteCategoryAsync(category.Id);

            return Ok(category);
        }
    }
}
