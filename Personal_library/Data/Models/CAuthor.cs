using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Personal_library_web.Data.Models
{
    public class CAuthor
    {
        public Int32 Id { get; set; }
        public String Name { get; set; }         
        public Int32[] BooksIds { get; set; }
        public String WikiPage
        {
            get
            {
                return "https://en.wikipedia.org/wiki/" + Name;
            }
        }
    }
    
}
