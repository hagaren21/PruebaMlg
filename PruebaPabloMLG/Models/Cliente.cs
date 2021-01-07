using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace PruebaPabloTapia.Model
{
    public partial class Cliente
    {
        public Cliente()
        {
            RelClienteTienda = new HashSet<RelClienteTiendum>();
        }

        [Key]
        public int IdCliente { get; set; }
        [StringLength(50)]
        public string Nombre { get; set; }
        [StringLength(50)]
        public string Apellidos { get; set; }
        [StringLength(50)]
        public string Direccion { get; set; }

        [InverseProperty(nameof(RelClienteTiendum.IdClienteNavigation))]
        public virtual ICollection<RelClienteTiendum> RelClienteTienda { get; set; }
    }
}
