using FysioAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FysioAPI.Domain.IRepos
{
    public interface ITreatmentRepository
    {
        Task<IEnumerable<VektisTreatment>> Get();
        Task<VektisTreatment> Get(string id);
    }
}
