using FysioAvansWebApp.Areas.Identity.Data;
using FysioAvansWebApp.Domain;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FysioAvansWebApp.Models
{
    public class PatientDetailsViewModel
    {
        public IEnumerable<Person> Persons { get; set; }
        public IEnumerable<VektisDiagnosis> Diagnoses { get; set; }
        public IEnumerable<PhysiotherapistDetailsViewModel> PhysiotherapistDetails { get; set; }
        public IEnumerable<PhysiotherapistDetailsViewModel> TeacherPhysiotherapistDetails { get; set; }        
        //Ids
        public int PatientId { get; set; }
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
        //Patient
        public string PatientNumber { get; set; }
        public string Photo { get; set; }
        public IFormFile File { get; set; }
        public string Gender { get; set; }
        public DateTime Birthdate { get; set; }
        //Patientfile
        public int PatientFileId { get; set; }
        public string PatientDescription { get; set; }
        public int DiagnosisCode { get; set; }
        public int EmployeeId { get; set; }
        public int IntakeEmployeeId { get; set; }
        public int SupervisorId { get; set; }
        public int CaretakerId { get; set; }
        public DateTime RegisterDate { get; set; }
        public DateTime ReleaseDate { get; set; }
        public string Notes { get; set; }
        public int TreatmentPlanId { get; set; }
        public string Treatments { get; set; }        
        //TreatmentPlan
        public int TreatmentsPerWeek { get; set; }
        public int SessionLength { get; set; }
        //User
        public string UserId { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        //Combined
        public string PatientFileSet { get { return $"{this.Fullname} - {this.Email} - {this.PatientDescription}"; } }
        public string Pat { get { return $"{this.Firstname} {this.Lastname} - {this.PatientDescription}"; } }
        public string error { get; set; }
    }
}
