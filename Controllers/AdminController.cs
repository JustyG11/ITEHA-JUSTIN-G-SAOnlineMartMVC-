using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http; // For session management
using SAOnlineMartMVC.Data;
using SAOnlineMartMVC.Models;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace SAOnlineMartMVC.Controllers
{
    public class AdminController : Controller
    {
        private readonly AppDbContext _context;

        public AdminController(AppDbContext context)
        {
            _context = context;
        }

        // GET: /Admin/Login
        // Displays the login form
        public IActionResult Login()
        {
            return View();
        }

        // POST: /Admin/Login
        // Handles the login form submission
        [HttpPost]
        public IActionResult Login(string username, string password)
        {
            // Simple hardcoded login check - replace with a secure method for production
            if (username == "admin" && password == "password") // Use secure methods in real applications
            {
                // Set session variable to indicate logged-in status
                HttpContext.Session.SetString("IsAdmin", "true");
                return RedirectToAction(nameof(Index));
            }

            // Display error message if login fails
            ViewBag.ErrorMessage = "Invalid username or password";
            return View();
        }

        // GET: /Admin/Logout
        // Logs the admin out and clears the session
        public IActionResult Logout()
        {
            HttpContext.Session.Remove("IsAdmin");
            return RedirectToAction(nameof(Login));
        }

        // GET: /Admin
        // Displays a list of products for admin management
        public IActionResult Index()
        {
            // Check if the admin is logged in
            if (HttpContext.Session.GetString("IsAdmin") != "true")
            {
                return RedirectToAction(nameof(Login));
            }

            var products = _context.Products.ToList();
            return View(products);
        }

        // GET: /Admin/Create
        // Displays the form to create a new product
        public IActionResult Create()
        {
            return View();
        }

        // POST: /Admin/Create
        // Handles the form submission to create a new product
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Name,Description,Price,Stock")] Product product)
        {
            if (ModelState.IsValid)
            {
                _context.Add(product);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(product);
        }

        // GET: /Admin/Edit/5
        // Displays the form to edit an existing product
        public async Task<IActionResult> Edit(int id)
        {
            var product = await _context.Products.FindAsync(id);
            if (product == null)
            {
                return NotFound();
            }
            return View(product);
        }

        // POST: /Admin/Edit/5
        // Handles the form submission to update an existing product
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Description,Price,Stock")] Product product)
        {
            if (id != product.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(product);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProductExists(product.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(product);
        }

        // GET: /Admin/Delete/5
        // Displays a confirmation page to delete a product
        public async Task<IActionResult> Delete(int id)
        {
            var product = await _context.Products.FindAsync(id);
            if (product == null)
            {
                return NotFound();
            }
            return View(product);
        }

        // POST: /Admin/Delete/5
        // Handles the confirmation to delete a product
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var product = await _context.Products.FindAsync(id);
            if (product != null)
            {
                _context.Products.Remove(product);
                await _context.SaveChangesAsync();
            }
            return RedirectToAction(nameof(Index));
        }

        // Helper method to check if a product exists by ID
        private bool ProductExists(int id)
        {
            return _context.Products.Any(e => e.Id == id);
        }
    }
}
