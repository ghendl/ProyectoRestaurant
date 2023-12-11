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


        [HttpGet]
        public IActionResult CrearMenu()
        {
            return View(new Menu()); //nos da un nuevo menu en lugar de una lista 
        }

        [HttpPost]
        public IActionResult CrearMenu(Menu nuevoMenu)
        {
            if (ModelState.IsValid)
            {
                // Lógica para agregar el nuevo menú a la base de datos
                _context.Menus.Add(nuevoMenu);
                _context.SaveChanges();

                TempData["SuccessMessage"] = "Menú agregado con éxito";

                // Redirige de nuevo a la vista "Menu" con el nuevo menú agregado
                return RedirectToAction("Menu");
            }

            // Si el modelo no es válido, vuelve a la vista de agregar menú para corregir los errores
            return View(nuevoMenu);
        }



        public IActionResult DeleteMenu(int id)
        {
            // Fetch the menu item from the database based on the ID
            var menu = _context.Menus.Find(id);

            if (menu == null)
            {
                // Handle the case where the menu item is not found
                return NotFound();
            }

            return View(menu);
        }


        [HttpPost]
        public IActionResult ConfirmDelete(int id)
        {
            var menu = _context.Menus.Find(id);

            if (menu == null)
            {
                // Handle the case where the menu item is not found
                return NotFound();
            }

            _context.Menus.Remove(menu);
            _context.SaveChanges();

            TempData["SuccessMessage"] = "El menu fue eliminado correctamente";

            return RedirectToAction("Menu");
        }
    }
}