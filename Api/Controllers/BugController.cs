using AutoMapper;
using Core.DTO;
using Core.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{

    public class BugController : BaseController
    {
        public BugController(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper)
        {
            
        }

        [HttpGet("not-found")]
        public async Task<IActionResult> GetNotFound(){
            var category = await _unitOfWork.CategoryReppository.GetByIdAsync(42);
            if(category == null)
            {
                return NotFound(new { message = "Category not found" });
            }
            return Ok(category);
        }
        [HttpGet("server-error")]
        public async Task<IActionResult> GetServerError(){
            var category = await _unitOfWork.CategoryReppository.GetByIdAsync(42);
            var categoryToReturn = _mapper.Map<CategoryDTO>(category);
            return Ok(categoryToReturn);
        }
        [HttpGet("bad-request/{id}")]
        public IActionResult GetBadRequest(int id){
            return Ok();
        }


        [HttpGet("bad-request")]
        public IActionResult GetBadRequest(){
            return BadRequest();
        }



    }
}
