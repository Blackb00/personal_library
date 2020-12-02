using Dropbox.Api;
using Personal_library_web.Data.Interfaces;
using Personal_library_web.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Configuration;

namespace Personal_library_web.Services.DropBox
{
    public class CDropBox : IRemoteStorage       //singletone
    {
        private static CDropBox instance;
        private static object syncRoot = new Object();


        private String token = ConfigurationManager.AppSettings["dropBoxToken"];

        private String authorNamePattern = "(?<=\\[).+?(?=\\])";
        public IEnumerable<CBook> Books { get; set; }
        public IEnumerable<CCategory> Categories { get; set; }
        public IEnumerable<CAuthor> Authors { get; set; }
        public static CDropBox getInstance()
        {
            if (instance == null)
            {
                lock (syncRoot)
                {
                    if (instance == null)
                    {
                        instance = new CDropBox();
                    }
                }
            }
            return instance;
        }
        public async Task<IEnumerable<CBook>> GetBooksFromFolder(string folderName)
        {
            List<CBook> result = new List<CBook>();
            try
            {                
                using (var dbx = new DropboxClient(token))
                {
                    var listOfFolders = await dbx.Files.ListFolderAsync(String.Empty);

                    foreach (var folder in listOfFolders.Entries.Where(i => i.IsFolder && i.Name == folderName))
                    {
                        String path = folder.PathLower;
                        var listOfFiles = await dbx.Files.ListFolderAsync(path);
                        foreach (var item in listOfFiles.Entries.Where(i => i.IsFile))
                        {
                            result.Add(new CBook
                            {
                                Name = item.Name,
                                FileId = item.PathDisplay

                            });
                        }

                    }
                }
                
            }
            catch(Exception ex)
            {
                Console.WriteLine("Error "+ex.Message);             //todo: NLog
            }
            return result;
        }
        private async Task<IEnumerable<String>> GetFoldersNames()
        {
            List<String> result = new List<string>();
            try
            {
                using (var dbx = new DropboxClient(token))
                {
                    var list = await dbx.Files.ListFolderAsync(String.Empty);
                    foreach (var item in list.Entries.Where(i => i.IsFolder))
                    {
                        result.Add(item.Name);
                    }
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine("Error " + ex.Message);             //todo: NLog
            }
           
            return result;
        }
        public async void LoadData()
        {
            try
            {
                Int32 countCategory = 0;
                Int32 countBook = 0;
                Int32 countAuthor = 0;
                IEnumerable<String> categotiesNames = await this.GetFoldersNames();

                List<CCategory> _categories = new List<CCategory>();
                List<CBook> _books = new List<CBook>();
                List<CAuthor> _authors = new List<CAuthor>();

                foreach (String cat in categotiesNames)
                {
                    CCategory currentCategory = new CCategory { Id = ++countCategory, Name = cat, Books = new List<CBook>() };
                    IEnumerable<CBook> booksByCategory = await this.GetBooksFromFolder(cat);


                    foreach (CBook book in booksByCategory)
                    {
                        List<Int32> currentBookAuthorsIds = new List<Int32>();
                        MatchCollection matches = Regex.Matches(book.Name, authorNamePattern);
                        foreach (Match match in matches)
                        {
                            if (_authors.Where(x => x.Name == match.Value).Count() == 0)
                            {
                                _authors.Add(new CAuthor { Name = match.Value, Id = ++countAuthor });
                                currentBookAuthorsIds.Add(countAuthor);
                            }
                            else
                            {
                                currentBookAuthorsIds.Add(_authors.Where(x => x.Name == match.Value).FirstOrDefault().Id);
                            }
                        }
                        book.Name = book.Name.Substring(book.Name.IndexOf(']') + 2);
                        book.Id = ++countBook;
                        book.CategoryId = countCategory;
                        book.AuthorsIds = currentBookAuthorsIds.ToArray();
                        _books.Add(book);
                        currentCategory.Books.Add(book);
                    }
                    _categories.Add(currentCategory);

                }
                this.Books = _books;
                this.Categories = _categories;
                this.Authors = _authors;

            }
            catch(Exception ex)
            {
                Console.WriteLine("Error " + ex.Message);             //todo: NLog
            }

        }
    }
}