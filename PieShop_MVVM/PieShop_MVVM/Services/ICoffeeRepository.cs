using PieShop_MVVM.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PieShop_MVVM.Services
{
    public interface ICoffeeRepository
    {
        Task AddCoffeeAsync(Coffee coffee);
        Task<List<Coffee>> GetAllCoffeesAsync();
        Task<Coffee> GetCoffeeAsync(int id);
    }
}