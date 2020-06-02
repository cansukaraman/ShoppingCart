using System;
using System.Collections.Generic;
using System.Text;
using static Ecommerce.ShoppingCart.Core.Components.Enum;

namespace Ecommerce.ShoppingCart.Core.Model
{
    public class Coupon : IBaseClass
    {
        public Coupon(double discountAmount, double discount, DiscountType type)
        {
            DiscountAmount = discountAmount;
            Discount = discount;
            Type = type;
        }

        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public double DiscountAmount { get; set; }
        public double Discount { get; set; }
        public DiscountType Type  { get; set; }
        public DateTime Created { get; set; }
    }
}
