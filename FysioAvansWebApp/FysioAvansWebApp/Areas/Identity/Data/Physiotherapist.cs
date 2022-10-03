using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FysioAvansWebApp.Domain
{
    public class Physiotherapist : BaseEntity
    {
        [StringLength(255)]
        [Display(Name = "PhysiotherapistNumber")]
        public string PhysiotherapistNumber { get; set; }
    }
}
