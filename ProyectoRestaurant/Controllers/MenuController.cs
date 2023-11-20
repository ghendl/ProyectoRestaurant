using Microsoft.AspNetCore.Mvc;

namespace ProyectoRestaurant.Controllers
{
    public class MenuController : Controller
    {
        public IActionResult Menu()
        {
            return View();
        }
    }
}
