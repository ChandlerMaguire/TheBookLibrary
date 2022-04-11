using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Capstone.Models
{
    public class Book
    {
        public string Title { get; set; }
        public int AuthorId { get; set; }
        public int Isbn { get; set; }
        public int BookId { get; set; } 
        public int GenreId { get; set; } 
        public DateTime DateAdded { get; set; }

    }
}
