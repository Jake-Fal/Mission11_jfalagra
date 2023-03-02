using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mission09_jfalagra.Models
{
    //create repo with inheritance to get to private context
    public class EFBookStoreRepository : IBookStoreRepository
    {
        private Bookstore1Context context { get; set; }
        public EFBookStoreRepository (Bookstore1Context temp)
        {
            context = temp;
        }
        public IQueryable<Book> Books => context.Books;
    }
}
