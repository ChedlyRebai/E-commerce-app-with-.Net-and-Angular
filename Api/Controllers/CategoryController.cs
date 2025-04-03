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
    }
}
