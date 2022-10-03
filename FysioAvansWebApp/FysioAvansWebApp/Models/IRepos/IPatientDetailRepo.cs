using FysioAvansWebApp.Areas.Identity.Data;
using FysioAvansWebApp.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FysioAvansWebApp.Domain.Models
{
    public interface IPatientDetailRepo
    {
        PatientDetailsViewModel GetOne(int Id);
        IEnumerable<PatientDetailsViewModel> GetAll();
        Task<PatientDetailsViewModel> GetPeeps();
        Task<PatientDetailsViewModel> GetOnePeeps(int id);
        void Create(PatientDetailsViewModel patientDetailsViewModel);
        void Update(PatientDetailsViewModel patientDetailsViewModel);
        void Delete(int id);
    }
}
