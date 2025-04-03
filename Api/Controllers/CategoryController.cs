using Core.DTO;
using Core.Entities.Product;
using Core.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    public class CategoryController : BaseController
    {
        public CategoryController(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }

        [HttpGet("get-all")]
        public async Task<IActionResult> getall()
        {
            try
            {
                var categories = await _unitOfWork.CategoryReppository.GetAllAsync();
                if (categories is null)
                {
                    return NotFound("No categories found.");
                }
                else
                {
                    return Ok(categories);
                }
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpGet("get-by-id/{id}")]
        public async Task<IActionResult> getById(int id)
        {
            try
            {
                var category = await _unitOfWork.CategoryReppository.GetByIdAsync(id);
                if (category is null)
                {
                    return NotFound($"Category with id {id} not found.");
                }
                else
                {
                    return Ok(category);
                }
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }
        [HttpPost("add")]
        public async Task<IActionResult> add(CategoryDTO categoryDTO)
        {
            try
            {
                Category category = new Category()
                {
                    Name = categoryDTO.Name,
                    Description = categoryDTO.Description,

                };
                await _unitOfWork.CategoryReppository.AddAsync(category);
                return Ok(category);
            }
            catch (System.Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }
        [HttpPut("update")]
        public async Task<IActionResult> update(UpdateCategoryDTO categoryDTO)
        {
            try
            {
                var category = new Category()
                {
                    Id = categoryDTO.id,
                    Name = categoryDTO.Name,
                    Description = categoryDTO.Description,
                };

                await _unitOfWork.CategoryReppository.UpdateAsync(category);
                return Ok(new { message = "Category updated successfully", category });
            }
            catch (System.Exception)
            {
                return BadRequest("Error updating category.");
            }
        }
        [HttpDelete("delete-category/{id}")]
        public async Task<IActionResult> delete(int id){
            try
            {
                await _unitOfWork.CategoryReppository.DeleteAsync(id);
                return Ok(new { message = "Category deleted successfully" });
            }
            catch (System.Exception)
            {
                return BadRequest("Error deleting category.");
            }
        }
    }

}
