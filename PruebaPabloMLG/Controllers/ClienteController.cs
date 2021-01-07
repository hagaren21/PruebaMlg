using Microsoft.AspNetCore.Mvc;
using PruebaPabloTapia.Bussiness;
using PruebaPabloTapia.Model;
using System.Collections.Generic;
using System.Linq;

namespace PruebaPabloMLG.Controllers
{
    public class ClienteController : Controller
    {
        ClienteService service;

        public ClienteController(AppDbContext context)
        {
            service = new ClienteService(context);
        }

        public IActionResult Index()
        {
            var listaClientes = service.ObtenerClientes().ToList();

            if (listaClientes != null)
                return View(listaClientes);

            return View(new List<Cliente>());
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            return View(service.LeerCliente(id));
        }

        [HttpPost]
        public IActionResult Delete(Cliente cliente)
        {
            if (service.BorrarCliente(cliente.IdCliente))
                return RedirectToAction("Index");

            return View(cliente);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View(new Cliente());
        }

        [HttpPost]
        public IActionResult Create(Cliente cliente)
        {
            if (service.CrearCliente(cliente))
            {
                return RedirectToAction("Index");
            }

            return View(cliente);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            return View(service.LeerCliente(id));
        }

        [HttpPost]
        public IActionResult Edit(Cliente cliente)
        {
            if (service.ActualizarCliente(cliente))
            {
                return RedirectToAction("Index");
            }

            return View(cliente);
        }
    }
}
