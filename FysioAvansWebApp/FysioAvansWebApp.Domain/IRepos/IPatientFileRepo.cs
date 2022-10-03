using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FysioAvansWebApp.Domain.Models
{
    public interface IPatientFileRepo
    {
        PatientFile GetOne(int Id);
        IEnumerable<PatientFile> GetAll();
        void Create(PatientFile roletype);
        void Update(PatientFile roletype);
        void Delete(int Id);
        void Save();
    }
}
