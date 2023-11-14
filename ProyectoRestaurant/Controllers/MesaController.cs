using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ProyectoRestaurant.Context;
using ProyectoRestaurant.Models;

namespace ProyectoRestaurant.Controllers
{
    public class MesaController : Controller
    {
        private readonly RestaurantDatabaseContext _context;

        public MesaController(RestaurantDatabaseContext context)
        {
            _context = context;
        }

        // GET: Mesa
        public async Task<IActionResult> Index()
        {
              return _context.Mesa != null ? 
                          View(await _context.Mesa.ToListAsync()) :
                          Problem("Entity set 'RestaurantDatabaseContext.Mesa'  is null.");
        }

        // GET: Mesa/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Mesa == null)
            {
                return NotFound();
            }

            var mesa = await _context.Mesa
                .FirstOrDefaultAsync(m => m.NumeroDeMesa == id);
            if (mesa == null)
            {
                return NotFound();
            }

            return View(mesa);
        }

        // GET: Mesa/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Mesa/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("NumeroDeMesa,MaximoPersonas,Libre")] Mesa mesa)
        {
            if (ModelState.IsValid)
            {
                _context.Add(mesa);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(mesa);
        }

        // GET: Mesa/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Mesa == null)
            {
                return NotFound();
            }

            var mesa = await _context.Mesa.FindAsync(id);
            if (mesa == null)
            {
                return NotFound();
            }
            return View(mesa);
        }

        // POST: Mesa/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("NumeroDeMesa,MaximoPersonas,Libre")] Mesa mesa)
        {
            if (id != mesa.NumeroDeMesa)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(mesa);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MesaExists(mesa.NumeroDeMesa))
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
            return View(mesa);
        }

        // GET: Mesa/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Mesa == null)
            {
                return NotFound();
            }

            var mesa = await _context.Mesa
                .FirstOrDefaultAsync(m => m.NumeroDeMesa == id);
            if (mesa == null)
            {
                return NotFound();
            }

            return View(mesa);
        }

        // POST: Mesa/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Mesa == null)
            {
                return Problem("Entity set 'RestaurantDatabaseContext.Mesa'  is null.");
            }
            var mesa = await _context.Mesa.FindAsync(id);
            if (mesa != null)
            {
                _context.Mesa.Remove(mesa);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MesaExists(int id)
        {
          return (_context.Mesa?.Any(e => e.NumeroDeMesa == id)).GetValueOrDefault();
        }
    }
}
