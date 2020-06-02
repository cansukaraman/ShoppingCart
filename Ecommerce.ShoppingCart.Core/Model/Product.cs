using System;
using System.Collections.Generic;
using System.Text;
using static Ecommerce.ShoppingCart.Core.Components.Enum;

namespace Ecommerce.ShoppingCart.Core.Model
{
    public class Product : IBaseClass
    {
        public Product() { }
        public Product(string title, decimal price, Category category)
        {
            Title = title;
            Price = price;
            Category = category;
        }

        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime Created { get; set; }
        public decimal Price { get; set; }
        public int CategoryId { get; set; }
        public int StockCount { get; set; }

        public Category Category { get; set; }
    }
}
