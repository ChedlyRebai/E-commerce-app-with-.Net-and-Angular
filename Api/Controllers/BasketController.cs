using Core.Entities;
using Core.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    public class BasketController : BaseController
    {
        public BasketController(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }

        [HttpGet("get-basket-item/{id}")]
        public async Task<IActionResult> GetBasketItem(string id)
        {
            var basket = await _unitOfWork.CustomerBasket.GetBasketAsync(id);
            if (basket == null)
            {
                return NotFound(new { message = "Basket not found" });
            }
            return Ok(basket);
        }

        [HttpPost("update-basket")]
        public async Task<IActionResult> UpdateBasket([FromBody] CustomerBasket basket)
        {
           var _basket=await _unitOfWork.CustomerBasket.UpdateCustomerBasketAsync(basket);
            if (_basket == null)
            {
                return BadRequest(new { message = "Failed to update basket" });
            }
            return Ok(_basket);
        }
    }
}
