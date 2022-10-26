using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Proyecto2.Models
{
    [Table("DISTRITO")]
    public partial class Distrito
    {
        public Distrito()
        {
            Cliente = new HashSet<Cliente>();
            Vendedor = new HashSet<Vendedor>();
        }

        [Key]
        [Column("IDE_DIS")]
        public int IdeDis { get; set; }
        [Column("DES_DIS")]
        [StringLength(50)]
        [Unicode(false)]
        public string? DesDis { get; set; }

        [InverseProperty("IdeDisNavigation")]
        public virtual ICollection<Cliente> Cliente { get; set; }
        [InverseProperty("IdeDisNavigation")]
        public virtual ICollection<Vendedor> Vendedor { get; set; }
    }
}
