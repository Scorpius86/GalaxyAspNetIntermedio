using System;
using System.Collections.Generic;

namespace Galaxy.RealTime.EF.Data
{
    public partial class Pagos
    {
        public decimal Idalumno { get; set; }
        public string Ciclo { get; set; }
        public decimal Ncuota { get; set; }
        public decimal Monto { get; set; }
        public DateTime? Fecha { get; set; }
    }
}
