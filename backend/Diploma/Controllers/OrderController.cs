using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Diploma.Exceptions;
using Diploma.Interfaces;
using Diploma.ViewModels;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Diploma.ResponseModels;

namespace Diploma.Controllers
{
    [Authorize]
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
        public async Task<IActionResult> GetOrders([FromQuery] Guid userId)
        {
            List<OrderResponse> ordersResponse = null;

            try
            {
                ordersResponse = await _orderService.GetOrders(userId);
            }
            catch (BusinessException ex)
            {
                return BadRequest(ex.Message);
            }

            return Ok(ordersResponse);
        }
    }
}
