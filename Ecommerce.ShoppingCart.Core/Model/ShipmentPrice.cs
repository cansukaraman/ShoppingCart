using System;
using System.Collections.Generic;
using System.Text;

namespace Ecommerce.ShoppingCart.Core.Model
{
    public class ShipmentPrice
    {
        public int Id { get; set; }
        public int ShipmentId { get; set; }
        public decimal Price { get; set; }

        public Shipment Shipment { get; set; }
    }
}
