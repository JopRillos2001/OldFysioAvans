using FysioAvansWebApp.Areas.Identity.Data;
using FysioAvansWebApp.Domain;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FysioAvansWebApp.Models
{
    public class AvailabilityDetailsViewModel
    {
        public IEnumerable<PatientDetailsViewModel> PatientFiles { get; set; }
        public IEnumerable<PhysiotherapistDetailsViewModel> Physios { get; set; }
        //Ids
        public int AvailabilityId { get; set; }
        [DataType(DataType.DateTime)]
        public DateTime StartAvailability { get; set; }
        [DataType(DataType.DateTime)]
        public DateTime EndAvailability { get; set; }
        public int EmployeeId { get; set; }        
        public string PhysioFirstname { get; set; }
        public string PhysioLastname { get; set; }
        public string error { get; set; }

    }
}
