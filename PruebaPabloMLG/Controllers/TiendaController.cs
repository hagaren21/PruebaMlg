using Microsoft.AspNetCore.Mvc;
using PruebaPabloTapia.Bussiness;
using PruebaPabloTapia.Model;
using System.Collections.Generic;
using System.Linq;

namespace PruebaPabloTapia.Controllers
{
    public class TiendaController : Controller
    {
        readonly TiendaService service;

        public TiendaController(AppDbContext context)
        {
            service = new TiendaService(context);
        }

        public IActionResult Index()
        {
            var listaTiendas = service.ObtenerTiendas().ToList();

            if (listaTiendas != null)
                return View(listaTiendas);

            return View(new List<Tienda>());
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            return View(service.LeerTienda(id));
        }

        [HttpPost]
        public IActionResult Delete(Tienda tienda)
        {
            if (service.BorrarTienda(tienda.IdTienda))
                return RedirectToAction("Index");

            return View(tienda);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View(new Tienda());
        }

        [HttpPost]
        public IActionResult Create(Tienda tienda)
        {
            if(service.CrearTienda(tienda))
            {
                return RedirectToAction("Index");
            }

            return View(tienda);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            return View(service.LeerTienda(id));
        }

        [HttpPost]
        public IActionResult Edit(Tienda tienda)
        {
            if(service.ActualizarTienda(tienda))
            {
                return RedirectToAction("Index");
            }

            return View(tienda);
        }
    }
}
