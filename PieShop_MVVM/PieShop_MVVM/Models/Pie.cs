using System;
using System.Collections.Generic;
using System.Text;

namespace PieShop_MVVM.Models
{
    public class Pie
    {
        public int ID { get; set; }

        private string  name;

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        private double price;

        public double Price
        {
            get { return price; }
            set { price = value; }
        }

        private string description;

        public string Description
        {
            get { return description; }
            set { description = value; }
        }

        private bool isInStock;

        public bool IsInStock
        {
            get { return isInStock; }
            set { isInStock = value; }
        }

        private string imageUrl;

        public string ImageUrl
        {
            get { return imageUrl; }
            set { imageUrl = value; }
        }




    }
}
