using NUnit.Framework;
using FluentAssertions;
using Personal_library_web.Data.Mocs;
using Personal_library_web.Data.Models;
using System;
using System.Collections.Generic;

namespace Personal_library_tests
{
    public class TestBookInteractor
    {
        private IEnumerable<CBook> allBooks;
        private CMockBooksInteractor interactorUnderTest;
       [SetUp]
        public void Setup()
        {
            allBooks = new List<CBook>
                {
                    new CBook { Id = 1, Name = "Test-Driven Development by Example", AuthorsIds = new Int32[] {1} },
                    new CBook { Id = 2, Name = "Compilers: Principles, Techniques, and Tools", AuthorsIds = new Int32[] {2,3,4,5}},
                    new CBook { Id = 3, Name="The Algorithm Design Manual (2nd ed.)", AuthorsIds = new Int32[] {6}},
                    new CBook { Id = 4, Name="An Introduction to Database Systems", AuthorsIds = new Int32[] {7} },
                    new CBook { Id = 5, Name = "Foundations of Computer Science", AuthorsIds = new int[] {2,5} }
                };
            interactorUnderTest = new CMockBooksInteractor();

        }

        [Test]
        public void ShouldGetAllBooks()
        {
            //Arrange
            
            //Act 
            var allBooksFromMock = interactorUnderTest.GetAllBooks();

            //Assert
            allBooksFromMock.Should().BeEquivalentTo(allBooks);
        }
        [Test]
        public void ShouldGetBookById()
        {
            //Arrange
            CBook testBook = new CBook { Id = 1, Name = "Test-Driven Development by Example", AuthorsIds = new Int32[] { 1 } };

            //Act
            CBook bookFromMock = interactorUnderTest.GetBookById(1);

            //Assert
            testBook.Should().BeEquivalentTo(bookFromMock);
        }
        [Test]
        public void ShouldGetBooksByAuthor()
        {
            //Arrange
            IEnumerable<CBook> testBooks = new CBook[]
            { new CBook { Id = 2, Name = "Compilers: Principles, Techniques, and Tools", AuthorsIds = new Int32[] { 2, 3, 4, 5 } },
              new CBook { Id = 5, Name = "Foundations of Computer Science", AuthorsIds = new int[] {2,5} }
            };
            //Act
            IEnumerable<CBook> booksFromMock = interactorUnderTest.GetBooksByAuthorId(2);

            //Assert
            testBooks.Should().BeEquivalentTo(booksFromMock);
        }
        [Test]
        public void ShouldGetAuthorsNamesByBookId()
        {
            //Arrange
            String[] testAuthorsNames = new String[] { "Alfred Vaino Aho", "Monica S. Lam", "Ravi Sethi", "Jeffrey D. Ullman" };
            CMockAuthorsInteractor authors = new CMockAuthorsInteractor();
            //Act
            IEnumerable<String> authorNamesFromMock = interactorUnderTest.GetAuthorsNamesByBookId(2, authors);
            //Assert
            testAuthorsNames.Should().BeEquivalentTo(authorNamesFromMock);
        }
    }
}
