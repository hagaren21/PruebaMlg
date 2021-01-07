using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PruebaPabloTapia.Model.Repository
{
    public interface ICRUD<Tipo>
    {
        void Create(Tipo tipo);
        void Update(Tipo tipo);
        void Delete(int id);
        Tipo GetByID(int id);
        IQueryable<Tipo> GetAll();
    }
}
