using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FysioAvansWebApp.Domain
{
    public class TypeNotes : BaseEntity
    {
        [StringLength(255)]
        [Display(Name = "Notes")]
        public string Notes { get; set; }

        [DataType(DataType.DateTime)]
        [Display(Name = "Date")]
        public DateTime Date { get; set; }

        [Display(Name = "NotetakerId")]
        public int NotetakerId { get; set; }

        [Display(Name = "VisibleForPatient")]
        public bool VisibleForPatient { get; set; }
    }
}
