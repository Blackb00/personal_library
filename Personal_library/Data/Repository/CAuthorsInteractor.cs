using Personal_library_web.Data.Interfaces;
using Personal_library_web.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Personal_library_web.Data.Repository
{
    public class CAuthorsInteractor : IAuthorsInteractor
    {
        public IRemoteStorage Storage { get; set; }

        public CAuthorsInteractor(IRemoteStorage storage)
        {
            Storage = storage;
        }


        public IEnumerable<CAuthor> GetAllAuthors()
        {
            return Storage.Authors;
        }

        public CAuthor GetAuthorById(int authorId)
        {
            return Storage.Authors.Where(x=>x.Id==authorId).FirstOrDefault();
        }

        public IEnumerable<CAuthor> GetAuthorsByBook(int bookId)
        {
            Int32[] authorsIds = Storage.Books.Where(x => x.Id == bookId).FirstOrDefault().AuthorsIds;
            IEnumerable<CAuthor> authors = Storage.Authors.Where(x => authorsIds.Contains(x.Id));
            return authors;
        }
    }
}
