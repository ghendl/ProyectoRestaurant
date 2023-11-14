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
    public class FechaController : Controller
    {
        private readonly RestaurantDatabaseContext _context;

        public FechaController(RestaurantDatabaseContext context)
        {
            _context = context;
        }

        // GET: Fecha
        public async Task<IActionResult> Index()
        {
              return _context.Fecha != null ? 
                          View(await _context.Fecha.ToListAsync()) :
                          Problem("Entity set 'RestaurantDatabaseContext.Fecha'  is null.");
        }

        // GET: Fecha/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Fecha == null)
            {
                return NotFound();
            }

            var fecha = await _context.Fecha
                .FirstOrDefaultAsync(m => m.ID == id);
            if (fecha == null)
            {
                return NotFound();
            }

            return View(fecha);
        }

        // GET: Fecha/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Fecha/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Dia,Hora")] Fecha fecha)
        {
            if (ModelState.IsValid)
            {
                _context.Add(fecha);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(fecha);
        }

        // GET: Fecha/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Fecha == null)
            {
                return NotFound();
            }

            var fecha = await _context.Fecha.FindAsync(id);
            if (fecha == null)
            {
                return NotFound();
            }
            return View(fecha);
        }

        // POST: Fecha/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Dia,Hora")] Fecha fecha)
        {
            if (id != fecha.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(fecha);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FechaExists(fecha.ID))
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
            return View(fecha);
        }

        // GET: Fecha/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Fecha == null)
            {
                return NotFound();
            }

            var fecha = await _context.Fecha
                .FirstOrDefaultAsync(m => m.ID == id);
            if (fecha == null)
            {
                return NotFound();
            }

            return View(fecha);
        }

        // POST: Fecha/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Fecha == null)
            {
                return Problem("Entity set 'RestaurantDatabaseContext.Fecha'  is null.");
            }
            var fecha = await _context.Fecha.FindAsync(id);
            if (fecha != null)
            {
                _context.Fecha.Remove(fecha);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool FechaExists(int id)
        {
          return (_context.Fecha?.Any(e => e.ID == id)).GetValueOrDefault();
        }
    }
}
