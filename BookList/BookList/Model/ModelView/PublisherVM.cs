using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookList.Model.ModelView
{
    public class PublisherVM
    {
        public string PublisherName { get; set; }
    }

    public class PublisherWithBook
    {
        public string PublisherName { get; set; }
        public List<BookWithAuthor> bookWithAuthors { get; set; }
    }

    public class BookWithAuthor
    {
        public string BookName { get; set; }
        public List<string> AuthorName { get; set; }
    }
}
