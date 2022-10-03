using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FysioAvansWebApp.Domain
{
    public class PatientFile : BaseEntity
    {
        [Display(Name = "PatientId")]
        public int PatientId { get; set; }

        [StringLength(255)]
        [Display(Name = "Description")]
        public string Description { get; set; }

        [Display(Name = "DiagnosisCode")]
        public int DiagnosisCode { get; set; }

        [Display(Name = "EmployeeId")]
        public int EmployeeId { get; set; }

        [Display(Name = "IntakeEmployeeId")]
        public int IntakeEmployeeId { get; set; }

        [Display(Name = "SupervisorId")]
        public int SupervisorId { get; set; }

        [Display(Name = "CaretakerId")]
        public int CaretakerId { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "RegisterDate")]
        public DateTime RegisterDate { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "ReleaseDate")]
        public DateTime ReleaseDate { get; set; }

        [StringLength(255)]
        [Display(Name = "Notes")]
        public string Notes { get; set; }

        [Display(Name = "TreatmentPlanId")]
        public int TreatmentPlanId { get; set; }

        [StringLength(255)]
        [Display(Name = "Treatments")]
        public string Treatments { get; set; }
    }
}
