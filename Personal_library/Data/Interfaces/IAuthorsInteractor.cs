using Personal_library_web.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Personal_library_web.Data.Interfaces
{
    public interface IAuthorsInteractor: IInteractor
    {
        IEnumerable<CAuthor> GetAllAuthors();
        IEnumerable<CAuthor> GetAuthorsByBook(Int32 bookId);
        CAuthor GetAuthorById(Int32 authorId);
    }
}
