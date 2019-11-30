using System.Collections.Generic;
using Galaxy.Taller.Api.Models;

namespace Galaxy.Taller.Api.Data.Repository
{
    public interface IOrderRepository
    {
        OrderDto CreateOrder(OrderCreateDto orderCreate);
        OrderProductDto CreateProductForOrder(OrderProductCreateDto orderProductCreateDto);
        OrderDto DeleteOrder(int orderId);
        OrderProductDto DeleteProductForOrder(int orderProductId);
        OrderDto GetOrder(int orderId);
        List<OrderDto> GetOrders(int userId);
        OrderProductDto GetProductForOrder(int orderProductId);
        List<OrderProductDto> GetProductsForOrder(int orderId);
        OrderDto UpdateOrder(OrderUpdateDto orderUpdate);
        OrderProductDto UpdateProductForOrder(OrderProductUpdateDto orderProductUpdateDto);
    }
}