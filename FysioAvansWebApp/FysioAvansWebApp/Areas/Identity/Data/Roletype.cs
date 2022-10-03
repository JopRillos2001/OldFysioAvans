using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FysioAvansWebApp.Domain
{
    public class Roletype : BaseEntity
    {
        [StringLength(255)]
        [Display(Name = "RoletypeName")]
        public string RoletypeName { get; set; }
    }
}
