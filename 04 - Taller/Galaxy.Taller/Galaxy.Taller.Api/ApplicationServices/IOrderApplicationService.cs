using Galaxy.Taller.Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Galaxy.Taller.Api.ApplicationServices
{
    public interface IOrderApplicationService
    {
        OrderDto CreateOrder(OrderCreateDto orderCreate);
        OrderProductDto CreateProductForOrder(int orderId,OrderProductCreateDto orderProductCreateDto);
        OrderDto DeleteOrder(int orderId);
        OrderProductDto DeleteProductForOrder(int orderProductId);
        OrderDto GetOrder(int orderId);
        List<OrderDto> GetOrders(int UserId);
        OrderProductDto GetProductForOrder(int orderProductId);
        List<OrderProductDto> GetProductsForOrder(int orderId);
        OrderDto UpdateOrder(int orderId,OrderUpdateDto orderUpdate);
        OrderProductDto UpdateProductForOrder(int orderProductId, OrderProductUpdateDto orderProductUpdateDto);
    }
}
