using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FysioAvansWebApp.Domain
{
    public class Accounttype : BaseEntity
    {
        [StringLength(255)]
        [Display(Name = "AccounttypeName")]
        public string AccounttypeName { get; set; }
    }
}
