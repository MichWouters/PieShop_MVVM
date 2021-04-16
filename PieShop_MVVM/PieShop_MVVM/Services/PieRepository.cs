using Microsoft.EntityFrameworkCore;
using PieShop_MVVM.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PieShop_MVVM.Services
{
    public class PieRepository : IPieRepository
    {
        public PieRepository()
        {
        }

        public async Task<List<Pie>> GetAllPiesAsync()
        {
            using (var dbContext = new PieshopContext())
            {
                return await dbContext.Pies.ToListAsync();
            }
        }

        public async Task<Pie> GetPieAsync(int id)
        {
            using (var dbContext = new PieshopContext())
            {
                return await dbContext.Pies.FindAsync(id);
            }
        }

        public async Task SavePieAsync(Pie pie)
        {
            using (var dbContext = new PieshopContext())
            {
                if (pie.ID == 0)
                {
                    await dbContext.Pies.AddAsync(pie);
                }
                else
                {
                    dbContext.Pies.Update(pie);
                }

                // Don't forget to save changes after operating.
                await dbContext.SaveChangesAsync();
            }
        }
    }
};