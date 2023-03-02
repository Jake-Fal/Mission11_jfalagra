using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mission09_jfalagra.Models
{
    public interface IBookStoreRepository
    {
        IQueryable<Book> Books { get; }
    }
}
