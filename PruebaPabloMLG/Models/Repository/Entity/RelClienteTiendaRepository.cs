using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace PruebaPabloTapia.Model.Repository.Entity
{
    public class RelClienteTiendaRepository : ICRUD<RelClienteTiendum>
    {
        readonly AppDbContext context;
        public RelClienteTiendaRepository(AppDbContext context)
        {
            this.context = context;
        }

        public void Create(RelClienteTiendum tipo)
        {
            context.Add(tipo);
            context.SaveChanges();
        }

        public void Delete(int id)
        {
            RelClienteTiendum relacion = GetByID(id);
            context.Remove(relacion);
            context.SaveChanges();
        }

        public IQueryable<RelClienteTiendum> GetAll()
        {
            return context.RelClienteTienda.Select(c => c).Include(r => r.IdClienteNavigation).Include(r => r.IdTiendaNavigation);
        }

        public RelClienteTiendum GetByID(int id)
        {
            return context.RelClienteTienda.Include(r => r.IdClienteNavigation).Include(r => r.IdTiendaNavigation).FirstOrDefault(m => m.IdTienda == id);
        }

        public void Update(RelClienteTiendum tipo)
        {
            context.Update(tipo);
            context.SaveChanges();
        }
    }
}
