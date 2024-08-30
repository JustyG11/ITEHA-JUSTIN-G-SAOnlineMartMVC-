using Microsoft.AspNetCore.Mvc;
using SAOnlineMartMVC.Data;
using SAOnlineMartMVC.Models;
using System.Linq;
using System.Collections.Generic;

namespace SAOnlineMartMVC.Controllers
{
    public class CartController : Controller
    {
        private readonly AppDbContext _context;
        private static List<CartItem> cart = new List<CartItem>();

        public CartController(AppDbContext context)
        {
            _context = context;
        }

        // GET: /Cart
        public IActionResult Index()
        {
            return View(cart);
        }

        // POST: /Cart/Add/5
        public IActionResult Add(int id, int quantity = 1)
        {
            // Fetch the product details from the database
            var product = _context.Products.FirstOrDefault(p => p.Id == id);

            if (product == null)
            {
                TempData["ErrorMessage"] = "Product not found.";
                return RedirectToAction(nameof(Index));
            }

            // Check if the product is already in the cart
            var cartItem = cart.FirstOrDefault(c => c.Product.Id == id);

            if (cartItem != null)
            {
                // Update quantity if product already exists in the cart
                cartItem.Quantity += quantity;
            }
            else
            {
                // Add a new item to the cart
                cart.Add(new CartItem { Product = product, Quantity = quantity });
            }

            return RedirectToAction(nameof(Index));
        }

        // POST: /Cart/Remove/5
        public IActionResult Remove(int id)
        {
            var cartItem = cart.FirstOrDefault(c => c.Product.Id == id);
            if (cartItem != null)
            {
                cart.Remove(cartItem);
            }
            return RedirectToAction(nameof(Index));
        }
    }
}
