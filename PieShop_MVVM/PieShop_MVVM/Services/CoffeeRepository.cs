using PieShop_MVVM.Models;
using System.Collections.Generic;
using System.Linq;

namespace PieShop_MVVM.Services
{
    public class CoffeeRepository : ICoffeeRepository
    {
        // SINGLETON
        private static CoffeeRepository instance;

        // Private constructor -> No outside instancing of this class
        private CoffeeRepository()
        {
            AddDummyData();
        }

        // Static method. Other classes will request the one object in this class
        // If it does not exist yet, create it first.
        public static CoffeeRepository GetSingleton()
        {
            if (instance == null)
            {
                instance = new CoffeeRepository();
            }

            return instance;
        }

        // MOCK Database
        private List<Coffee> coffees;

        public List<Coffee> GetAllCoffees()
        {
            return coffees;
        }

        private void AddDummyData()
        {
            coffees = new List<Coffee>
            {
                    new Coffee
                    {
                        ID = 1,
                        ImageUrl = "segafredo.jpg",
                        Name = "Coffee with milk",
                        Price = 15.95,
                        Brand = "Douwe Egberts",
                        HasMilk = true,
                        Caffeine = 7
                    },
                    new Coffee
                    {
                        ID = 2,
                        ImageUrl="lavazza.jpg",
                        Name = "Espresso",
                        Price = 12.95,
                        Brand = "Douwe Egberts",
                        HasMilk = true,
                        Caffeine = 6
                    },
                    new Coffee
                    {
                        ID = 3,
                        ImageUrl="melita.jpg",
                        Name = "Bitter stuff",
                        Price = 9.95,
                        Brand = "Java",
                        HasMilk = false,
                        Caffeine = 7
                    },
                };
        }

        public void AddCoffee(Coffee coffee)
        {
            coffees.Add(coffee);
        }

        public Coffee GetCoffee(int id)
        {
            return coffees.FirstOrDefault(x => x.ID == id);
        }
    }
}