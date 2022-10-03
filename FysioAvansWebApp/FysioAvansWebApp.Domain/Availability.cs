using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FysioAvansWebApp.Domain
{
    public class Availability : BaseEntity
    {
        [DataType(DataType.DateTime)]
        [Display(Name = "StartAvailable")]
        public DateTime StartAvailable { get; set; }

        [DataType(DataType.DateTime)]
        [Display(Name = "EndAvailable")]
        public DateTime EndAvailable { get; set; }

        [Display(Name = "EmployeeId")]
        public int EmployeeId { get; set; }
    }
}
