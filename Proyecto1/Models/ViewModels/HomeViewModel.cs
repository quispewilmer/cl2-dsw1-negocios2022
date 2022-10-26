using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Proyecto1.Models.ViewModels
{
    public class HomeViewModel
    {
        [JsonInclude]
        [Display(Name = "Id")]
        public int IdePro { get; set; }
        [JsonInclude]
        [Display(Name = "Descripción")]
        public string DesPro { get; set; } = null!;
        [JsonInclude]
        [Display(Name = "Categoría")]
        public int IdeCat { get; set; }
        [JsonInclude]
        [Display(Name = "Precio")]
        public decimal PrePro { get; set; }
        [JsonInclude]
        [Display(Name = "Stock")]
        public int StoPro { get; set; }
        [JsonInclude]
        [Display(Name = "Imagen")]
        public string? ImgPro { get; set; }
        [JsonInclude]
        [Display(Name = "Cantidad")]
        public int Cant { get; set; }
    }
}
