using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lagerverwaltung.Model.DatabaseModels
{
    public class Geschäftsfall
    {
        [Key]
        public int GeschäftsfallId { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? Datum { get; set; }


        public int MitarbeiterId { get; set; }
        public virtual Mitarbeiter Mitarbeiter { get; set; }
    }
}
