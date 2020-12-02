using Personal_library_web.Data.Interfaces;
using Personal_library_web.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Personal_library_web.Data.Mocs
{
    public class CMockCategoriesInteractor:ICategoriesInteractor
    {
        public IEnumerable<CCategory> AllCategories {
            get
            {
                return new List<CCategory> { new CCategory { Name = "Programming" },
                new CCategory {Name = "Science Fiction"},
                new CCategory { Name = "Documentary"} };
            }
        }

        public IRemoteStorage Storage { get; set; }
    }
}
