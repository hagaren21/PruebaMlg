using PruebaPabloTapia.Model;
using PruebaPabloTapia.Model.Repository;
using PruebaPabloTapia.Model.Repository.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PruebaPabloTapia.Bussiness
{
    public class RelClienteTiendumService
    {
        ICRUD<RelClienteTiendum> repository;

        public RelClienteTiendumService(AppDbContext appDbContext)
        {
            this.repository = new RelClienteTiendaRepository(appDbContext);
        }

        public bool CrearRelClienteTiendum(RelClienteTiendum relClienteTiendum)
        {
            bool bandera = true;

            try
            {
                repository.Create(relClienteTiendum);
            }
            catch (Exception ex)
            {
                bandera = false;
            }

            return bandera;
        }

        public bool ActualizarRelClienteTiendum(RelClienteTiendum relClienteTiendum)
        {
            bool bandera = true;

            try
            {
                repository.Update(relClienteTiendum);
            }
            catch (Exception ex)
            {
                bandera = false;
            }

            return bandera;
        }

        public bool BorrarRelClienteTiendum(int id)
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

        public RelClienteTiendum LeerRelClienteTiendum(int id)
        {
            RelClienteTiendum relClienteTiendum = repository.GetByID(id);

            if (relClienteTiendum == null)
            {
                return new RelClienteTiendum();
            }

            return relClienteTiendum;
        }

        public IQueryable<RelClienteTiendum> ObtenerRelClienteTiendums()
        {
            return repository.GetAll();
        }
    }
}
