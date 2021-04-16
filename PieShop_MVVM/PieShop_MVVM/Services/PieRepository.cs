﻿using PieShop_MVVM.Models;
using System.Collections.Generic;
using System.Linq;

namespace PieShop_MVVM.Services
{
    public class PieRepository : IPieRepository
    {
        public PieRepository()
        {
        }

        public List<Pie> GetAllPies()
        {
            using (var dbContext = new PieshopContext())
            {
                return dbContext.Pies.ToList();
            }
        }

        public Pie GetPie(int id)
        {
            using (var dbContext = new PieshopContext())
            {
                return dbContext.Pies.Find(id);
            }
        }

        public void SavePie(Pie pie)
        {
            using (var dbContext = new PieshopContext())
            {
                if (pie.ID == 0)
                {
                    dbContext.Pies.Add(pie);
                }
                else
                {
                    dbContext.Pies.Update(pie);
                }

                // Don't forget to save changes after operating.
                dbContext.SaveChanges();
            }
        }

        //private void AddDummyData()
        //{
        //    pies = new List<Pie>
        //    {
        //            new Pie
        //            {
        //                ID = 1,
        //                IsInStock = true,
        //                ImageUrl = "strawberrypiesmall.jpg",
        //                Name = "Strawberry Pie",
        //                Price = 15.95,
        //                Description = "Icing carrot cake jelly-o cheesecake. Sweet roll marzipan marshmallow toffee brownie brownie candy tootsie roll. Chocolate cake gingerbread tootsie roll oat cake pie chocolate bar cookie dragée brownie. Lollipop cotton candy cake bear claw oat cake. Dragée candy canes dessert tart. Marzipan dragée gummies lollipop jujubes chocolate bar candy canes. Icing gingerbread chupa chups cotton candy cookie sweet icing bonbon gummies. Gummies lollipop brownie biscuit danish chocolate cake. Danish powder cookie macaroon chocolate donut tart. Carrot cake dragée croissant lemon drops liquorice lemon drops cookie lollipop toffee. Carrot cake carrot cake liquorice sugar plum topping bonbon pie muffin jujubes. Jelly pastry wafer tart caramels bear claw. Tiramisu tart pie cake danish lemon drops. Brownie cupcake dragée gummies."
        //            },
        //            new Pie
        //            {
        //                ID = 2,
        //                IsInStock = true,
        //                ImageUrl = "cheesecakesmall.jpg",
        //                Name = "Cheese cake",
        //                Price = 18.95,
        //                Description = "Icing carrot cake jelly-o cheesecake. Sweet roll marzipan marshmallow toffee brownie brownie candy tootsie roll. Chocolate cake gingerbread tootsie roll oat cake pie chocolate bar cookie dragée brownie. Lollipop cotton candy cake bear claw oat cake. Dragée candy canes dessert tart. Marzipan dragée gummies lollipop jujubes chocolate bar candy canes. Icing gingerbread chupa chups cotton candy cookie sweet icing bonbon gummies. Gummies lollipop brownie biscuit danish chocolate cake. Danish powder cookie macaroon chocolate donut tart. Carrot cake dragée croissant lemon drops liquorice lemon drops cookie lollipop toffee. Carrot cake carrot cake liquorice sugar plum topping bonbon pie muffin jujubes. Jelly pastry wafer tart caramels bear claw. Tiramisu tart pie cake danish lemon drops. Brownie cupcake dragée gummies."
        //            },
        //            new Pie
        //            {
        //                ID = 3,
        //                IsInStock = true,
        //                ImageUrl = "rhubarbpiesmall.jpg",
        //                Name = "Rhubarb Pie",
        //                Price = 15.95,
        //                Description = "Icing carrot cake jelly-o cheesecake. Sweet roll marzipan marshmallow toffee brownie brownie candy tootsie roll. Chocolate cake gingerbread tootsie roll oat cake pie chocolate bar cookie dragée brownie. Lollipop cotton candy cake bear claw oat cake. Dragée candy canes dessert tart. Marzipan dragée gummies lollipop jujubes chocolate bar candy canes. Icing gingerbread chupa chups cotton candy cookie sweet icing bonbon gummies. Gummies lollipop brownie biscuit danish chocolate cake. Danish powder cookie macaroon chocolate donut tart. Carrot cake dragée croissant lemon drops liquorice lemon drops cookie lollipop toffee. Carrot cake carrot cake liquorice sugar plum topping bonbon pie muffin jujubes. Jelly pastry wafer tart caramels bear claw. Tiramisu tart pie cake danish lemon drops. Brownie cupcake dragée gummies."
        //            },
        //            new Pie
        //            {
        //                ID = 4,
        //                IsInStock = true,
        //                ImageUrl = "pumpkinpiesmall.jpg",
        //                Name = "Pumpkin Pie",
        //                Price = 12.95,
        //                Description = "Icing carrot cake jelly-o cheesecake. Sweet roll marzipan marshmallow toffee brownie brownie candy tootsie roll. Chocolate cake gingerbread tootsie roll oat cake pie chocolate bar cookie dragée brownie. Lollipop cotton candy cake bear claw oat cake. Dragée candy canes dessert tart. Marzipan dragée gummies lollipop jujubes chocolate bar candy canes. Icing gingerbread chupa chups cotton candy cookie sweet icing bonbon gummies. Gummies lollipop brownie biscuit danish chocolate cake. Danish powder cookie macaroon chocolate donut tart. Carrot cake dragée croissant lemon drops liquorice lemon drops cookie lollipop toffee. Carrot cake carrot cake liquorice sugar plum topping bonbon pie muffin jujubes. Jelly pastry wafer tart caramels bear claw. Tiramisu tart pie cake danish lemon drops. Brownie cupcake dragée gummies."
        //            }
        //        };
        //}
    }
};