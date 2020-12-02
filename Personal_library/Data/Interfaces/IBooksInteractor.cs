using Personal_library_web.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Personal_library_web.Data.Interfaces
{
    public interface IBooksInteractor : IInteractor
    {
        
        public IEnumerable<CBook> GetAllBooks();
        public CBook GetBookById(Int32 bookId);
        public IEnumerable<CBook> GetBooksByAuthorId(Int32 authorId);
        public IEnumerable<CBook> GetBooksByCategoryId(Int32 categoryId);
      
      
    }
}
