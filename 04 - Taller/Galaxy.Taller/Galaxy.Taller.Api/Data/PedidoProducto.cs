using System;
using System.Collections.Generic;

namespace Galaxy.Taller.Api.Data
{
    public partial class PedidoProducto
    {
        public int PedidoProductoId { get; set; }
        public int PedidoId { get; set; }
        public int ProductoId { get; set; }
        public int Cantidad { get; set; }

        public virtual Pedido Pedido { get; set; }
        public virtual Producto Producto { get; set; }
    }
}