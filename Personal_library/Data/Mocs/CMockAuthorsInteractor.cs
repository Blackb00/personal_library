using Personal_library_web.Data.Interfaces;
using Personal_library_web.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Personal_library_web.Data.Mocs
{
    public class CMockAuthorsInteractor : IAuthorsInteractor
    {
        public IRemoteStorage Storage { get; set; }

        public IEnumerable<CAuthor> GetAllAuthors() 
        {     return new List<CAuthor>
                {
                    new CAuthor { Id = 1, Name = "Kent Beck",  BooksIds = new Int32[] {1} },
                    new CAuthor { Id = 2, Name = "Alfred Vaino Aho",  BooksIds = new Int32[] {2, 5 } },
                    new CAuthor { Id = 3, Name = "Monica S. Lam",  BooksIds = new Int32[] {2}},
                    new CAuthor { Id = 4, Name = "Ravi Sethi",  BooksIds = new Int32[] {2}},
                    new CAuthor { Id = 5, Name = "Jeffrey D. Ullman",  BooksIds = new Int32[] {2, 5}},
                    new CAuthor { Id = 6, Name = "Steven S. Skiena",  BooksIds = new Int32[] {3}},
                    new CAuthor { Id = 7, Name = "Christopher J. Date", BooksIds = new Int32[] {4}}
                };
        }

        public CAuthor GetAuthorById(Int32 authorId)
        {
            return GetAllAuthors().Where(y => y.Id == authorId).FirstOrDefault();
        }

        public IEnumerable<CAuthor> GetAuthorsByBook(int bookId)
        {
            return GetAllAuthors().Where(x => x.BooksIds.Contains(bookId));
        }
    }
}
