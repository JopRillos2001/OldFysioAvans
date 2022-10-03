using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FysioAvansWebApp.Domain
{
    public class Person : BaseEntity
    {
        [StringLength(255)]
        [Display(Name = "Firstname")]
        public string Firstname { get; set; }

        [StringLength(255)]
        [Display(Name = "Lastname")]
        public string Lastname { get; set; }

        [NotMapped]
        public string Fullname { get { return this.Firstname + " " + this.Lastname; } }

        [StringLength(255)]
        [Display(Name = "Phonenumber")]
        public string Phonenumber { get; set; }

        [Display(Name = "RoletypeId")]
        public int RoletypeId { get; set; }

        [StringLength(255)]
        [Display(Name = "RoletypeNumber")]
        public string RoletypeNumber { get; set; }
    }
}
