using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FysioAvansWebApp.Domain
{
    public class Patient : BaseEntity
    {
        [StringLength(255)]
        [Display(Name = "PatientNumber")]
        public string PatientNumber { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "Birthdate")]
        public DateTime Birthdate { get; set; }

        [StringLength(255)]
        [Display(Name = "Photo")]
        public string Photo { get; set; }

        [StringLength(255)]
        [Display(Name = "Gender")]
        public string Gender { get; set; }
    }
}
