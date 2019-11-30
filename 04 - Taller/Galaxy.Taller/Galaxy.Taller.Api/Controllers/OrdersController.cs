using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Galaxy.Taller.Api.ApplicationServices;
using Galaxy.Taller.Api.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Galaxy.Taller.Api.Controllers
{
    [Route("api/orders")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        public IOrderApplicationService _orderApplicationService { get; set; }

        public OrdersController(IOrderApplicationService orderApplicationService)
        {
            _orderApplicationService = orderApplicationService;
        }

        [HttpGet]
        public ActionResult<List<OrderDto>> GetOrders([FromQuery]int userId)
        {
            List<OrderDto> orders = _orderApplicationService.GetOrders(userId);
            return Ok(orders);
        }

        [HttpGet("{orderId}")]
        public ActionResult<OrderDto> GetOrder(int orderId)
        {
            OrderDto orders = _orderApplicationService.GetOrder(orderId);
            return Ok(orders);
        }

        [HttpPost]
        public ActionResult<OrderDto> CreateOrder([FromBody] OrderCreateDto orderCreate)
        {
            OrderDto order = _orderApplicationService.CreateOrder(orderCreate);
            return Ok(order);
        }

        [HttpPut("{orderId}")]
        public ActionResult<OrderDto> UpdateAuthor(int orderId,[FromBody] OrderUpdateDto orderUpdate)
        {
            OrderDto order = _orderApplicationService.UpdateOrder(orderId, orderUpdate);
            return Ok(order);
        }

        [HttpDelete("{orderId}")]
        public ActionResult<OrderDto> DeleteOrder(int orderId)
        {
            OrderDto order = _orderApplicationService.DeleteOrder(orderId);
            return Ok(order);
        }
    }
}