﻿using System;
using System.Collections.Generic;
using System.Text;
using static Ecommerce.ShoppingCart.Core.Components.Enum;

namespace Ecommerce.ShoppingCart.Core.Model
{
    public class Shipment : IBaseClass
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime Created { get; set; }

        public List<ShipmentPrice> TotalPrice { get; set; }

    }
}
