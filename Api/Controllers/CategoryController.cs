using Api.Helper;
using AutoMapper;
using Core.DTO;
using Core.Entities.Product;
using Core.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    public class CategoryController : BaseController
    {
        public CategoryController(IUnitOfWork unitOfWork,IMapper mapper) : base(unitOfWork,mapper)
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
                    return BadRequest(new ResponseAPI(400));
                }
                else
                {
                    return Ok(categories);
                }
            }
            catch (System.Exception ex)
            {
                return BadRequest(new ResponseAPI(400, ex.Message));
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
                return BadRequest(new ResponseAPI(400, ex.Message));
            }

        }

        [HttpPost("add")]
        public async Task<IActionResult> add(CategoryDTO categoryDTO)
        {
            try
            {
                // Category category = new Category()
                // {
                //     Name = categoryDTO.Name,
                //     Description = categoryDTO.Description,
                // };
                var category =_mapper.Map<Category>(categoryDTO);
                await _unitOfWork.CategoryReppository.AddAsync(category);
                return Ok(category);
            }
            catch (System.Exception ex)
            {

                return BadRequest(new ResponseAPI(400, ex.Message));
            }
        }

        [HttpPut("update")]
        public async Task<IActionResult> update(UpdateCategoryDTO updatecategoryDTO)
        {
            try{
                // var category = new Category()
                // {
                //     Id = categoryDTO.id,
                //     Name = categoryDTO.Name,
                //     Description = categoryDTO.Description,
                // };
                var category= _mapper.Map<Category>(updatecategoryDTO);
                await _unitOfWork.CategoryReppository.UpdateAsync(category);
                return Ok(new { message = "Category updated successfully", category });
            }
            catch (System.Exception)
            {
                return BadRequest(new ResponseAPI(400, "Category not found."));
            }
        }

        [HttpDelete("delete-category/{id}")]
        public async Task<IActionResult> delete(int id){
            try
            {
                await _unitOfWork.CategoryReppository.DeleteAsync(id);
                return Ok(new ResponseAPI(200,"Category deleted successfully."));
            }
            catch (System.Exception ex)
            {
                return BadRequest(new ResponseAPI(400, ex.Message));
            }
        }
    }

}
