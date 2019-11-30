using System;
using System.Collections.Generic;

namespace Galaxy.Taller.Api.Data
{
    public partial class Producto
    {
        public Producto()
        {
            PedidoProducto = new HashSet<PedidoProducto>();
        }

        public int ProductoId { get; set; }
        public int MarcaId { get; set; }
        public string Descripcion { get; set; }
        public decimal? Precio { get; set; }
        public string UnidadMedidad { get; set; }

        public virtual Marca Marca { get; set; }
        public virtual ICollection<PedidoProducto> PedidoProducto { get; set; }
    }
}