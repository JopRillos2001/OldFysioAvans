using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FysioAvansWebApp.Domain
{
    public class Treatment : BaseEntity
    {
        [Display(Name = "TypeId")]
        public int TypeId { get; set; }

        [Display(Name = "TypeNotesId")]
        public int TypeNotesId { get; set; }

        [StringLength(255)]
        [Display(Name = "Description")]
        public string Description { get; set; }

        [StringLength(255)]
        [Display(Name = "Room")]
        public string Room { get; set; }

        [StringLength(255)]
        [Display(Name = "Notes")]
        public string Notes { get; set; }

        [Display(Name = "CaretakerId")]
        public int CaretakerId { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "TreatmentDate")]
        public DateTime TreatmentDate { get; set; }

        [Display(Name = "PatientFileId")]
        public int PatientFileId { get; set; }
    }
}
