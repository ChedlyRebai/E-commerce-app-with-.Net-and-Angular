using Api.Helper;
using AutoMapper;
using Core.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers.Mapping
{
    public class ProductController : BaseController
    {
        public ProductController(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper)
        {
        }
        [HttpGet("get-all")]
        public async Task<IActionResult> getAll(){
            try
            {
                var products = await _unitOfWork.ProductRepository.GetAllAsync(
                    x=>x.Category,
                    x=>x.Photos
                );

                if (products is null)
                {
                    return BadRequest(new ResponseAPI(400));
                }

                else{
                    return Ok(products);
                }
            }
            catch (System.Exception ex)
            {
                return BadRequest(new ResponseAPI(400, ex.Message));
            }
        }
        [HttpGet("get-by-id/{id}")]
        public async Task<IActionResult> getById(int id){
            try
            {
                var product = await _unitOfWork.ProductRepository.GetByIdAsync(id);
                if(product is null){
                    return BadRequest(new ResponseAPI(400, $"Product with id {id} not found."));
                }
                return Ok(product);
            }
            catch (System.Exception ex)
            {
        
                return BadRequest(new ResponseAPI(400,ex.Message));
            }
        }
    }
}
