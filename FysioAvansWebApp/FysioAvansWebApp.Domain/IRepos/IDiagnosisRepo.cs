using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FysioAvansWebApp.Domain.Models
{
    public interface IDiagnosisRepo
    {
        //async Task<VektisDiagnosis> GetOne(string Id);
        Task<IEnumerable<VektisDiagnosis>> GetDiagnosesAsync();
    }
}
