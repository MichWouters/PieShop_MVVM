using PieShop_MVVM.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PieShop_MVVM.Services
{
    public interface IPieRepository
    {
        Task<List<Pie>> GetAllPiesAsync();
        Task<Pie> GetPieAsync(int id);
        Task SavePieAsync(Pie pie);
    }
}