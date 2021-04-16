using Microsoft.EntityFrameworkCore;
using PieShop_MVVM.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PieShop_MVVM.Services
{
    public class CoffeeRepository : ICoffeeRepository
    {
        public async Task<List<Coffee>> GetAllCoffeesAsync()
        {
            using (var dbContext = new PieshopContext())
            {
                return await dbContext.Coffees.ToListAsync();
            }
        }

        public async Task AddCoffeeAsync(Coffee coffee)
        {
            using (var dbContext = new PieshopContext())
            {
                if (coffee.ID == 0)
                {
                    await dbContext.Coffees.AddAsync(coffee);
                }
                else
                {
                    dbContext.Coffees.Update(coffee);
                }

                await dbContext.SaveChangesAsync();
            }
        }

        public async Task<Coffee> GetCoffeeAsync(int id)
        {
            using (var dbContext = new PieshopContext())
            {
                return await dbContext.Coffees.FindAsync();
            }
        }
    }
}