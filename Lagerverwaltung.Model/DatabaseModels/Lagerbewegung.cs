using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.Security.Principal;

namespace Lagerverwaltung.Model.DatabaseModels
{
    public class Lagerbewegung
    {
        [Key]
        public int LagerbewegungId { get; set; }

        [Display(Name = "Menge")]
        public int B_Menge { get; set; }


        public int LagerartikelId { get; set; }
        public virtual Lagerartikel Lagerartikel { get; set; }

        public int GeschäftsfallId { get; set; }
        public virtual Geschäftsfall Geschäftsfall { get; set; }

        public int VorgangsId { get; set; }
        public virtual Vorgangstyp Vorgangstyp { get; set; }
    }
}
