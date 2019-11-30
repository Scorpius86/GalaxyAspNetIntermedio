using System;
using System.Collections.Generic;

namespace Galaxy.Taller.Api.Data
{
    public partial class Pedido
    {
        public Pedido()
        {
            PedidoProducto = new HashSet<PedidoProducto>();
        }

        public int PedidoId { get; set; }
        public int UsuarioId { get; set; }
        public int ClienteId { get; set; }
        public DateTime Fecha { get; set; }

        public virtual Cliente Cliente { get; set; }
        public virtual Usuario Usuario { get; set; }
        public virtual ICollection<PedidoProducto> PedidoProducto { get; set; }
    }
}