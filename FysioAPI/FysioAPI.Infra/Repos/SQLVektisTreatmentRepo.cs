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
    public class SQLVektisTreatmentRepo : ITreatmentRepository
    {
        private readonly FysioAPIDbContext _db;

        public SQLVektisTreatmentRepo(FysioAPIDbContext db)
        {
            _db = db;
        }

        public async Task<IEnumerable<VektisTreatment>> Get()
        {
            return await _db.VektisTreatments.ToListAsync();
        }

        public async Task<VektisTreatment> Get(string id)
        {
            return await _db.VektisTreatments.FindAsync(id);
        }
    }
}
