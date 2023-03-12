using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace Mission09_jfalagra.Models
{
    public class EFPurchaseRepository : IPurchaseRepository
    {
        private Bookstore1Context context;
        public EFPurchaseRepository(Bookstore1Context temp) 
        {
            context = temp;
        }
        public IQueryable<Purchase> Purchases => context.Purchases.Include(x => x.Lines).ThenInclude(x => x.Book);
        public void SavePurchase(Purchase purchase)
        {
            context.AttachRange(purchase.Lines.Select(x => x.Book));
            if (purchase.PurchaseId == 0)
            {
                context.Purchases.Add(purchase);
            }
            context.SaveChanges();
        }
    }
}
