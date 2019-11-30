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
    [Route("api/orders/{orderId}/products")]
    [ApiController]
    public class OrderProductsController : ControllerBase
    {
        public IOrderApplicationService _orderApplicationService { get; set; }

        public OrderProductsController(IOrderApplicationService orderApplicationService)
        {
            _orderApplicationService = orderApplicationService;
        }

        [HttpGet]
        public ActionResult<List<OrderProductDto>> GetProductsForOrder(int orderId)
        {
            List<OrderProductDto> orderProducts = _orderApplicationService.GetProductsForOrder(orderId);
            return Ok(orderProducts);
        }

        [HttpGet("{orderProductId}")]
        public ActionResult<OrderProductDto> GetProductForOrder(int orderProductId)
        {
            OrderProductDto orderProduct = _orderApplicationService.GetProductForOrder(orderProductId);
            return Ok(orderProduct);
        }

        [HttpPost]
        public ActionResult<OrderProductDto> CreateProductForOrder(int orderId,[FromBody] OrderProductCreateDto orderProductCreate)
        {
            OrderProductDto orderProduct = _orderApplicationService.CreateProductForOrder(orderId, orderProductCreate);
            return Ok(orderProduct);
        }

        [HttpPut("{orderProductId}")]
        public ActionResult<OrderProductDto> UpdateProductForOrder(int orderProductId, [FromBody] OrderProductUpdateDto orderProductUpdateDto)
        {
            OrderProductDto orderProduct = _orderApplicationService.UpdateProductForOrder(orderProductId, orderProductUpdateDto);
            return Ok(orderProduct);
        }

        [HttpDelete("{orderProductId}")]
        public ActionResult<OrderProductDto> DeleteProductForOrder(int orderProductId)
        {
            OrderProductDto orderProductDto = _orderApplicationService.DeleteProductForOrder(orderProductId);
            return Ok(orderProductDto);
        }
    }
}