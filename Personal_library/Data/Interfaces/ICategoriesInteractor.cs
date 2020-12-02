using Personal_library_web.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Personal_library_web.Data.Interfaces
{
    public interface ICategoriesInteractor: IInteractor
    {
        IEnumerable <CCategory> AllCategories { get; }
    }
}
