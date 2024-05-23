using ApiLibrary.Models;
using ApiLibrary.Services;
using AutoMapper;
using BaseLibrary.DTO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Policy = "Admin")]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _categoryService;
        private readonly IMapper _mapper;

        public CategoryController(ICategoryService categoryService, IMapper mapper)
        {
            _categoryService = categoryService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetCategories()
        {
            try
            {
                List<Category> categories = await _categoryService.GetAllCategories();
                return Ok(categories);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCategory(int id)
        {
            if (id <= 0)
            {
                return BadRequest("Invalid id");
            }
            try
            {
                Category category = await _categoryService.GetCategoryById(id);
                return Ok(category);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> CreateCategory([FromBody] ICategoryDTO categoryDTO)
        {
            if (!ModelState.IsValid || categoryDTO == null)
            {
                return BadRequest("Invalid category data");
            }
            try
            {
                Category category = _mapper.Map<Category>(categoryDTO);
                Category response = await _categoryService.CreateCategory(category);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCategory(int id, [FromBody] ICategoryDTO categoryDTO)
        {
            try
            {
                Category category = _mapper.Map<Category>(categoryDTO);
                Category response = await _categoryService.UpdateCategory(id, category);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCategory(int id)
        {
            try
            {
                string response = await _categoryService.DeleteCategory(id);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
