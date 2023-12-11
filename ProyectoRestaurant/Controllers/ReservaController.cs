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
            string reservaErrorMessage = TempData["ErrorMessage"] as string;
            ViewBag.ReservaErrorMessage = reservaErrorMessage;

            string reservaExitosaMessage = TempData["SuccessMessage"] as string;
            ViewBag.ReservaExitosaMessage = reservaExitosaMessage;

            return View();
        }


        [HttpPost]
        public IActionResult Reservar(Reserva reserva)
        {
            if (MesaEstaOcupada(reserva.MesaNumero, reserva.Dia))
            {
                TempData["ErrorMessage"] = "Lo siento, la mesa ya está reservada en ese día. Por favor, elige otra mesa u otro día.";
                return RedirectToAction("Index");
            }

            if (ModelState.IsValid)
            {
                _context.Reservas.Add(reserva);
                _context.SaveChanges();
                TempData["SuccessMessage"] = "Se ha reservado su mesa correctamente!";
                return RedirectToAction("Index");
            }
            return View();

        }

        private bool MesaEstaOcupada(string mesa, DateTime dia)
        {

            var mesaOcupada = _context.Reservas.Any(r => r.MesaNumero == mesa && r.Dia == dia);

            return mesaOcupada;
        }
    }
}
