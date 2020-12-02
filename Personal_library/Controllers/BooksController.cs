using Microsoft.AspNetCore.Mvc;
using Personal_library_web.Data.Interfaces;
using Personal_library_web.Data.Models;
using Personal_library_web.Services;
using Personal_library_web.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Personal_library_web.Controllers
{
    public class BooksController: Controller
    {
        private readonly IBooksInteractor _booksInteractor;
        private readonly IAuthorsInteractor _authorsInteractor;
        private readonly ICategoriesInteractor _categoriesInteractor;
        public BooksController(IBooksInteractor iBooks, IAuthorsInteractor iAuthors, ICategoriesInteractor iCategories)
        {
            _authorsInteractor = iAuthors;
            _booksInteractor = iBooks;
            _categoriesInteractor = iCategories;

    }

    public  ViewResult List()
        {
            ViewBag.Title = $"All Books";
            List<BookViewModel> objsList = new List<BookViewModel>();
            IEnumerable<CAuthor> authors = _authorsInteractor.GetAllAuthors();
            foreach (CAuthor author in authors)
            {
                BookViewModel obj = new BookViewModel
                {
                    AllBooksByAuthor =  _booksInteractor.GetBooksByAuthorId(author.Id),
                    Author = author
                };
                objsList.Add(obj);
            }

            return View(objsList);
        }
    }
}
