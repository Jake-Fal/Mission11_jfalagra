using Microsoft.AspNetCore.Mvc;
using Mission09_jfalagra.Models;
using System.Linq;

namespace Mission09_jfalagra.Components
{
    public class TypesViewComponent : ViewComponent
    {
        private IBookStoreRepository repo { get; set; }
        public TypesViewComponent(IBookStoreRepository temp)
        {
            repo = temp;
        }
        public IViewComponentResult Invoke()
        {
            ViewBag.SelectedType = RouteData?.Values["bookType"];

            var types = repo.Books
                .Select(x => x.Category)
                .Distinct()
                .OrderBy(x=>x);

            return View(types);
        }




    }
}
