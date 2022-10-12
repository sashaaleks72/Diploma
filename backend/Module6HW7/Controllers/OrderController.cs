using Microsoft.AspNetCore.Mvc;
using Module6HW7.Exceptions;
using Module6HW7.Interfaces;
using Module6HW7.ResponseModels;
using Module6HW7.ViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Module6HW7.Controllers
{
    [Route("api")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrderService _orderService;

        public OrderController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        [HttpPost("orders")]
        public async Task<IActionResult> MakeAnOrder([FromBody] OrderViewModel orderViewModel)
        {
            bool isOrderAdded = await _orderService.MakeAnOrder(orderViewModel);

            if (!isOrderAdded) return BadRequest("Order hasn't been added");

            return Ok("Order successfully added!");
        }

        [HttpGet("orders")]
        public async Task<IActionResult> GetOrders()
        {
            List<OrderResponse> ordersResponse = null;

            try
            {
                ordersResponse = await _orderService.GetOrders();
            }
            catch (BusinessException ex)
            {
                return BadRequest(ex.Message);
            }

            return Ok(ordersResponse);
        }
    }
}
