using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Galaxy.Taller.Api.Models
{
    public class OrderUpdateDto
    {
        public int OrderId { get; set; }
        public int UserId { get; set; }
        public int ClientId { get; set; }
    }
}
