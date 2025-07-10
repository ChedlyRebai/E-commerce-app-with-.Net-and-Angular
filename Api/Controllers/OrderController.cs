using System.Security.Claims;
using Api.Helper;
using Core.DTO;
using Core.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
  //  [Authorize]
    public class OrderController : ControllerBase
    {
        private readonly IOrderService _orderService;
        public OrderController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        [HttpPost("create-order")]
        public async Task<IActionResult> create(OrderDTO orderDTO)
        {

            var buyerEmail = User.FindFirst(ClaimTypes.Email)?.Value;
            var order =await _orderService.CreateOrdersAsync(orderDTO, "chedly.rebai123@gmail.com");
            
            return Ok(new ResponseAPI(200, "Order created successfully"));
        }
    }
}
