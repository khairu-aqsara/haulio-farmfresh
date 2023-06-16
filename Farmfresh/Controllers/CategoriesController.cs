using AutoMapper;
using Farmfresh.Models;
using Farmfresh.Services.Categories;
using Microsoft.AspNetCore.Mvc;

namespace Farmfresh.Controllers
{
    [Route("api/categories")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly ICategoryService _categoryService;
        private IMapper _mapper;

        public CategoriesController(ICategoryService categoryService, IMapper mapper)
        {
            _categoryService = categoryService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetCategories()
        {
            var result = await _categoryService.GetAll();
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> AddCategory(CategoryDto category)
        {
            var entity = _mapper.Map<Category>(category);  
            var result = await _categoryService.AddCategory(entity);
            if (result == null)
                return BadRequest();
            return Ok(result);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateCategory(int id, CategoryDto category)
        {
            var entity = _mapper.Map<Category>(category);
            var result = await _categoryService.UpdateCategory(id, entity);
            if (result == null)
                return BadRequest();
            return Ok(result);
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteCategory(int id)
        {
            var deleted = await _categoryService.DeleteCategory(id);
            return Ok(deleted);
        }
    }
}
