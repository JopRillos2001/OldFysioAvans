using FysioAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FysioAPI.Domain.IRepos
{
    public interface IDiagnosisRepository
    {
        Task<IEnumerable<VektisDiagnosis>> Get();
        Task<VektisDiagnosis> Get(string id);
    }
}
