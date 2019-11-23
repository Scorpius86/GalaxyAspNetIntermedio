using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Galaxy.RealTime.API.Entities.old
{
    public class Author
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public string Genre { get; set; }
        public List<Book> Books { get; set; }
    }
}
