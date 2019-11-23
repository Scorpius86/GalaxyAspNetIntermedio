using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Galaxy.RealTime.API.Models
{
    public class BookDto
    {
        public Guid Id { get; set; }
        public Guid AuthorId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
    }
}
