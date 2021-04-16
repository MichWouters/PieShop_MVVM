using Microsoft.EntityFrameworkCore;
using PieShop_MVVM.Models;
using System.IO;
using Xamarin.Essentials;

namespace PieShop_MVVM.Services
{
    public class PieshopContext: DbContext
    {
        public DbSet<Coffee> Coffees { get; set; }

        public DbSet<Pie> Pies { get; set; }

        public PieshopContext()
        {
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string dbPath = Path.Combine(FileSystem.AppDataDirectory, "PieShop.sqlite");
            optionsBuilder.UseSqlite($"FileName = {dbPath}");
        }
    }
}
