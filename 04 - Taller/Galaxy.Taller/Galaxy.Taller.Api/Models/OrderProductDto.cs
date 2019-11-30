using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Galaxy.Taller.Api.Models
{
    public class OrderProductDto
    {
        public int OrderProductId { get; set; }
        public int OrderId { get; set; }
        public int ProductId { get; set; }
        public int Quantity { get; set; }
        public string Description { get; set; }
        public string BrandDescription { get; set; }
        public Decimal? Price { get; set; }
        public Decimal? TotalPrice { get; set; }
        public string UnitDescription { get; set; }
    }
}
