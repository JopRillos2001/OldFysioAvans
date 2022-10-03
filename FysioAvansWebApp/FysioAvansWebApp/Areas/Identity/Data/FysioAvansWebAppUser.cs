using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace FysioAvansWebApp.Areas.Identity.Data
{
    // Add profile data for application users by adding properties to the FysioAvansWebAppUser class
    public class FysioAvansWebAppUser : IdentityUser
    {
        [PersonalData]
        [Column(TypeName = "int")]
        public int PersonId { get; set; }

        [PersonalData]
        [Column(TypeName = "int")]
        public int? PatientId { get; set; }

        [PersonalData]
        [Column(TypeName = "int")]
        public int? PhysiotherapistId { get; set; }

        [PersonalData]
        [Column(TypeName = "int")]
        public int AccounttypeId { get; set; }
    }
}
