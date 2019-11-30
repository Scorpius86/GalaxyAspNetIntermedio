using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Galaxy.Taller.Api.Models
{
    public class ClientDto
    {
        public int ClientId { get; set; }
        public string Name { get; set; }
        public string FullName { get; set; }
        public string LastName { get; set; }
        public string SurName { get; set; }
        public int? Age { get; set; }
        public string SexDescription { get; set; }
    }
}
