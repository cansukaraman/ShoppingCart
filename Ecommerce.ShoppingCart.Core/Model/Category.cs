using System;
using System.Collections.Generic;
using System.Text;
using static Ecommerce.ShoppingCart.Core.Components.Enum;

namespace Ecommerce.ShoppingCart.Core.Model
{
    public class Category : IBaseClass
    {
        public Category(string title)
        {
            Title = title;
        }
        public int Id { get; set; }
        public int ParentId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime Created { get; set; }
    } 
}
