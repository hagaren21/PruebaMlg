using PruebaPabloTapia.Model;
using PruebaPabloTapia.Model.Repository;
using PruebaPabloTapia.Model.Repository.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PruebaPabloTapia.Bussiness
{
    public class TiendaService
    {
        readonly ICRUD<Tienda> repository;

        public TiendaService(AppDbContext appDbContext)
        {
            this.repository = new TiendaRepository(appDbContext);
        }

        public bool CrearTienda(Tienda tienda)
        {
            bool bandera = true;

            try
            {
                repository.Create(tienda);
            }
            catch (Exception ex)
            {
                bandera = false;
            }

            return bandera;
        }

        public bool ActualizarTienda(Tienda tienda)
        {
            bool bandera = true;

            try
            {
                repository.Update(tienda);
            }
            catch (Exception ex)
            {
                bandera = false;
            }

            return bandera;
        }

        public bool BorrarTienda(int id)
        {
            bool bandera = true;

            try
            {
                repository.Delete(id);
            }
            catch (Exception ex)
            {
                bandera = false;
            }

            return bandera;
        }

        public Tienda LeerTienda(int id)
        {
            Tienda tienda = repository.GetByID(id);

            if (tienda == null)
            {
                return new Tienda();
            }

            return tienda;
        }

        public IQueryable<Tienda> ObtenerTiendas()
        {
            return repository.GetAll();
        }
    }
}
