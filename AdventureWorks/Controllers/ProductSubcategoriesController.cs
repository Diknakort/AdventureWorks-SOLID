using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AdventureWorks.Models;

namespace AdventureWorks.Controllers
{
    public class ProductSubcategoriesController : Controller
    {
        private readonly AdventureWorks2016Context _context;

        public ProductSubcategoriesController(AdventureWorks2016Context context)
        {
            _context = context;
        }

        // GET: ProductSubcategories
        public async Task<IActionResult> Index()
        {
            var adventureWorks2016Context = _context.ProductSubcategories.Include(p => p.ProductCategory);
            return View(await adventureWorks2016Context.ToListAsync());
        }

        // GET: ProductSubcategories/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var productSubcategory = await _context.ProductSubcategories
                .Include(p => p.ProductCategory)
                .FirstOrDefaultAsync(m => m.ProductSubcategoryId == id);
            if (productSubcategory == null)
            {
                return NotFound();
            }

            return View(productSubcategory);
        }

        // GET: ProductSubcategories/Create
        public IActionResult Create()
        {
            ViewData["ProductCategoryId"] = new SelectList(_context.ProductCategories, "ProductCategoryId", "ProductCategoryId");
            return View();
        }

        // POST: ProductSubcategories/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ProductSubcategoryId,ProductCategoryId,Name,Rowguid,ModifiedDate")] ProductSubcategory productSubcategory)
        {
            if (ModelState.IsValid)
            {
                _context.Add(productSubcategory);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ProductCategoryId"] = new SelectList(_context.ProductCategories, "ProductCategoryId", "ProductCategoryId", productSubcategory.ProductCategoryId);
            return View(productSubcategory);
        }

        // GET: ProductSubcategories/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var productSubcategory = await _context.ProductSubcategories.FindAsync(id);
            if (productSubcategory == null)
            {
                return NotFound();
            }
            ViewData["ProductCategoryId"] = new SelectList(_context.ProductCategories, "ProductCategoryId", "ProductCategoryId", productSubcategory.ProductCategoryId);
            return View(productSubcategory);
        }

        // POST: ProductSubcategories/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ProductSubcategoryId,ProductCategoryId,Name,Rowguid,ModifiedDate")] ProductSubcategory productSubcategory)
        {
            if (id != productSubcategory.ProductSubcategoryId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(productSubcategory);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProductSubcategoryExists(productSubcategory.ProductSubcategoryId))
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
            ViewData["ProductCategoryId"] = new SelectList(_context.ProductCategories, "ProductCategoryId", "ProductCategoryId", productSubcategory.ProductCategoryId);
            return View(productSubcategory);
        }

        // GET: ProductSubcategories/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var productSubcategory = await _context.ProductSubcategories
                .Include(p => p.ProductCategory)
                .FirstOrDefaultAsync(m => m.ProductSubcategoryId == id);
            if (productSubcategory == null)
            {
                return NotFound();
            }

            return View(productSubcategory);
        }

        // POST: ProductSubcategories/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var productSubcategory = await _context.ProductSubcategories.FindAsync(id);
            if (productSubcategory != null)
            {
                _context.ProductSubcategories.Remove(productSubcategory);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProductSubcategoryExists(int id)
        {
            return _context.ProductSubcategories.Any(e => e.ProductSubcategoryId == id);
        }
    }
}
