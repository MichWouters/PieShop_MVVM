namespace PieShop_MVVM.Models
{
    public abstract class Product
    {
        public int ID { get; set; }

        public string Name { get; set; }

        public double Price { get; set; }

        public string ImageUrl { get; set; }
    }
}