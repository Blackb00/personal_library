using Personal_library_web.Data.Interfaces;
using Personal_library_web.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Personal_library_web.Data.Repository
{
    public class CBooksInteractor : IBooksInteractor
    {
        public IRemoteStorage Storage { get; set; }
        public CBooksInteractor(IRemoteStorage storage)
        {
            Storage = storage;

        }
        public  IEnumerable<CBook> GetAllBooks()
        {
            return Storage.Books;
        }

        public CBook GetBookById(Int32 bookId)
        {
            return Storage.Books.Where(x=>x.Id==bookId).FirstOrDefault();
        }

        public IEnumerable<CBook> GetBooksByAuthorId(Int32 authorId)
        {
            return Storage.Books.Where(x => x.AuthorsIds.Contains(authorId));
        }

        public IEnumerable<CBook> GetBooksByCategoryId(Int32 categoryId)
        {
            return Storage.Books.Where(x => x.CategoryId == categoryId);
        }

    }
}
