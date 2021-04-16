using System;
using System.Collections.Generic;
using System.Text;

namespace PieShop_MVVM.Models
{
    public class Coffee: Product
    {
        public bool HasMilk { get; set; }

        public int Caffeine { get; set; }

        public string Brand { get; set; }
    }
}
