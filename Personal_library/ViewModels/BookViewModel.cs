using Personal_library_web.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Personal_library_web.ViewModels
{
    public class BookViewModel
    {
        public IEnumerable<CBook> AllBooksByAuthor{get; set;}
        public CAuthor Author { get; set; }
    }
}
