using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Mission09_jfalagra.Models;
using Mission09_jfalagra.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Mission09_jfalagra.Controllers
{
    public class HomeController : Controller
    {
        //Create repo to hide context file
        private IBookStoreRepository repo;
        public HomeController (IBookStoreRepository temp)
        {
            repo = temp;
        }

        //Create necessary dynamic info for pagination
        public IActionResult Index(string bookType, int pageNum = 1)
        {
            int pageSize = 10;

            var x = new BooksViewModel
            {
                Books = repo.Books
                .Where(b => b.Category == bookType || bookType == null)
                .OrderBy(b => b.Title)
                .Skip((pageNum - 1) * pageSize)
                .Take(pageSize),

                PageInfo = new PageInfo
                {
                    TotalNumBooks = (bookType == null ? repo.Books.Count() : 
                    repo.Books.Where(x=> x.Category == bookType).Count()),
                    BooksPerPage = pageSize,
                    CurrentPage = pageNum
                }
            };

            return View(x);
        }
    }
}
