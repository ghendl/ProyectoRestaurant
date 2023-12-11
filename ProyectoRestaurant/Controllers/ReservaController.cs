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
    public class ReservaController : Controller
    {
        private readonly RestaurantDatabaseContext _context;

        public ReservaController(RestaurantDatabaseContext context)
        {
            _context = context;
        }

        // GET: Reservas
        public async Task<IActionResult> Index()
        {
            return View();
        }
    }
}
