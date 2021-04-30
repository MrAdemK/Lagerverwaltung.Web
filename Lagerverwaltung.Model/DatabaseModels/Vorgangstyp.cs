using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lagerverwaltung.Model.DatabaseModels
{
    public class Vorgangstyp
    {
        [Key]
        public int VorgangsId { get; set; }
        
        [Required]
        [StringLength(7)]
        public string Vorgang { get; set; }


        /*public virtual ICollection<Lagerartikel> Lagerartikels { get; set; }*/
    }
}
