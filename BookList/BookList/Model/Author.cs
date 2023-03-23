using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookList.Model
{
    public class Author
    {
        public int Id { get; set; }
        public string AuthorName { get; set; }

        public List<Book_Author> book_author { get; set; }
    }
}
