using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Ecommerce.ShoppingCart.Core.Repositories;
using Ecommerce.ShoppingCart.Core.Model;
using Ecommerce.ShoppingCart.Core.Components;
using static Ecommerce.ShoppingCart.Core.Components.Enum;

namespace Ecommerce.ShoppingCart.Web.Controllers
{
    public class HomeController : BaseController
    {
        private ShoppingCartRepository shoppingCart;

        public HomeController(ShoppingCartRepository shoppingCart)
        {
            this.shoppingCart = shoppingCart;
        }

        public IActionResult Index()
        {
            Category food = new Category("food");

            Product apple = new Product("Apple", 100, food);
            Product almond = new Product("Almond", 150, food);

            Cart cart = shoppingCart.Get(currentCart.Guid);
            shoppingCart.AddItem(apple, 3);
            shoppingCart.AddItem(almond, 1);

            HttpContext.Session.Set("cart", cart);

            Order o = new Order();
            o.Created = DateTime.Now;
            o.Cart = cart;
            o.CartId = cart.Id;

            //Campaign
            Campaign campaign1 = new Campaign(food, 10, 3, DiscountType.Rate);
            Campaign campaign2 = new Campaign(food, 20, 5, DiscountType.Rate);
            Campaign campaign3 = new Campaign(food, 30, 1, DiscountType.Amount);

            shoppingCart.ApplyDiscount(campaign1, campaign2, campaign3);
            shoppingCart.GetCampaignDiscount();

            //Coupon 
            Coupon coupon = new Coupon(100, 10, DiscountType.Rate);
            shoppingCart.ApplyCoupon(coupon);
            shoppingCart.GetCouponDiscount();

            //Delivery
            var deliveryCost = shoppingCart.GetDeliveryCost();
            o.ShipmentPrice = deliveryCost;

            //TotalAmount After Discount
            var totalAmountDiscount = shoppingCart.GetTotalAmountAfterDiscount();
            o.Amount = o.ShipmentPrice + totalAmountDiscount;

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }
    }
}
