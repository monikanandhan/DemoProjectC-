using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookList.Model
{
    public class Publisher
    {

        public int Id { get; set; }
        public string PublisherName { get; set; }

        public List<Book> booksDemo { get; set; }
    }
}
