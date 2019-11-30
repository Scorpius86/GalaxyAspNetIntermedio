using System;
using System.Collections.Generic;

namespace Galaxy.Taller.Api.Data
{
    public partial class Cliente
    {
        public Cliente()
        {
            Pedido = new HashSet<Pedido>();
        }

        public int ClienteId { get; set; }
        public string Nombre { get; set; }
        public string ApellidoPaterno { get; set; }
        public string ApellidoMaterno { get; set; }
        public int? Edad { get; set; }
        public int? SexoId { get; set; }

        public virtual Sexo Sexo { get; set; }
        public virtual ICollection<Pedido> Pedido { get; set; }
    }
}