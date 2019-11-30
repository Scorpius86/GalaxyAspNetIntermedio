using Galaxy.Taller.Api.Data;
using Galaxy.Taller.Api.Data.Repository;
using Galaxy.Taller.Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Galaxy.Taller.Api.ApplicationServices
{
    public class OrderApplicationService : IOrderApplicationService
    {
        public IOrderRepository _orderRepository { get; set; }
        public OrderApplicationService(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }
        public OrderDto CreateOrder(OrderCreateDto orderCreate)
        {
            return _orderRepository.CreateOrder(orderCreate);
        }

        public List<OrderDto> GetOrders(int userId)
        {
            return _orderRepository.GetOrders(userId);
        }

        public OrderDto GetOrder(int orderId)
        {
            return _orderRepository.GetOrder(orderId);
        }

        public List<OrderProductDto> GetProductsForOrder(int orderId)
        {
            return _orderRepository.GetProductsForOrder(orderId);
        }

        public OrderDto UpdateOrder(int orderId,OrderUpdateDto orderUpdate)
        {
            orderUpdate.OrderId = orderId;
            return _orderRepository.UpdateOrder(orderUpdate);
        }

        public OrderDto DeleteOrder(int orderId)
        {
            return _orderRepository.DeleteOrder(orderId);
        }

        public OrderProductDto CreateProductForOrder(int orderId, OrderProductCreateDto orderProductCreateDto)
        {
            orderProductCreateDto.OrderId = orderId;
            return _orderRepository.CreateProductForOrder(orderProductCreateDto);
        }

        public OrderProductDto DeleteProductForOrder(int orderProductId)
        {
            return _orderRepository.DeleteProductForOrder(orderProductId);
        }

        public OrderProductDto UpdateProductForOrder(int orderProductId,OrderProductUpdateDto orderProductUpdateDto)
        {
            orderProductUpdateDto.OrderProductId = orderProductId;
            return _orderRepository.UpdateProductForOrder(orderProductUpdateDto);
        }

        public OrderProductDto GetProductForOrder(int orderProductId)
        {
            return _orderRepository.GetProductForOrder(orderProductId);
        }
    }
}
