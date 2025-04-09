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
        public async Task<IActionResult> getAll(string sort){
            try
            {
                var products = await _unitOfWork.ProductRepository.GetAllAsync();
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
                var product = await _unitOfWork.ProductRepository.GetByIdAsync(id,x=>x.Category
                ,x=>x.Photos
                );
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
        public async Task<IActionResult> Add(AddProductDTo addproductDTO){
            try
            {
                await _unitOfWork.ProductRepository.AddAsync(addproductDTO);
                return Ok(new ResponseAPI(201, "Product added successfully."));
            }
            catch (System.Exception ex)
            {
                return BadRequest(new ResponseAPI(400, ex.Message));
            }
        }
        
        [HttpPut("update-product")]
        public async Task<IActionResult> UpdateProduct(UpdateProductDTO updateProductDto){
            try
            {
                await _unitOfWork.ProductRepository.UpdateAsync(updateProductDto);
                return Ok(new ResponseAPI(200, "Product updated successfully."));
                
            }
            catch (System.Exception ex)
            {   
                return BadRequest(new ResponseAPI(400,ex.Message));
            }
        }
        [HttpDelete("Delete-product")]
        public async Task<IActionResult> delete(int Id){
            try
            {
                var product=await _unitOfWork.ProductRepository.GetByIdAsync(Id,x=>x.Category,x=>x.Photos);

                await _unitOfWork.ProductRepository.DeleteAsync(product.Id);
                return Ok(new ResponseAPI(200,"Product deleted successfully."));
            }
            catch (System.Exception)
            {
                
                throw;
            }
        }
    }
}
