using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Proyecto1.Models
{
    [Table("DETALLEBOLETA")]
    public partial class Detalleboleta
    {
        [Key]
        [Column("NUM_BOL")]
        public int NumBol { get; set; }
        [Key]
        [Column("IDE_PRO")]
        public int IdePro { get; set; }
        [Column("CAN_ART")]
        public int CanArt { get; set; }

        [ForeignKey("IdePro")]
        [InverseProperty("Detalleboleta")]
        public virtual Producto IdeProNavigation { get; set; } = null!;
        [ForeignKey("NumBol")]
        [InverseProperty("Detalleboleta")]
        public virtual Boleta NumBolNavigation { get; set; } = null!;
    }
}
