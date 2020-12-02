using NUnit.Framework;
using FluentAssertions;
using Personal_library_web.Data.Mocs;
using Personal_library_web.Data.Models;
using System;
using System.Collections.Generic;

namespace Personal_library_tests
{
    public class TestAuthorInteractor
    {
        private IEnumerable<CAuthor> allAuthors;
        private CMockAuthorsInteractor interactorUnderTest;
        [SetUp]
        public void Setup()
        {
            allAuthors = new List<CAuthor>
                {
                    new CAuthor { Id = 1, Name = "Kent Beck",  BooksIds = new Int32[] {1} },
                    new CAuthor { Id = 2, Name = "Alfred Vaino Aho",  BooksIds = new Int32[] {2, 5 } },
                    new CAuthor { Id = 3, Name = "Monica S. Lam",  BooksIds = new Int32[] {2}},
                    new CAuthor { Id = 4, Name = "Ravi Sethi",  BooksIds = new Int32[] {2}},
                    new CAuthor { Id = 5, Name = "Jeffrey D. Ullman",  BooksIds = new Int32[] {2, 5}},
                    new CAuthor { Id = 6, Name = "Steven S. Skiena",  BooksIds = new Int32[] {3}},
                    new CAuthor { Id = 7, Name = "Christopher J. Date", BooksIds = new Int32[] {4}}
                };
            interactorUnderTest = new CMockAuthorsInteractor();
        }

        [Test]
        public void ShouldGetAllAuthors()
        {
            //Arrange

            //Act 
            var allAuthorsFromMock = interactorUnderTest.GetAllAuthors();

            //Assert
            allAuthorsFromMock.Should().BeEquivalentTo(allAuthors);
        }
        [Test]
        public void ShouldGetAuthorById()
        {
            //Arrange
            CAuthor testAuthor = new CAuthor { Id = 2, Name = "Alfred Vaino Aho", BooksIds = new Int32[] { 2, 5 } };

            //Act
            CAuthor authorFromMock = interactorUnderTest.GetAuthorById(2);

            //Assert
            testAuthor.Should().BeEquivalentTo(authorFromMock);
        }
        [Test]
        public void ShouldGetAuthorsByBook()
        {
            //Arrange
            IEnumerable<CAuthor> testAuthors = new CAuthor[]
            {
                    new CAuthor { Id = 2, Name = "Alfred Vaino Aho",  BooksIds = new Int32[] {2, 5 } },
                    new CAuthor { Id = 3, Name = "Monica S. Lam",  BooksIds = new Int32[] {2}},
                    new CAuthor { Id = 4, Name = "Ravi Sethi",  BooksIds = new Int32[] {2}},
                    new CAuthor { Id = 5, Name = "Jeffrey D. Ullman",  BooksIds = new Int32[] {2, 5}},
            };
            //Act
            IEnumerable<CAuthor> authorsFromMock = interactorUnderTest.GetAuthorsByBook(2);

            //Assert
            testAuthors.Should().BeEquivalentTo(authorsFromMock);
        }
    }
}
