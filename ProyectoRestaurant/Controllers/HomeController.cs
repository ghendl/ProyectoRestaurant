using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProyectoRestaurant.Context;
using ProyectoRestaurant.Models;
using System.Diagnostics;

namespace ProyectoRestaurant.Controllers
{
    public class HomeController : Controller
    {
        private readonly RestaurantDatabaseContext _context;

        public HomeController(RestaurantDatabaseContext context)
        {
            _context = context;
        }


        public async Task<IActionResult> Menu()
        {
            if (TempData.ContainsKey("SuccessMessage"))
            {
                ViewBag.SuccessMessage = TempData["SuccessMessage"].ToString();
            }
            var menus = await _context.Menus.ToListAsync();

            return menus != null ?
                        View(menus) :
                        Problem("La lista de menús es null.");
        }

        [HttpPost]
        public IActionResult UpdatePrice(Menu menu)
        {
            // Actualiza el precio en la base de datos
            if (ModelState.IsValid)
            {
                var existingMenu = _context.Menus.Find(menu.ID);
                if (existingMenu != null)
                {
                    // Actualiza solo las propiedades relevantes
                    existingMenu.Precio = menu.Precio;
                    _context.SaveChanges();

                    TempData["SuccessMessage"] = "Precio modificado con éxito"; //tempdata es un diccionario que persiste entre acciones
                }
            }

            // Redirige de nuevo a la vista de edición
            return RedirectToAction("Menu");
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}