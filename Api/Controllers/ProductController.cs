using Api.Helper;
using AutoMapper;
using Core.DTO;
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
                var results = _mapper.Map<List<ProductDTO>>(products);

                if (results is null)
                {
                    return BadRequest(new ResponseAPI(400));
                }

                else{
                    return Ok(results);
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
                var product = await _unitOfWork.ProductRepository.GetByIdAsync(id,x=>x.Category,x=>x.Photos);
                var result = _mapper.Map<ProductDTO>(product);
                if(result is null){
                    return BadRequest(new ResponseAPI(400, $"Product with id {id} not found."));
                }
                return Ok(result);
            }
            catch (System.Exception ex)
            {
        
                return BadRequest(new ResponseAPI(400,ex.Message));
            }
        }

        [HttpPost("Add-Product")]
        public async Task<IActionResult> AddProduct([FromBody] ProductDTO productDTO){
            try
            {

            }
            catch (System.Exception ex)
            {
                return BadRequest(new ResponseAPI(400, ex.Message));
            }
        }
    }
}
