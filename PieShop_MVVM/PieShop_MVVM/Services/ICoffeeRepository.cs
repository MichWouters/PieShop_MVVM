using PieShop_MVVM.Models;
using System.Collections.Generic;

namespace PieShop_MVVM.Services
{
    public interface ICoffeeRepository
    {
        void AddCoffee(Coffee coffee);
        List<Coffee> GetAllCoffees();
        Coffee GetCoffee(int id);
    }
}