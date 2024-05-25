using System.Collections.Generic;
using System.Linq;

namespace ShoppingCart.Models.ViewModels
{
    public class CartViewModel
    {
        public List<CartItem> CartItems { get; set; }
        public decimal GrandTotal { get; set; } // Grand total including discount
        public decimal Discount { get; set; } // Discount amount

        public CartViewModel()
        {
            CartItems = new List<CartItem>();
        }

        public void CalculateTotalAndDiscount()
        {
            if (CartItems == null || CartItems.Count == 0)
            {
                GrandTotal = 0m;
                Discount = 0m;
                return;
            }

            decimal totalAmount = CartItems.Sum(x => x.Quantity * x.Price); // Calculate total amount without discount

            if (totalAmount > 1000)
            {
                Discount = totalAmount * 0.1m; // Calculate discount amount
                GrandTotal = totalAmount - Discount; // Apply discount to total amount
            }
            else
            {
                Discount = 0m;
                GrandTotal = totalAmount;
            }
        }
    }
}
