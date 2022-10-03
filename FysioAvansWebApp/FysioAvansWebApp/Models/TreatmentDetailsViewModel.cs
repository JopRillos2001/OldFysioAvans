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
    public class TreatmentDetailsViewModel
    {
        public IEnumerable<TypeNotes> TypeNotess { get; set; }
        public IEnumerable<VektisTreatment> VTreatments { get; set; }
        public IEnumerable<PatientDetailsViewModel> PatientFiles { get; set; }
        public IEnumerable<PhysiotherapistDetailsViewModel> Physios { get; set; }
        public IEnumerable<Treatment> Treatments { get; set; }
        public IEnumerable<TreatmentPlan> TreatmentPlans { get; set; }
        public IEnumerable<Availability> Availability { get; set; }
        //Ids
        public int TreatmentId { get; set; }
        public int TypeId { get; set; }
        public int TypeNotesId { get; set; }
        public string Description { get; set; }
        public string Room { get; set; }
        public int CaretakerId { get; set; }
        public DateTime TreatmentDate { get; set; }
        public int PatientFileId { get; set; }
        public int PatientId { get; set; }
        public string PatientFirstname { get; set; }
        public string PatientLastname { get; set; }
        public string CaretakerFirstname { get; set; }
        public string CaretakerLastname { get; set; }
        public string PatientDescription { get; set; }
        public string PatientFullname { get { return $"{this.PatientFirstname} {this.PatientLastname}"; } }
        public string CaretakerFullname { get { return $"{this.CaretakerFirstname} {this.CaretakerLastname}"; } }
        //TypeNotes
        public string Notes { get; set; }
        public DateTime Date { get; set; }
        public int NotetakerId { get; set; }
        public bool VisibleForPatient { get; set; }
        public string error { get; set; }

    }
}
