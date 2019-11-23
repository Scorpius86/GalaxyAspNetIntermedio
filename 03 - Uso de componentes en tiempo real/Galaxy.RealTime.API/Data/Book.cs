using System;
using System.Collections.Generic;

namespace Galaxy.RealTime.API.Data
{
    public partial class Book
    {
        public Guid Id { get; set; }
        public Guid AuthorId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }

        public virtual Author Author { get; set; }
    }
}