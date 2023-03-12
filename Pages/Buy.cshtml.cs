using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Mission09_jfalagra.Infrastructure;
using Mission09_jfalagra.Models;
using System.Linq;

namespace Mission09_jfalagra.Pages
{
    public class BuyModel : PageModel
    {
        public IBookStoreRepository repo { get; set; }
        public BuyModel (IBookStoreRepository temp, Basket b)
        {
            repo = temp;
            basket = b;
        }
        //Set instances
        public Basket basket { get; set; }
        public string ReturnUrl { get; set; }
        //Pass Url for return to previous page
        public void OnGet(string returnUrl)
        {
            ReturnUrl = returnUrl ?? "/";
        }
        //Post info of books on cart
        public IActionResult OnPost(int bookId, string returnUrl) 
        {
            Book b = repo.Books.FirstOrDefault(x => x.BookId == bookId);
            basket.AddItem(b, 1);
            return RedirectToPage(new {ReturnUrl = returnUrl});
        }
        public IActionResult OnPostRemove(int bookId, string returnUrl)
        {
            basket.RemoveItem(basket.Items.First(x => x.Book.BookId == bookId).Book);
            return RedirectToPage(new { ReturnUrl = returnUrl});
        }
    }
}
