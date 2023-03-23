using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookList.Model.ModelView
{
    public class AuthorVM
    {
        public string AuthorName { get; set; }
    }
    public class AuthorWithBook
    {
        public string AuthorName { get; set; }
        public List<string> BookName { get; set; }
    }
}
