using Personal_library_web.Data.Interfaces;
using Personal_library_web.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Personal_library_web.Data.Repository
{
    public class CCategoriesInteractor : ICategoriesInteractor
    {
        public IRemoteStorage Storage { get; set; }
        public CCategoriesInteractor(IRemoteStorage storage)
        {
            Storage = storage;
        }
                    

        public IEnumerable<CCategory> AllCategories 
        { 
            get
            {
                return Storage.Categories;
            } 
        }

    }
}
