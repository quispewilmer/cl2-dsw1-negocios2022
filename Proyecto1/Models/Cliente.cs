using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Proyecto1.Models
{
    [Table("CLIENTE")]
    public partial class Cliente
    {
        public Cliente()
        {
            Boleta = new HashSet<Boleta>();
        }

        [Key]
        [Column("IDE_CLI")]
        public int IdeCli { get; set; }
        [Column("NOM_CLI")]
        [StringLength(50)]
        [Unicode(false)]
        public string NomCli { get; set; } = null!;
        [Column("MOV_CLI")]
        [StringLength(15)]
        [Unicode(false)]
        public string? MovCli { get; set; }
        [Column("IDE_DIS")]
        public int IdeDis { get; set; }
        [Column("COR_CLI")]
        [StringLength(50)]
        [Unicode(false)]
        public string? CorCli { get; set; }

        [ForeignKey("IdeDis")]
        [InverseProperty("Cliente")]
        public virtual Distrito IdeDisNavigation { get; set; } = null!;
        [InverseProperty("IdeCliNavigation")]
        public virtual ICollection<Boleta> Boleta { get; set; }
    }
}
