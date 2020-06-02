using System;
using System.Collections.Generic;
using System.Text;

namespace Ecommerce.ShoppingCart.Core.Model
{
    public class CartItem
    {
        public int Id { get; set; }
        public int CartId { get; set; }
        public int ProductId { get; set; }
        public int Quantity { get; set; }
        public double Price { get; set; } //TODO: Fiyatı üründen çekebilriz.
        public DateTime Created { get; set; }
        public double Amount
        {
            get
            {
                return Price * Quantity;
            }
        }

        public Cart Cart { get; set; }
        public Product Product { get; set; }
    }
}
