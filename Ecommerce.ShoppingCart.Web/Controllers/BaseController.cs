using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ecommerce.ShoppingCart.Core.Components;
using Ecommerce.ShoppingCart.Core.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Ecommerce.ShoppingCart.Web.Controllers
{
    public class BaseController : Controller
    {
        public Cart currentCart
        {
            get
            {
                if (HttpContext.Session.Keys.Contains("cart"))
                    return HttpContext.Session.Get<Cart>("cart");
                else
                    return null;
            }
        }
    }
}