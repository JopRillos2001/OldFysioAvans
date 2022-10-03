using FysioAvansWebApp.Areas.Identity.Data;
using FysioAvansWebApp.Data;
using FysioAvansWebApp.Domain;
using FysioAvansWebApp.Domain.Models;
using FysioAvansWebApp.Infra;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace FysioAvansWebApp.Models.Repo
{
    public class SQLTreatmentDetailRepository : ITreatmentDetailRepo
    {
        private readonly AuthDbFysioAvansWebAppContext _db;
        private readonly FysioDbContext _fdb;
        private readonly IVTreatmentRepo _api;
        private readonly IPatientDetailRepo _pat;
        private readonly IPhysiotherapistDetailRepo _phy;
        private readonly IWebHostEnvironment _web;
        private readonly IHostingEnvironment _env;

        public SQLTreatmentDetailRepository(AuthDbFysioAvansWebAppContext db, FysioDbContext fdb, IWebHostEnvironment web, IVTreatmentRepo api, IPatientDetailRepo pat, IPhysiotherapistDetailRepo phy, IHostingEnvironment env) {
            _db = db;
            _fdb = fdb;
            _web = web;
            _api = api;
            _pat = pat;
            _phy = phy;
            _env = env;
        }

        public void Create(TreatmentDetailsViewModel vm)
        {
            TypeNotes typenotes = new TypeNotes()
            {
                Notes = vm.Notes,
                NotetakerId = vm.NotetakerId,
                Date = vm.Date,
                VisibleForPatient = vm.VisibleForPatient
            };
            _fdb.TypeNotess.Add(typenotes);
            _fdb.SaveChanges();
            Treatment treatment = new Treatment()
            {
                TypeId = vm.TypeId,
                TypeNotesId = typenotes.Id,
                Description = vm.Description,
                Room = vm.Room,
                Notes = vm.Notes,
                CaretakerId = vm.CaretakerId,
                TreatmentDate = vm.TreatmentDate,
                PatientFileId = vm.PatientFileId
            };
            _fdb.Treatments.Add(treatment);
            _fdb.SaveChanges();
            
        }

        public IEnumerable<TreatmentDetailsViewModel> GetAll()
        {
            List<Treatment> treatments = _fdb.Treatments.ToList();
            List<PatientFile> patientfiles = _fdb.PatientFiles.ToList();
            List<FysioAvansWebAppUser> users = _db.FysioUsers.ToList();
            List<TypeNotes> typenotess = _fdb.TypeNotess.ToList();
            List<Person> persons = _db.Persons.ToList();
            var treatmentdetails = from t in treatments
                                   join n in typenotess on t.TypeNotesId equals n.Id into table0
                                   from n in table0.ToList()
                                   join f in patientfiles on t.PatientFileId equals f.Id into table1
                                   from f in table1.ToList()                                   
                                   join u in users on f.PatientId equals u.PatientId into table2
                                   from u in table2.ToList()
                                   join p in persons on u.PersonId equals p.Id into table3
                                   from p in table3.ToList()
                                   join u2 in users on t.CaretakerId equals u2.PhysiotherapistId into table4
                                   from u2 in table4.ToList()
                                   join p2 in persons on u2.PersonId equals p2.Id into table5
                                   from p2 in table5.ToList()
                                   select new TreatmentDetailsViewModel
                                 {
                                     TreatmentId = t.Id,
                                     TypeId = t.TypeId,
                                     TypeNotesId = t.TypeNotesId,
                                     Description = t.Description,
                                     Room = t.Room,
                                     CaretakerId = t.CaretakerId,
                                     TreatmentDate = t.TreatmentDate,
                                     PatientFileId = t.PatientFileId,
                                     PatientFirstname = p.Firstname,
                                     PatientLastname = p.Lastname,
                                     CaretakerFirstname = p2.Firstname,
                                     CaretakerLastname = p2.Lastname,
                                     Notes = n.Notes,
                                     NotetakerId = n.NotetakerId,
                                     VisibleForPatient = n.VisibleForPatient,
                                     Date = n.Date,
                                       PatientDescription = f.Description,
                                       PatientId = u.PatientId ?? default(int)
                                   };
            return treatmentdetails;
        }

        public TreatmentDetailsViewModel GetOne(int id)
        {
            List<Treatment> treatments = _fdb.Treatments.ToList();
            List<PatientFile> patientfiles = _fdb.PatientFiles.ToList();
            List<FysioAvansWebAppUser> users = _db.FysioUsers.ToList();
            List<Person> persons = _db.Persons.ToList();
            List<TypeNotes> typenotess = _fdb.TypeNotess.ToList();

            var treatmentdetails = from t in treatments
                                   join n in typenotess on t.TypeNotesId equals n.Id into table0
                                   from n in table0.ToList()
                                   join f in patientfiles on t.PatientFileId equals f.Id into table1
                                   from f in table1.ToList()
                                   join u in users on f.PatientId equals u.PatientId into table2
                                   from u in table2.ToList()
                                   join p in persons on u.PersonId equals p.Id into table3
                                   from p in table3.ToList()
                                   join u2 in users on t.CaretakerId equals u2.PhysiotherapistId into table4
                                   from u2 in table4.ToList()
                                   join p2 in persons on u2.PersonId equals p2.Id into table5
                                   from p2 in table5.ToList()
                                   where t.Id == id
                                   select new TreatmentDetailsViewModel
                                   {
                                       TreatmentId = t.Id,
                                       TypeId = t.TypeId,
                                       TypeNotesId = t.TypeNotesId,
                                       Description = t.Description,
                                       Room = t.Room,
                                       CaretakerId = t.CaretakerId,
                                       TreatmentDate = t.TreatmentDate,
                                       PatientFileId = t.PatientFileId,
                                       PatientFirstname = p.Firstname,
                                       PatientLastname = p.Lastname,
                                       CaretakerFirstname = p2.Firstname,
                                       CaretakerLastname = p2.Lastname,
                                       Notes = n.Notes,
                                       NotetakerId = n.NotetakerId,
                                       VisibleForPatient = n.VisibleForPatient,
                                       Date = n.Date,
                                       PatientDescription = f.Description,
                                       PatientId = u.PatientId ?? default(int)

                                   };
            return treatmentdetails.First();
        }

        public async Task<TreatmentDetailsViewModel> GetPeeps()
        {
            var treatmentplans = _fdb.TreatmentPlans.ToList();
            var treatments = _fdb.Treatments.ToList();
            var typesnotess = _fdb.TypeNotess.ToList();
            var vtreatments = await _api.GetVTreatmentsAsync();
            var patientfiles = _pat.GetAll();
            var physiotherapistdetails = _phy.GetAll();
            TreatmentDetailsViewModel vm = new TreatmentDetailsViewModel()
            {
                TreatmentPlans = treatmentplans,
                Treatments = treatments,
                TypeNotess = typesnotess,
                VTreatments = vtreatments,
                PatientFiles = patientfiles,
                Physios = physiotherapistdetails
            };
            vm.Physios = _phy.GetAll();
            return vm;
        }

        public async Task<TreatmentDetailsViewModel> GetOnePeeps(int id)
        {
            var treatmentplans = _fdb.TreatmentPlans.ToList();
            var treatments = _fdb.Treatments.ToList();
            var typesnotess = _fdb.TypeNotess.ToList();
            var vtreatments = await _api.GetVTreatmentsAsync();
            IEnumerable<PatientDetailsViewModel> patientfiles = _pat.GetAll();
            var physiotherapistdetails = _phy.GetAll();
            var vm = GetOne(id);
            vm.TreatmentPlans = treatmentplans;
            vm.Treatments = treatments;
            vm.TypeNotess = typesnotess;
            vm.VTreatments = vtreatments;
            vm.PatientFiles = patientfiles;
            vm.Physios = physiotherapistdetails;
            return vm;
        }

        public void Update(TreatmentDetailsViewModel vm)
        {
            Treatment treatment = new Treatment()
            {
                Id = vm.TreatmentId,
                TypeId = vm.TypeId,
                TypeNotesId = vm.TypeNotesId,
                Description = vm.Description,
                Room = vm.Room,
                Notes = vm.Notes,
                CaretakerId = vm.CaretakerId,
                TreatmentDate = vm.TreatmentDate,
                PatientFileId = vm.PatientFileId
            };
            _fdb.Entry(treatment).State = EntityState.Modified;
            _fdb.SaveChanges();
        }

        public void Delete(int Id)
        {
            Treatment treatment = _fdb.Treatments.Find(Id);
            TypeNotes typenotes = _fdb.TypeNotess.Where(r => r.Id == treatment.TypeNotesId).FirstOrDefault();
            _fdb.Treatments.Remove(treatment);
            _fdb.TypeNotess.Remove(typenotes);
            _fdb.SaveChanges();
        }

        public async Task<IEnumerable<VektisTreatment>> GetVTreatments()
        {
            var diagnoses = await _api.GetVTreatmentsAsync();
            return diagnoses;
        }

        public async Task<TreatmentDetailsViewModel> GetExtraDataTables()
        {
            var availability = _fdb.Availability.ToList();
            var treatmentplans = _fdb.TreatmentPlans.ToList();
            var treatments = _fdb.Treatments.ToList();
            var typenotess = _fdb.TypeNotess.ToList();
            var physiotherapistdetails = _phy.GetAll();
            var patientdetails = _pat.GetAll();
            TreatmentDetailsViewModel vm = new TreatmentDetailsViewModel()
            {
                Availability = availability,
                TreatmentPlans = treatmentplans,
                Treatments = treatments,
                VTreatments = await GetVTreatments(),
                TypeNotess = typenotess,
                Physios = physiotherapistdetails,
                PatientFiles = patientdetails
            };
            return vm;
        }

        

        public async Task<TreatmentDetailsViewModel> GetExtraDataTable(int id)
        {
            var availability = _fdb.Availability.ToList();
            var treatmentplans = _fdb.TreatmentPlans.ToList();
            var dbtreatments = _fdb.Treatments.ToList();
            TreatmentDetailsViewModel vm = GetOne(id);
            var treatments = await _api.GetVTreatmentsAsync();
            var typenotess = _fdb.TypeNotess.ToList();
            var physiotherapistdetails = _phy.GetAll();
            var patientdetails = _pat.GetAll();

            vm.Availability = availability;
            vm.TreatmentPlans = treatmentplans;
            vm.Treatments = dbtreatments;
            vm.VTreatments = treatments;
            vm.TypeNotess = typenotess;
            vm.Physios = physiotherapistdetails;
            vm.PatientFiles = patientdetails;
            return vm;
        }
    }
}
