using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AdventureWorks.Models;
using AdventureWorks.ViewModels;

namespace AdventureWorks.Controllers
{
    public class SalesOrderDetailsController : Controller
    {
        private readonly AdventureWorks2016Context _context;

        public SalesOrderDetailsController(AdventureWorks2016Context context)
        {
            _context = context;
        }

        // GET: SalesOrderDetails
        public async Task<IActionResult> Index()
        {
            //var resultado = from Sale in _context.SalesOrderDetails.Take(500)
            //                join Prod in _context.Products
            //        on Sale.SalesOrderDetailId equals Prod.ProductId
            //    select new SaleOrderViewModel()
            //    {
            //        Id = Sale.SalesOrderDetailId,
            //        CodigoProducto = Sale.ProductId,
            //        NombreProducto = Prod.Name,
            //        ColorProducto= Prod.Color
            //    };




            var adventureWorks2016Context = _context.SalesOrderDetails.Include(s => s.SalesOrder).Include(s => s.SpecialOfferProduct);
            return View(await adventureWorks2016Context.ToListAsync());

        }
        public async Task<IActionResult> ListaFiltrada()
        {
            var resultado = from Sale in _context.SalesOrderDetails.Take(500)
                join Prod in _context.Products
                    on Sale.SalesOrderDetailId equals Prod.ProductId
                select new SaleOrderViewModel()
                {
                    Id = Sale.SalesOrderDetailId,
                    CodigoProducto = Sale.ProductId,
                    NombreProducto = Prod.Name,
                    ColorProducto = Prod.Color
                };




            //var adventureWorks2016Context = _context.SalesOrderDetails.Include(s => s.SalesOrder).Include(s => s.SpecialOfferProduct);
            //return View(await adventureWorks2016Context.ToListAsync());
            return View(resultado);

        }

        // GET: SalesOrderDetails/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var salesOrderDetail = await _context.SalesOrderDetails
                .Include(s => s.SalesOrder)
                .Include(s => s.SpecialOfferProduct)
                .FirstOrDefaultAsync(m => m.SalesOrderId == id);
            if (salesOrderDetail == null)
            {
                return NotFound();
            }

            return View(salesOrderDetail);
        }

        // GET: SalesOrderDetails/Create
        public IActionResult Create()
        {
            ViewData["SalesOrderId"] = new SelectList(_context.SalesOrderHeaders, "SalesOrderId", "SalesOrderId");
            ViewData["SpecialOfferId"] = new SelectList(_context.SpecialOfferProducts, "SpecialOfferId", "SpecialOfferId");
            return View();
        }

        // POST: SalesOrderDetails/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("SalesOrderId,SalesOrderDetailId,CarrierTrackingNumber,OrderQty,ProductId,SpecialOfferId,UnitPrice,UnitPriceDiscount,LineTotal,Rowguid,ModifiedDate")] SalesOrderDetail salesOrderDetail)
        {
            if (ModelState.IsValid)
            {
                _context.Add(salesOrderDetail);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["SalesOrderId"] = new SelectList(_context.SalesOrderHeaders, "SalesOrderId", "SalesOrderId", salesOrderDetail.SalesOrderId);
            ViewData["SpecialOfferId"] = new SelectList(_context.SpecialOfferProducts, "SpecialOfferId", "SpecialOfferId", salesOrderDetail.SpecialOfferId);
            return View(salesOrderDetail);
        }

        // GET: SalesOrderDetails/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var salesOrderDetail = await _context.SalesOrderDetails.FindAsync(id);
            if (salesOrderDetail == null)
            {
                return NotFound();
            }
            ViewData["SalesOrderId"] = new SelectList(_context.SalesOrderHeaders, "SalesOrderId", "SalesOrderId", salesOrderDetail.SalesOrderId);
            ViewData["SpecialOfferId"] = new SelectList(_context.SpecialOfferProducts, "SpecialOfferId", "SpecialOfferId", salesOrderDetail.SpecialOfferId);
            return View(salesOrderDetail);
        }

        // POST: SalesOrderDetails/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("SalesOrderId,SalesOrderDetailId,CarrierTrackingNumber,OrderQty,ProductId,SpecialOfferId,UnitPrice,UnitPriceDiscount,LineTotal,Rowguid,ModifiedDate")] SalesOrderDetail salesOrderDetail)
        {
            if (id != salesOrderDetail.SalesOrderId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(salesOrderDetail);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SalesOrderDetailExists(salesOrderDetail.SalesOrderId))
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
            ViewData["SalesOrderId"] = new SelectList(_context.SalesOrderHeaders, "SalesOrderId", "SalesOrderId", salesOrderDetail.SalesOrderId);
            ViewData["SpecialOfferId"] = new SelectList(_context.SpecialOfferProducts, "SpecialOfferId", "SpecialOfferId", salesOrderDetail.SpecialOfferId);
            return View(salesOrderDetail);
        }

        // GET: SalesOrderDetails/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var salesOrderDetail = await _context.SalesOrderDetails
                .Include(s => s.SalesOrder)
                .Include(s => s.SpecialOfferProduct)
                .FirstOrDefaultAsync(m => m.SalesOrderId == id);
            if (salesOrderDetail == null)
            {
                return NotFound();
            }

            return View(salesOrderDetail);
        }

        // POST: SalesOrderDetails/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var salesOrderDetail = await _context.SalesOrderDetails.FindAsync(id);
            if (salesOrderDetail != null)
            {
                _context.SalesOrderDetails.Remove(salesOrderDetail);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SalesOrderDetailExists(int id)
        {
            return _context.SalesOrderDetails.Any(e => e.SalesOrderId == id);
        }
    }
}
