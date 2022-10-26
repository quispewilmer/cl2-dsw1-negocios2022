using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Proyecto2.Models
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
        [Display(Name = "Id")]
        public int IdeVen { get; set; }
        [Column("NOM_VEN")]
        [StringLength(30)]
        [Unicode(false)]
        [Display(Name = "Nombre")]
        public string NomVen { get; set; } = null!;
        [Column("APE_VEN")]
        [StringLength(30)]
        [Unicode(false)]
        [Display(Name = "Apellido")]
        public string ApeVen { get; set; } = null!;
        [Column("DIR_VEN")]
        [StringLength(50)]
        [Unicode(false)]
        [Display(Name = "Dirección")]
        public string? DirVen { get; set; }
        [Column("TEL_VEN")]
        [StringLength(15)]
        [Unicode(false)]
        [Display(Name = "Teléfono")]
        public string? TelVen { get; set; }
        [Column("IDE_DIS")]
        [Display(Name = "Distrito")]
        public int IdeDis { get; set; }
        [Column("COR_VEN")]
        [StringLength(50)]
        [Unicode(false)]
        [Display(Name = "Correo")]
        public string? CorVen { get; set; }
        [Column("SUE_VEN", TypeName = "money")]
        [Display(Name = "Sueldo")]
        public decimal SueVen { get; set; }

        [ForeignKey("IdeDis")]
        [InverseProperty("Vendedor")]
        public virtual Distrito IdeDisNavigation { get; set; } = null!;
        [InverseProperty("IdeVenNavigation")]
        public virtual ICollection<Boleta> Boleta { get; set; }
    }
}
