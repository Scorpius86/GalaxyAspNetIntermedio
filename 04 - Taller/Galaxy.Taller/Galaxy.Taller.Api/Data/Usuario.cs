using System;
using System.Collections.Generic;

namespace Galaxy.Taller.Api.Data
{
    public partial class Usuario
    {
        public Usuario()
        {
            Pedido = new HashSet<Pedido>();
        }

        public int UsuarioId { get; set; }
        public string NombreUsuario { get; set; }
        public string Clave { get; set; }
        public string Nombre { get; set; }
        public string ApellidoPaterno { get; set; }
        public string ApellidoMaterno { get; set; }
        public int? Edad { get; set; }
        public int? SexoId { get; set; }

        public virtual Sexo Sexo { get; set; }
        public virtual ICollection<Pedido> Pedido { get; set; }
    }
}