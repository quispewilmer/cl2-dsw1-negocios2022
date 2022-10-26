using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Proyecto1.Models
{
    [Table("VENDEDOR")]
    public partial class Vendedor
    {
        public Vendedor()
        {
            Boleta = new HashSet<Boleta>();
        }

        [Key]
        [Column("IDE_VEN")]
        public int IdeVen { get; set; }
        [Column("NOM_VEN")]
        [StringLength(30)]
        [Unicode(false)]
        public string NomVen { get; set; } = null!;
        [Column("APE_VEN")]
        [StringLength(30)]
        [Unicode(false)]
        public string ApeVen { get; set; } = null!;
        [Column("DIR_VEN")]
        [StringLength(50)]
        [Unicode(false)]
        public string? DirVen { get; set; }
        [Column("TEL_VEN")]
        [StringLength(15)]
        [Unicode(false)]
        public string? TelVen { get; set; }
        [Column("IDE_DIS")]
        public int IdeDis { get; set; }
        [Column("COR_VEN")]
        [StringLength(50)]
        [Unicode(false)]
        public string? CorVen { get; set; }
        [Column("SUE_VEN", TypeName = "money")]
        public decimal SueVen { get; set; }

        [ForeignKey("IdeDis")]
        [InverseProperty("Vendedor")]
        public virtual Distrito IdeDisNavigation { get; set; } = null!;
        [InverseProperty("IdeVenNavigation")]
        public virtual ICollection<Boleta> Boleta { get; set; }
    }
}
