using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookList.Model
{
    public class Book_Author
    {
        public int Id { get; set; }
        public Book book { get; set; }
        public int BookId { get; set; }
        public Author author { get; set; }
        public int AuthorId { get; set; }
    }
}
