using Personal_library_web.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Personal_library_web.Data.Interfaces
{
    public interface IRemoteStorage           
    {
        public IEnumerable<CBook> Books { get;  set; }
        public IEnumerable<CCategory> Categories { get; set; }
        public IEnumerable<CAuthor> Authors { get; set; }
       
        void LoadData();
    }
}
