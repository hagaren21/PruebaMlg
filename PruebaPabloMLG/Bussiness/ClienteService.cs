using PruebaPabloTapia.Model;
using PruebaPabloTapia.Model.Repository;
using PruebaPabloTapia.Model.Repository.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PruebaPabloTapia.Bussiness
{
    public class ClienteService
    {
        ICRUD<Cliente> repository;

        public ClienteService(AppDbContext appDbContext)
        {
            this.repository = new ClienteRepository(appDbContext);
        }

        [Obsolete]
        public List<Cliente> ObtenerClienteConMasCompras()
        {
            var cliente = ((ClienteRepository)repository).GetClienteConMasCompras();

            return cliente;
        }

        public bool CrearCliente(Cliente cliente)
        {
            bool bandera = true;

            try
            {
                repository.Create(cliente);
            }
            catch (Exception ex)
            {
                bandera = false;
            }

            return bandera;
        }

        public bool ActualizarCliente(Cliente cliente)
        {
            bool bandera = true;

            try
            {
                repository.Update(cliente);
            }
            catch (Exception ex)
            {
                bandera = false;
            }

            return bandera;
        }

        public bool BorrarCliente(int id)
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

        public Cliente LeerCliente(int id)
        {
            Cliente cliente = repository.GetByID(id);

            if (cliente == null)
            {
                return new Cliente();
            }

            return cliente;
        }

        public IQueryable<Cliente> ObtenerClientes()
        {
            return repository.GetAll();
        }
    }
}
