using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Proyecto2.Models
{
    [Table("BOLETA")]
    public partial class Boleta
    {
        public Boleta()
        {
            Detalleboleta = new HashSet<Detalleboleta>();
        }

        [Key]
        [Column("NUM_BOL")]
        public int NumBol { get; set; }
        [Column("FEC_BOL", TypeName = "date")]
        public DateTime FecBol { get; set; }
        [Column("IDE_CLI")]
        public int IdeCli { get; set; }
        [Column("IDE_VEN")]
        public int IdeVen { get; set; }

        [ForeignKey("IdeCli")]
        [InverseProperty("Boleta")]
        public virtual Cliente IdeCliNavigation { get; set; } = null!;
        [ForeignKey("IdeVen")]
        [InverseProperty("Boleta")]
        public virtual Vendedor IdeVenNavigation { get; set; } = null!;
        [InverseProperty("NumBolNavigation")]
        public virtual ICollection<Detalleboleta> Detalleboleta { get; set; }
    }
}
