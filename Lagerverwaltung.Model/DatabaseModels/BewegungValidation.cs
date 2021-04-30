using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lagerverwaltung.Model.DatabaseModels
{
    public class BewegungValidation : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var bestand = (Lagerartikel) validationContext.ObjectInstance;

            if (bestand.Lagerstand >= 0)
            {
                return ValidationResult.Success;
            }
            else
            {
                return new ValidationResult("Bestand darf nicht unter null sein");
            }
        }
    }
}
