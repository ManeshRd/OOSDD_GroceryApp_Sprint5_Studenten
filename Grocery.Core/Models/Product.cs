using CommunityToolkit.Mvvm.ComponentModel;

namespace Grocery.Core.Models
{
    public partial class Product : Model
    {
        [ObservableProperty]
        public int stock;
        public DateOnly ShelfLife { get; set; }
        public double Price { get; set; }

        public Product(int id, string name, int stock) : this(id, name, stock, default, default) { }

        public Product(int id, string name, int stock, DateOnly shelfLife, double price) : base(id, name) 
        {
            Price = price;
            Stock = stock;
            ShelfLife = shelfLife;
        }
        public override string? ToString()
        {
            return $"{Name} - {Stock} op voorraad";
        }
    }
}
