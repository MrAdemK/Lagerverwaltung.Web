using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lagerverwaltung.Model.ViewModels
{
    public class SelectListItemVM
    {
        [Key]
        public string ValueMember { get; set; }

        public string DisplayMember { get; set; }
    }
}
