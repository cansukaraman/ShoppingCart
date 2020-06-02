using Ecommerce.ShoppingCart.Core.Components;
using Ecommerce.ShoppingCart.Core.Model;
using Ecommerce.ShoppingCart.Core.Repositories.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace Ecommerce.ShoppingCart.Core.Repositories
{
    public class ShoppingCartRepository : BaseRepository<Cart>, IShoppingCartRepository
    {
        public ShoppingCartRepository(ShoppingCartContext context) : base(context) { }

        public string CartGuid { get; set; }
        public List<Campaign> Campaigns { get; set; }
        public Cart Cart { get; set; }
        public double CampaignDiscount { get; set; }
        public Coupon Coupon { get; set; }
        public double CouponDiscount { get; set; }

        public Cart Get(Guid guid)
        {
            Cart = FindBy(x => x.Guid == guid).FirstOrDefault();
            return Cart;
        }
        public bool AddItem(Product product, int quantity)
        {
            if (product.StockCount == 0 || quantity == 0)
                return false;

            var cart = FindBy(x => x.Guid == new Guid(CartGuid)).FirstOrDefault();
            if (cart == null)
            {
                Cart newCart = new Cart() { Guid = Guid.NewGuid() };
                Add(newCart);

                cart = FindBy(x => x.Guid == new Guid(CartGuid)).FirstOrDefault();
            }

            var cartItem = context.CartItems.SingleOrDefault(
            x => x.ProductId == product.Id && x.Cart.Guid == new Guid(CartGuid));

            if (cartItem == null)
            {
                CartItem item = new CartItem()
                {
                    CartId = cart.Id,
                    Product = product,
                    Quantity = quantity,
                    Created = DateTime.Now
                };

                context.CartItems.Add(item);
            }
            else
            {
                cartItem.Quantity += quantity;
            }

            context.SaveChanges();
            return true;
        }
        public void ApplyDiscount(params Campaign[] campaigns)
        {
            Campaigns.AddRange(campaigns);
        }
        public void GetCampaignDiscount()
        {
            foreach (var campaign in Campaigns)
            {
                var productAmount = Cart.CartItems.Where(y => y.Product.Category == campaign.Category).Sum(x => x.Amount);
                if (productAmount > campaign.DiscountAmount)
                {
                    switch (campaign.Type)
                    {
                        case Components.Enum.DiscountType.Rate:
                            double totalAmount = Cart.TotalAmount;
                            CampaignDiscount += totalAmount * (campaign.DiscountAmount / 100);
                            break;
                        case Components.Enum.DiscountType.Amount:
                            CampaignDiscount = campaign.DiscountAmount;
                            break;
                        default:
                            break;
                    }
                }               
            }
        }
        public void ApplyCoupon(Coupon coupon)
        {
            Coupon = coupon;
        }
        public void GetCouponDiscount()
        {
            double totalAmount = Cart.TotalAmount;
            if(totalAmount > Coupon.DiscountAmount)
            {
                switch (Coupon.Type)
                {
                    case Components.Enum.DiscountType.Rate:
                        CouponDiscount = totalAmount * (Coupon.Discount / 100);
                        break;
                    case Components.Enum.DiscountType.Amount:
                        CouponDiscount = Coupon.Discount;
                        break;
                    default:
                        break;
                }
            }
        }
        public double GetDeliveryCost()
        {
            DeliveryCostCalculator deliveryCostCalculator = new DeliveryCostCalculator(8, 9);
            double deliveryCost = deliveryCostCalculator.CalculateFor(Cart);

            return deliveryCost;
        }
        public double GetTotalAmountAfterDiscount()
        {
            return Cart.TotalAmount - CampaignDiscount - CouponDiscount;
        }
    }
}
