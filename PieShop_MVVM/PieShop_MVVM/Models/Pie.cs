using System;
using System.Collections.Generic;
using System.Text;

namespace PieShop_MVVM.Models
{
    public class Pie: Product
    {
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
    }
}
