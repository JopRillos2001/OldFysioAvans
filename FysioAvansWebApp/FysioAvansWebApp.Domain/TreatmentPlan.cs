using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FysioAvansWebApp.Domain
{
    public class TreatmentPlan : BaseEntity
    {
        [Display(Name = "TreatmentsPerWeek")]
        public int TreatmentsPerWeek { get; set; }

        [Display(Name = "SessionLengthInMinutes")]
        public int SessionLength { get; set; }
    }
}
