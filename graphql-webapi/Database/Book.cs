using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace graphql_webapi.Database
{
    public class Book
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Genre { get; set; }
        public bool Published { get; set; }
        public int AuthorId { get; set; }
        public Author Author { get; set; }
    }
}
