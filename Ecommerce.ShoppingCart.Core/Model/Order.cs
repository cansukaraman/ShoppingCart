using System;
using System.Collections.Generic;
using System.Text;

namespace Ecommerce.ShoppingCart.Core.Model
{
    public class Order : IBaseClass
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public Guid Guid { get; set; }
        public int CartId { get; set; }
        public DateTime Created { get; set; }
        public double Amount { get; set; }
        public int ShipmentId { get; set; }
        public double ShipmentPrice { get; set; }

        public Cart Cart { get; set; }
        public Shipment Shipment { get; set; }
    }
}
