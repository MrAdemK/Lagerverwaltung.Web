using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lagerverwaltung.Model.DatabaseModels
{
    public class Lagerartikel
    {
        [Key]
        public int LagerartikelId { get; set; }
        
        [Required]
        [StringLength(100)]
        public string L_Bezeichnung { get; set; }
        
        public double L_Preis { get; set; }
        
        [BewegungValidation]
        public int Lagerstand { get; set; }
        
        [Required]
        [StringLength(5)]
        [Display(Name = "Mengeneinheit")]
        public string L_MengenEinheit { get; set; }
    }
}
