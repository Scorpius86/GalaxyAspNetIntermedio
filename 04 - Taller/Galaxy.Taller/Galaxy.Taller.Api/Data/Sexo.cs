using System;
using System.Collections.Generic;

namespace Galaxy.Taller.Api.Data
{
    public partial class Sexo
    {
        public Sexo()
        {
            Cliente = new HashSet<Cliente>();
            Usuario = new HashSet<Usuario>();
        }

        public int SexoId { get; set; }
        public string Descripcion { get; set; }

        public virtual ICollection<Cliente> Cliente { get; set; }
        public virtual ICollection<Usuario> Usuario { get; set; }
    }
}