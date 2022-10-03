using FysioAPI.Domain.IRepos;
using FysioAPI.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FysioAPI.Infra.Repos
{
    public class SQLVektisDiagnosisRepo : IDiagnosisRepository
    {
        private readonly FysioAPIDbContext _db;

        public SQLVektisDiagnosisRepo(FysioAPIDbContext db) {
            _db = db;
        }

        public async Task<IEnumerable<VektisDiagnosis>> Get()
        {
            return await _db.VektisDiagnoses.ToListAsync();
        }

        public async Task<VektisDiagnosis> Get(string id)
        {
            return await _db.VektisDiagnoses.FindAsync(id);
        }
    }
}
