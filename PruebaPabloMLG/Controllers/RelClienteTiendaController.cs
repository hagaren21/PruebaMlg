using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using PruebaPabloTapia.Bussiness;
using PruebaPabloTapia.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PruebaPabloMLG.Controllers
{
    public class RelClienteTiendaController : Controller
    {
        RelClienteTiendumService service;
        ClienteService clienteService;
        TiendaService tiendaService;
        public RelClienteTiendaController(AppDbContext context)
        {
            service = new RelClienteTiendumService(context);
            clienteService = new ClienteService(context);
            tiendaService = new TiendaService(context);
        }

        [Obsolete]
        public IActionResult ClienteConMasCompras()
        {
            var clienteMasCompras = clienteService.ObtenerClienteConMasCompras();

            if(clienteMasCompras==null)
            {
                return View(new List<Cliente>());
            }

            return View(clienteMasCompras);
        }

        public IActionResult Index()
        {
            var listaRelaciones = service.ObtenerRelClienteTiendums().ToList();
                        
            if (listaRelaciones != null)
                return View(listaRelaciones);

            return View(new List<RelClienteTiendum>());
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            return View(service.LeerRelClienteTiendum(id));
        }

        [HttpPost]
        public IActionResult Delete(RelClienteTiendum rel)
        {
            if (service.BorrarRelClienteTiendum(rel.IdRelacion))
                return RedirectToAction("Index");

            return View(rel);
        }

        [HttpGet]
        public IActionResult Create()
        {
            var listaClientes = clienteService.ObtenerClientes().Select(s =>
            new
            {
                IdCliente = s.IdCliente,
                Descripcion = string.Format("{0} - {1}", s.IdCliente, s.Nombre + " " + s.Apellidos)
            }
            );

            ViewData["IdCliente"] = new SelectList(listaClientes, "IdCliente", "Descripcion");
            ViewData["IdTienda"] = new SelectList(tiendaService.ObtenerTiendas(), "IdTienda", "Sucursal");

            return View(new RelClienteTiendum());
        }

        [HttpPost]
        public IActionResult Create([Bind("IdRelacion,IdCliente,IdTienda,Monto,Fecha")] RelClienteTiendum rel)
        {
            if (service.CrearRelClienteTiendum(rel))
            {
                return RedirectToAction("Index");
            }

            var listaClientes = clienteService.ObtenerClientes().Select(s =>
            new
            {
                IdCliente = s.IdCliente,
                Descripcion = string.Format("{0} - {1}", s.IdCliente, s.Nombre + " " + s.Apellidos)
            }
            );

            ViewData["IdCliente"] = new SelectList(listaClientes, "IdCliente", "Descripcion");
            ViewData["IdTienda"] = new SelectList(tiendaService.ObtenerTiendas(), "IdTienda", "Sucursal", rel.IdTienda);

            return View(rel);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var rel = service.LeerRelClienteTiendum(id);

            var listaClientes = clienteService.ObtenerClientes().Select(s =>
            new
            {
                IdCliente = s.IdCliente,
                Descripcion = string.Format("{0} - {1}", s.IdCliente, s.Nombre + " " + s.Apellidos)
            }
            );

            ViewData["IdCliente"] = new SelectList(listaClientes, "IdCliente", "Descripcion");
            ViewData["IdTienda"] = new SelectList(tiendaService.ObtenerTiendas(), "IdTienda", "Sucursal", rel.IdTienda);

            return View(rel);
        }

        [HttpPost]
        public IActionResult Edit(RelClienteTiendum rel)
        {
            if (service.ActualizarRelClienteTiendum(rel))
            {
                return RedirectToAction("Index");
            }

            var listaClientes = clienteService.ObtenerClientes().Select(s =>
            new
            {
                IdCliente = s.IdCliente,
                Descripcion = string.Format("{0} - {1}", s.IdCliente, s.Nombre + " " + s.Apellidos)
            }
            );

            ViewData["IdCliente"] = new SelectList(listaClientes, "IdCliente", "Descripcion");
            ViewData["IdTienda"] = new SelectList(tiendaService.ObtenerTiendas(), "IdTienda", "Sucursal", rel.IdTienda);
            return View(rel);
        }
    }
}
