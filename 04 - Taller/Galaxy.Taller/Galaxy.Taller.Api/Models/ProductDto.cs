using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Galaxy.Taller.Api.Models
{
    public class ProductDto
    {
        public int ProductId { get; set; }
        public string BrandDescription { get; set; }
        public string Description { get; set; }
        public decimal? Price { get; set; }
        public string Unit { get; set; }
    }
}
