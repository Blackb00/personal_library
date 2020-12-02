using Personal_library_web.Data.Interfaces;
using Personal_library_web.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Personal_library_web.Data.Mocs
{
    public class CMockBooksInteractor : IBooksInteractor
    {
        public IRemoteStorage Storage { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public IEnumerable<CBook> GetAllBooks() { 
            
                return new List<CBook>
                {
                    new CBook { Id = 1, Name = "Test-Driven Development by Example", AuthorsIds = new Int32[] {1} },
                    new CBook { Id = 2, Name = "Compilers: Principles, Techniques, and Tools", AuthorsIds = new Int32[] {2,3,4,5}},
                    new CBook { Id = 3, Name="The Algorithm Design Manual (2nd ed.)", AuthorsIds = new Int32[] {6}},
                    new CBook { Id = 4, Name="An Introduction to Database Systems", AuthorsIds = new Int32[] {7} },
                    new CBook { Id = 5, Name = "Foundations of Computer Science", AuthorsIds = new int[] {2,5} }
                };
        }

        public IEnumerable<String> GetAuthorsNamesByBookId(Int32 bookId, IAuthorsInteractor authors)
        {
            var authorIds = GetBookById(bookId).AuthorsIds;
            List<String> authorsNames = new List<String>();
            foreach (Int32 id in authorIds)
                authorsNames.Add(authors.GetAuthorById(id).Name);
            return authorsNames;
        }

        public CBook GetBookById(Int32 bookId)
        {
            return GetAllBooks().Where(x => x.Id == bookId).FirstOrDefault();
        }

        public IEnumerable<CBook> GetBooksByAuthorId(Int32 authorId)
        {
            return GetAllBooks().Where(x=>x.AuthorsIds.Contains(authorId));
        }

        public IEnumerable<CBook> GetBooksByCategoryId(Int32 categoryId)
        {
            return GetAllBooks().Where(x => x.CategoryId.Equals(categoryId));
        }
      
    }
}
