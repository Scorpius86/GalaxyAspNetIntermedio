using System;
using System.Collections.Generic;

namespace Galaxy.RealTime.API.Data
{
    public partial class Author
    {
        public Author()
        {
            Books = new HashSet<Book>();
        }

        public Guid Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public string Genre { get; set; }

        public virtual ICollection<Book> Books { get; set; }
    }
}