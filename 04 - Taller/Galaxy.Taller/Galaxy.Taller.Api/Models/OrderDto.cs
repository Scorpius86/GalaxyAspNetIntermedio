using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Galaxy.Taller.Api.Models
{
    public class OrderDto
    {
        public int OrderId { get; set; }
        public string FullUserName { get; set; }
        public string FullClientName { get; set; }
        public Decimal? TotalPrice { get; set; }
        public DateTime OrderDate { get; set; }

    }
}
