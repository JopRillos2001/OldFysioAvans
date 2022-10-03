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
    public interface ITreatmentDetailRepo
    {
        TreatmentDetailsViewModel GetOne(int Id);
        IEnumerable<TreatmentDetailsViewModel> GetAll();
        Task<TreatmentDetailsViewModel> GetExtraDataTables();
        Task<TreatmentDetailsViewModel> GetExtraDataTable(int id);
        void Create(TreatmentDetailsViewModel treatmentsDetailsViewModel);
        void Update(TreatmentDetailsViewModel treatmentsDetailsViewModel);
        void Delete(int id);
    }
}
