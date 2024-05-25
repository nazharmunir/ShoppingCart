using Microsoft.AspNetCore.Mvc;
using ShoppingCart.Models;
using ShoppingCart.Models.ViewModels;

namespace ShoppingCart.Infrastructure.Components
{
    public class SmallCartViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            List<CartItem> cart = HttpContext.Session.GetJson<List<CartItem>>("Cart");
            SmallCartViewModel smallCartVM;

            if (cart == null || cart.Count == 0)
            {
                smallCartVM = null;
            }
            else
            {
                decimal totalAmount = cart.Sum(x => x.Quantity * x.Price); // Calculate total amount without discount

                // Apply discount if total amount is greater than 1000
                if (totalAmount > 1000)
                {
                    decimal discount = totalAmount * 0.1m; // 10% discount
                    totalAmount -= discount; // Apply discount to total amount
                }

                smallCartVM = new()
                {
                    NumberOfItems = cart.Sum(x => x.Quantity),
                    TotalAmount = totalAmount
                };
            }


            return View(smallCartVM);
        }
    }
}