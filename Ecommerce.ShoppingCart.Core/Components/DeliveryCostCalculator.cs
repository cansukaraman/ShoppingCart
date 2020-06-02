using Ecommerce.ShoppingCart.Core.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ecommerce.ShoppingCart.Core.Components
{
    public class DeliveryCostCalculator
    {
        public int CostOfDelivery { get; set; }
        public int CostOfProduct { get; set; }
        public double FixedCost { get; set; }
        public DeliveryCostCalculator(int costOfDelivery, int costOfProduct, double fixedCost = 2.99)
        {
            CostOfDelivery = costOfDelivery;
            CostOfProduct = costOfProduct;
            FixedCost = fixedCost;
        }

        public double CalculateFor(Cart cart)
        {
            int numberOfDelivery = cart.DeliveryNumber;
            int numberOfProduct = cart.ProductNumber;

            return (CostOfDelivery * numberOfDelivery) + (CostOfProduct * numberOfProduct) + FixedCost;
        }
    }
}
