using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static Ecommerce.ShoppingCart.Core.Components.Enum;

namespace Ecommerce.ShoppingCart.Core.Model
{
    public class Cart : IBaseClass
    {
        public Cart()
        {
            CartItems = new List<CartItem>();
        }

        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime Created { get; set; }
        public Guid Guid { get; set; }
        public ICollection<CartItem> CartItems { get; set; }
        public double TotalAmount
        {
            get
            {
                return CartItems.Sum(item => item.Amount);
            }
        }

        public int ProductNumber
        {
            get { return CartItems.Select(x => x.Product).Count(); }
        }

        public int DeliveryNumber
        {
            get { return CartItems.Select(x => x.Product).GroupBy(y => y.Category.Id).Count(); }
        }
    }
}
