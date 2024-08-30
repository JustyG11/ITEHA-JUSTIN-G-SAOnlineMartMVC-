using Microsoft.AspNetCore.Mvc;
using SAOnlineMartMVC.Models;
using System.Collections.Generic;
using System.Linq;

namespace SAOnlineMartMVC.Controllers
{
    public class CheckoutController : Controller
    {

        private static List<CartItem> cart = new List<CartItem>();

        // GET: /Checkout
        // Displays the checkout form
        public IActionResult Index()
        {
            // Ensure cart is not empty before proceeding to checkout
            if (!cart.Any())
            {
                TempData["Message"] = "Your cart is empty. Please add items before checking out.";
                return RedirectToAction("Index", "Cart");
            }

            ViewBag.Cart = cart; // Pass the cart to the view
            return View(new Order()); // Pass a new Order object to the view
        }

        // POST: /Checkout/Complete
        // Processes the checkout form submission
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Complete(Order order)
        {
            if (ModelState.IsValid)
            {
                // Process the order here (e.g., save to database, send confirmation email, etc.)
                // Clear the cart after successful checkout
                cart.Clear();
                ViewBag.Message = "Thank you for your order!";
                return View("Complete");
            }

            // If the model state is invalid, redisplay the checkout form with errors
            ViewBag.Cart = cart;
            return View("Index", order);
        }
    }
}
