using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lagerverwaltung.Model.DatabaseModels
{
    public class Mitarbeiter
    {
        public int MitarbeiterId { get; set; }

        public string Username { get; set; }


        public virtual ICollection<Geschäftsfall> Geschäftsfalls { get; set; }
    }
}
