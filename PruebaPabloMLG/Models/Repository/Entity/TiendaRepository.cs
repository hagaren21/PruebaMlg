using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PruebaPabloTapia.Model.Repository.Entity
{
    public class TiendaRepository : ICRUD<Tienda>
    {
        readonly AppDbContext context;
        public TiendaRepository(AppDbContext context)
        {
            this.context = context;
        }

        public void Create(Tienda tipo)
        {
            context.Add(tipo);
            context.SaveChanges();
        }

        public void Delete(int id)
        {
            Tienda tienda = GetByID(id);
            context.Remove(tienda);
            context.SaveChanges();
        }

        public IQueryable<Tienda> GetAll()
        {
            return context.Tiendas.Select(c => c);
        }

        public Tienda GetByID(int id)
        {
            return context.Tiendas.FirstOrDefault(m => m.IdTienda == id);
        }

        public void Update(Tienda tipo)
        {
            context.Update(tipo);
            context.SaveChanges();
        }
    }
}
