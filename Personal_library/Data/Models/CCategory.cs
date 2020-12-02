using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Personal_library_web.Data.Models
{
    public class CCategory
    {
        public Int32 Id { get; set; }
        public String Name { get; set; }
        public List<CBook> Books { get; set; }
    }
}
