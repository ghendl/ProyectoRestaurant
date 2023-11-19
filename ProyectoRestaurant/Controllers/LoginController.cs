using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using System.Threading.Tasks;
using ProyectoRestaurant.Context;

namespace ProyectoRestaurant.Controllers
{
    public class LoginController : Controller
    {

        private readonly RestaurantDatabaseContext _context;

        public LoginController(RestaurantDatabaseContext context)
        {
            _context = context;
        }


        public IActionResult login()
        {
            return View();
        }


        [HttpPost]
        public async Task<IActionResult> Login(string nombre, string clave)
        {
            var usuario = await _context.Usuarios.SingleOrDefaultAsync(u => u.Nombre == nombre && u.password == clave);

            if (usuario != null)
            {
                var claims = new[]
                {
                new Claim(ClaimTypes.Name, usuario.Nombre)
                // Puedes agregar más claims según sea necesario
            };

                var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

                await HttpContext.SignInAsync(new ClaimsPrincipal(claimsIdentity));

                return RedirectToAction("Privacy", "Home");
            }
            else
            {
                // Agrega un mensaje de error solo si hay un intento de inicio de sesión fallido
                TempData["ErrorMessage"] = "Error en el login. Verifica tus credenciales.";
            }

            // Retén el valor en TempData solo si hay un intento de inicio de sesión fallido
            if (ModelState.IsValid)
            {
                TempData.Keep("ErrorMessage");
            }

            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Index", "Home");
        }
    }
}