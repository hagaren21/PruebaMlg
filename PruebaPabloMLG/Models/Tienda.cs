using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace PruebaPabloTapia.Model
{
    public partial class Tienda
    {
        public Tienda()
        {
            RelClienteTienda = new HashSet<RelClienteTiendum>();
        }

        [Key]
        public int IdTienda { get; set; }
        [StringLength(50)]
        public string Sucursal { get; set; }
        [StringLength(50)]
        public string Direccion { get; set; }

        [InverseProperty(nameof(RelClienteTiendum.IdTiendaNavigation))]
        public virtual ICollection<RelClienteTiendum> RelClienteTienda { get; set; }
    }
}
