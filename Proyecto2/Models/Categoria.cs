using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Proyecto2.Models
{
    [Table("CATEGORIA")]
    public partial class Categoria
    {
        public Categoria()
        {
            Producto = new HashSet<Producto>();
        }

        [Key]
        [Column("IDE_CAT")]
        public int IdeCat { get; set; }
        [Column("DES_CAT")]
        [StringLength(35)]
        [Unicode(false)]
        public string DesCat { get; set; } = null!;

        [InverseProperty("IdeCatNavigation")]
        public virtual ICollection<Producto> Producto { get; set; }
    }
}
