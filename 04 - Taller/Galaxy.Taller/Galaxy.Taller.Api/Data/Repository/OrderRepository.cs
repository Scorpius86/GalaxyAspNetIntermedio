using Galaxy.Taller.Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Galaxy.Taller.Api.Data.Repository
{
    public class OrderRepository : IOrderRepository
    {
        public GalaxyTallerContext _galaxyTallerContext { get; set; }

        public OrderRepository(GalaxyTallerContext galaxyTallerContext)
        {
            _galaxyTallerContext = galaxyTallerContext;
        }

        private IQueryable<OrderDto> QueryGetOrder(int orderId = 0,int userId=0)
        {
            var query = from o in _galaxyTallerContext.Pedido
                        join op in _galaxyTallerContext.PedidoProducto on o.PedidoId equals op.PedidoId
                            into opJoin
                            from opLeft in opJoin.DefaultIfEmpty()
                        join p in _galaxyTallerContext.Producto on opLeft.ProductoId equals p.ProductoId
                            into pJoin 
                            from pLeft in pJoin.DefaultIfEmpty()
                        select new
                        {
                            OrderId = o.PedidoId,
                            UserId = o.UsuarioId,
                            FullUserName = o.Usuario.Nombre + " " + o.Usuario.ApellidoPaterno + " " + o.Usuario.ApellidoMaterno,
                            FullClientName = o.Cliente.Nombre + " " + o.Cliente.ApellidoPaterno + " " + o.Cliente.ApellidoMaterno,
                            TotalPrice = (opLeft.Cantidad * pLeft.Precio)??0,
                            OrderDate = o.Fecha
                        };

            if (orderId != 0)
            {
                query = query.Where(w => w.OrderId == orderId);
            }
            if (userId != 0)
            {
                query = query.Where(w => w.UserId == userId);
            }

            var queryOrder = from q in query.GroupBy(g => new { g.OrderId, g.FullUserName, g.FullClientName, g.OrderDate })
                     select new OrderDto
                     {
                         OrderId = q.Key.OrderId,
                         FullUserName = q.Key.FullUserName,
                         FullClientName = q.Key.FullClientName,
                         TotalPrice = q.Sum(s=> s.TotalPrice),
                         OrderDate = q.Key.OrderDate
                     };

            return queryOrder;
        }

        private IQueryable<OrderProductDto> QueryGetOrderProduct(int orderId,int orderProductoId=0)
        {
            var query = from op in _galaxyTallerContext.PedidoProducto
                        join o in _galaxyTallerContext.Pedido on op.PedidoId equals o.PedidoId
                        join p in _galaxyTallerContext.Producto on op.ProductoId equals p.ProductoId
                        join b in _galaxyTallerContext.Marca on p.MarcaId equals b.MarcaId
                        select new OrderProductDto
                        {
                            OrderProductId = op.PedidoProductoId,
                            OrderId = op.PedidoId,
                            ProductId = op.ProductoId,
                            Description = p.Descripcion,
                            BrandDescription = p.Marca.Descripcion,
                            Price = p.Precio,
                            Quantity = op.Cantidad,
                            TotalPrice = p.Precio * op.Cantidad,
                            UnitDescription = p.UnidadMedidad
                        };

            if (orderId != 0)
            {
                query = query.Where(w => w.OrderId == orderId);
            }
            if (orderProductoId != 0)
            {
                query = query.Where(w => w.OrderProductId == orderProductoId);
            }

            return query;
        }
        public List<OrderDto> GetOrders(int userId)
        {
            List<OrderDto> result = QueryGetOrder(userId:userId).ToList();

            return result;
        }

        public OrderDto GetOrder(int orderId)
        {
            OrderDto result = QueryGetOrder(orderId).FirstOrDefault();

            return result;
        }
        public OrderDto CreateOrder(OrderCreateDto orderCreate)
        {
            Pedido pedido = new Pedido
            {
                ClienteId = orderCreate.ClientId,
                UsuarioId = orderCreate.UserId,
                Fecha = DateTime.Now
            };

            _galaxyTallerContext.Pedido.Add(pedido);
            _galaxyTallerContext.SaveChanges();

            return GetOrder(pedido.PedidoId);
        }
        public OrderDto UpdateOrder(OrderUpdateDto orderUpdate)
        {
            Pedido pedido = _galaxyTallerContext.Pedido.Where(p => p.PedidoId == orderUpdate.OrderId).FirstOrDefault();
            pedido.UsuarioId = orderUpdate.UserId;
            pedido.ClienteId = orderUpdate.ClientId;

            _galaxyTallerContext.Pedido.Update(pedido);
            _galaxyTallerContext.SaveChanges();

            return GetOrder(pedido.PedidoId);
        }

        public OrderDto DeleteOrder(int orderId)
        {
            Pedido pedido = _galaxyTallerContext.Pedido.Where(p => p.PedidoId == orderId).FirstOrDefault();
            OrderDto orderDto = GetOrder(orderId);

            _galaxyTallerContext.Pedido.Remove(pedido);
            _galaxyTallerContext.SaveChanges();

            return orderDto;
        }

        public List<OrderProductDto> GetProductsForOrder(int orderId)
        {            
            List<OrderProductDto> result = QueryGetOrderProduct(orderId).ToList();
            return result;
        }

        public OrderProductDto GetProductForOrder(int orderProductId)
        {
            OrderProductDto result = QueryGetOrderProduct(0, orderProductId).FirstOrDefault();
            return result;
        }

        public OrderProductDto CreateProductForOrder(OrderProductCreateDto orderProductCreateDto)
        {
            PedidoProducto pedidoProducto = new PedidoProducto
            {
                PedidoId = orderProductCreateDto.OrderId,
                ProductoId = orderProductCreateDto.ProductId,
                Cantidad = orderProductCreateDto.Quantity
            };

            _galaxyTallerContext.PedidoProducto.Add(pedidoProducto);
            _galaxyTallerContext.SaveChanges();

            return GetProductForOrder(pedidoProducto.PedidoProductoId);
        }
        public OrderProductDto UpdateProductForOrder(OrderProductUpdateDto orderProductUpdateDto)
        {            
            PedidoProducto pedidoProducto = _galaxyTallerContext.PedidoProducto.Where(w=> w.PedidoProductoId == orderProductUpdateDto.OrderProductId).FirstOrDefault();
            pedidoProducto.ProductoId = orderProductUpdateDto.ProductId;
            pedidoProducto.Cantidad = orderProductUpdateDto.Quantity;
            _galaxyTallerContext.PedidoProducto.Update(pedidoProducto);
            _galaxyTallerContext.SaveChanges();

            return GetProductForOrder(pedidoProducto.PedidoProductoId);
        }

        public OrderProductDto DeleteProductForOrder(int orderProductId)
        {
            PedidoProducto pedidoProducto = _galaxyTallerContext.PedidoProducto.Where(w => w.PedidoProductoId == orderProductId).FirstOrDefault();
            OrderProductDto orderProductDto = GetProductForOrder(orderProductId);
            _galaxyTallerContext.PedidoProducto.Remove(pedidoProducto);
            _galaxyTallerContext.SaveChanges();

            return orderProductDto;
        }
    }
}
