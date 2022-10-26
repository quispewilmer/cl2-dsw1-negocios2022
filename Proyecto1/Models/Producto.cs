using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Proyecto1.Models
{
    [Table("PRODUCTO")]
    public partial class Producto
    {
        public Producto()
        {
            Detalleboleta = new HashSet<Detalleboleta>();
        }

        [Key]
        [Column("IDE_PRO")]
        public int IdePro { get; set; }
        [Column("DES_PRO")]
        [StringLength(40)]
        [Unicode(false)]
        public string DesPro { get; set; } = null!;
        [Column("IDE_CAT")]
        public int IdeCat { get; set; }
        [Column("PRE_PRO", TypeName = "money")]
        public decimal PrePro { get; set; }
        [Column("STO_PRO")]
        public int StoPro { get; set; }
        [Column("IMG_PRO")]
        [StringLength(100)]
        [Unicode(false)]
        public string? ImgPro { get; set; }

        [ForeignKey("IdeCat")]
        [InverseProperty("Producto")]
        public virtual Categoria IdeCatNavigation { get; set; } = null!;
        [InverseProperty("IdeProNavigation")]
        public virtual ICollection<Detalleboleta> Detalleboleta { get; set; }
    }
}
