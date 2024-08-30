using Microsoft.AspNetCore.Mvc;
using SAOnlineMartMVC.Data;
using SAOnlineMartMVC.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace SAOnlineMartMVC.Controllers
{
    public class ProductController : Controller
    {
        private readonly AppDbContext _context;

        // Inject the AppDbContext to access the database
        public ProductController(AppDbContext context)
        {
            _context = context;
        }

        // GET: /Product/List
        // Displays a list of all products
        public async Task<IActionResult> List()
        {
            // Fetch all products from the database
            var products = await _context.Products.ToListAsync();
            return View(products);
        }

        // GET: /Product/Details/5
        // Displays details for a specific product
        public async Task<IActionResult> Details(int id)
        {
            // Find the product by ID
            var product = await _context.Products.FindAsync(id);

            // If the product is not found, return a 404 Not Found response
            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }

        // GET: /Product/Create
        // Displays a form to create a new product
        public IActionResult Create()
        {
            return View();
        }

        // POST: /Product/Create
        // Handles the form submission to create a new product
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Name,Description,Price,Stock")] Product product)
        {
            if (ModelState.IsValid)
            {
                // Add the new product to the database
                _context.Add(product);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(List));
            }
            return View(product);
        }

        // GET: /Product/Edit/5
        // Displays a form to edit an existing product
        public async Task<IActionResult> Edit(int id)
        {
            // Find the product by ID
            var product = await _context.Products.FindAsync(id);

            // If the product is not found, return a 404 Not Found response
            if (product == null)
            {
                return NotFound();
            }
            return View(product);
        }

        // POST: /Product/Edit/5
        // Handles the form submission to update an existing product
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Description,Price,Stock")] Product product)
        {
            // Check if the IDs match
            if (id != product.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    // Update the product in the database
                    _context.Update(product);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    // Check if the product still exists
                    if (!ProductExists(product.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(List));
            }
            return View(product);
        }

        // GET: /Product/Delete/5
        // Displays a confirmation page to delete a product
        public async Task<IActionResult> Delete(int id)
        {
            // Find the product by ID
            var product = await _context.Products.FindAsync(id);

            // If the product is not found, return a 404 Not Found response
            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }

        // POST: /Product/Delete/5
        // Handles the confirmation to delete a product
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            // Find the product by ID
            var product = await _context.Products.FindAsync(id);

            // If the product is found, remove it from the database
            if (product != null)
            {
                _context.Products.Remove(product);
                await _context.SaveChangesAsync();
            }

            return RedirectToAction(nameof(List));
        }

        // Helper method to check if a product exists by ID
        private bool ProductExists(int id)
        {
            return _context.Products.Any(e => e.Id == id);
        }
    }
}
