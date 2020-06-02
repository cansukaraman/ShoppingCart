using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using static Ecommerce.ShoppingCart.Core.Components.Enum;

namespace Ecommerce.ShoppingCart.Core.Model
{
    public class Campaign : IBaseClass
    {
        public Campaign() { }
        public Campaign(Category category, double discountAmount, int count, DiscountType type)
        {
            Category = category;
            DiscountAmount = discountAmount;
            Count = count;
            Type = type;
        }

        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime Created { get; set; }
        public DiscountType Type { get; set; }
        public Guid Guid { get; set; }
        public DateTime Start { get; set; }
        public DateTime Finish { get; set; }
        public double DiscountAmount { get; set; }
        public int CategoryId { get; set; }
        public int Count { get; set; }

        public Category Category { get; set; }
    }
}
