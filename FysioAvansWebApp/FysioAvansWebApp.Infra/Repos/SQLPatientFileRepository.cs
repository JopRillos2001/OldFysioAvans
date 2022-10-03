using FysioAvansWebApp.Domain;
using FysioAvansWebApp.Domain.Models;
using FysioAvansWebApp.Infra;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FysioAvansWebApp.Models.Repo
{
    public class SQLPatientFileRepository : IPatientFileRepo
    {
        private readonly FysioDbContext _db;

        public SQLPatientFileRepository(FysioDbContext db) {
            _db = db;
        }

        public void Create(PatientFile patientFile)
        {
            _db.PatientFiles.Add(patientFile);
        }

        public void Delete(int Id)
        {
            PatientFile patientFile = _db.PatientFiles.Find(Id);
            _db.PatientFiles.Remove(patientFile);
        }

        public IEnumerable<PatientFile> GetAll()
        {
            return _db.PatientFiles.ToList();
        }

        public PatientFile GetOne(int Id)
        {
            return _db.PatientFiles.Find(Id);
        }

        public void Save()
        {
            _db.SaveChanges();
        }

        public void Update(PatientFile patientFile)
        {
            _db.Entry(patientFile).State = EntityState.Modified;
        }
    }
}
