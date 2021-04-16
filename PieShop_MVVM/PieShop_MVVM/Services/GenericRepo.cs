using PieShop_MVVM.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PieShop_MVVM.Services
{
    public class GenericRepo<T> where T: Product
    {
        public async Task AddItem(T product)
        {
            using (var dbContext = new PieshopContext())
            {
                if (product.ID == 0)
                {
                    await dbContext.AddAsync(product);
                }
                else
                {
                    dbContext.Update(product);
                }

                // Don't forget to save changes after operating.
                await dbContext.SaveChangesAsync();
            }
        }

        public async Task<T>FindItemAsync(int id)
        {
            using (var dbContext = new PieshopContext())
            {
               return await dbContext.FindAsync<T>(id);
            }
        }
    }
}
