using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FysioAvansWebApp.Domain.Models
{
    public interface IVTreatmentRepo
    {
        //async Task<VektisDiagnosis> GetOne(string Id);
        Task<IEnumerable<VektisTreatment>> GetVTreatmentsAsync();
    }
}
