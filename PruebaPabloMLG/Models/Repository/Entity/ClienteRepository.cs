using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PruebaPabloTapia.Model.Repository.Entity
{
    public class ClienteRepository : ICRUD<Cliente>
    {
        readonly AppDbContext context;
        public ClienteRepository(AppDbContext context)
        {
            this.context = context;
        }

        [Obsolete]
        public List<Cliente> GetClienteConMasCompras()
        {
            var lista = context.Clientes.FromSql("upCliente").ToList();

            return lista;
        }

        public void Create(Cliente tipo)
        {
            context.Add(tipo);
            context.SaveChanges();
        }

        public void Delete(int id)
        {
            Cliente cliente = GetByID(id);
            context.Remove(cliente);
            context.SaveChanges();
        }

        public IQueryable<Cliente> GetAll()
        {
            return context.Clientes.Select(c => c);
        }

        public Cliente GetByID(int id)
        {
            return context.Clientes.FirstOrDefault(m => m.IdCliente == id);
        }

        public void Update(Cliente tipo)
        {
            context.Update(tipo);
            context.SaveChanges();
        }
    }
}
