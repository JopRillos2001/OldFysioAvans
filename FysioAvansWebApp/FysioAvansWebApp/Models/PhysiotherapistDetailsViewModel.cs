using FysioAvansWebApp.Areas.Identity.Data;
using FysioAvansWebApp.Domain;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FysioAvansWebApp.Models
{
    public class PhysiotherapistDetailsViewModel
    {
        //Ids
        public int PhysiotherapistId { get; set; }
        public int PersonId { get; set; }
        public int AccounttypeId { get; set; }
        public int RoletypeId { get; set; }
        //Person
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Fullname { get { return $"{this.Firstname} {this.Lastname}"; } }
        public string Phonenumber { get; set; }
        //Roletype
        public string RoletypeName { get; set; }
        //Accounttype
        public string AccounttypeName { get; set; }
        //Physiotherapist
        public string PhysiotherapistNumber { get; set; }        
        //User
        public string Email { get; set; }
        public string Password { get; set; }
        //Combined
        public string Combined { get { return $"{this.PhysiotherapistNumber} - {this.Fullname} - {this.RoletypeName}"; } }

    }
}
