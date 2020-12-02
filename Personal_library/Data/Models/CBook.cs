using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Personal_library_web.Data.Models
{
    public class CBook
    {
        public Int32 Id { get; set; }
        public Int32[] AuthorsIds { get; set; }
        public Int32 CategoryId { get; set; }
        public String Name { get; set; }   
        public String FileId { get; set; }
        
    }
}
