using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Galaxy.Taller.Api.Models
{
    public class OrderCreateDto
    {
        public int UserId { get; set; }
        public int ClientId { get; set; }
    }
}
