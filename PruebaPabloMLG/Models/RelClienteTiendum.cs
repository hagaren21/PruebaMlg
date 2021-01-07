using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace PruebaPabloTapia.Model
{
    public partial class RelClienteTiendum
    {
        [Key]
        public int IdRelacion { get; set; }
        public int? IdCliente { get; set; }
        public int? IdTienda { get; set; }
        [Column(TypeName = "money")]
        public decimal? Monto { get; set; }
        [Column(TypeName = "date")]
        public DateTime? Fecha { get; set; }

        [ForeignKey(nameof(IdCliente))]
        [InverseProperty(nameof(Cliente.RelClienteTienda))]
        public virtual Cliente IdClienteNavigation { get; set; }
        [ForeignKey(nameof(IdTienda))]
        [InverseProperty(nameof(Tienda.RelClienteTienda))]
        public virtual Tienda IdTiendaNavigation { get; set; }
    }
}
