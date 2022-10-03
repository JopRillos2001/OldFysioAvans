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
    public class SQLPatientDetailRepository : IPatientDetailRepo
    {
        private readonly AuthDbFysioAvansWebAppContext _db;
        private readonly FysioDbContext _fdb;
        private readonly IDiagnosisRepo _api;
        private readonly IPhysiotherapistDetailRepo _phy;
        private readonly IWebHostEnvironment _web;
        private readonly IHostingEnvironment _env;

        public SQLPatientDetailRepository(AuthDbFysioAvansWebAppContext db, FysioDbContext fdb, IWebHostEnvironment web, IDiagnosisRepo api, IPhysiotherapistDetailRepo phy, IHostingEnvironment env) {
            _db = db;
            _fdb = fdb;
            _web = web;
            _api = api;
            _phy = phy;
            _env = env;
        }

        public IEnumerable<PatientDetailsViewModel> GetAll()
        {
            List<Person> persons = _db.Persons.ToList();
            List<Roletype> roletypes = _db.Roletypes.ToList();
            List<Accounttype> accounttypes = _db.Accounttypes.ToList();
            List<Patient> patients = _db.Patients.ToList();
            List<PatientFile> patientFiles = _fdb.PatientFiles.ToList();
            List<FysioAvansWebAppUser> users = _db.FysioUsers.ToList();
            List<TreatmentPlan> treatmentplan = _fdb.TreatmentPlans.ToList();
            var patientdetails = from p in persons
                                 join r in roletypes on p.RoletypeId equals r.Id into table1
                                 from r in table1.ToList()
                                 join u in users on p.Id equals u.PersonId into table2
                                 from u in table2.ToList()
                                 join f in patientFiles on u.PatientId equals f.PatientId into table3
                                 from f in table3.ToList()
                                 join pt in patients on u.PatientId equals pt.Id into table4
                                 from pt in table4.ToList()
                                 join a in accounttypes on u.AccounttypeId equals a.Id into table5
                                 from a in table5.ToList()
                                 join tp in treatmentplan on f.TreatmentPlanId equals tp.Id into table6
                                 from tp in table6.ToList()
                                 where u.AccounttypeId == 1
                                 select new PatientDetailsViewModel
                                 {
                                     PatientId = pt.Id,
                                     PersonId = p.Id,
                                     AccounttypeId = a.Id,
                                     RoletypeId = r.Id,
                                     Firstname = p.Firstname,
                                     Lastname = p.Lastname,
                                     Phonenumber = p.Phonenumber,
                                     RoletypeName = r.RoletypeName,
                                     AccounttypeName = a.AccounttypeName,
                                     PatientNumber = pt.PatientNumber,
                                     Photo = pt.Photo,
                                     Gender = pt.Gender,
                                     Birthdate = pt.Birthdate,
                                     PatientDescription = f.Description,
                                     DiagnosisCode = f.DiagnosisCode,
                                     EmployeeId = f.EmployeeId,
                                     IntakeEmployeeId = f.IntakeEmployeeId,
                                     SupervisorId = f.SupervisorId,
                                     CaretakerId = f.CaretakerId,
                                     RegisterDate = f.RegisterDate,
                                     ReleaseDate = f.ReleaseDate,
                                     Notes = f.Notes,
                                     TreatmentPlanId = f.TreatmentPlanId,
                                     Treatments = f.Treatments,
                                     Email = u.Email,
                                     UserId = u.Id,
                                     PatientFileId = f.Id,
                                     SessionLength = tp.SessionLength,
                                     TreatmentsPerWeek = tp.TreatmentsPerWeek
                                 };
            return patientdetails;
        }        

        public PatientDetailsViewModel GetOne(int Id)
        {
            List<Person> persons = _db.Persons.ToList();
            List<Roletype> roletypes = _db.Roletypes.ToList();
            List<Accounttype> accounttypes = _db.Accounttypes.ToList();
            List<Patient> patients = _db.Patients.ToList();
            List<PatientFile> patientFiles = _fdb.PatientFiles.ToList();
            List<FysioAvansWebAppUser> users = _db.FysioUsers.ToList();
            List<TreatmentPlan> treatmentplan = _fdb.TreatmentPlans.ToList();
            var patientdetails = from p in persons
                                 join r in roletypes on p.RoletypeId equals r.Id into table1
                                 from r in table1.ToList()
                                 join u in users on p.Id equals u.PersonId into table2
                                 from u in table2.ToList()
                                 join f in patientFiles on u.PatientId equals f.PatientId into table3
                                 from f in table3.ToList()
                                 join pt in patients on u.PatientId equals pt.Id into table4
                                 from pt in table4.ToList()
                                 join a in accounttypes on u.AccounttypeId equals a.Id into table5
                                 from a in table5.ToList()
                                 join tp in treatmentplan on f.TreatmentPlanId equals tp.Id into table6
                                 from tp in table6.ToList()
                                 where pt.Id == Id && u.AccounttypeId == 1
                                 select new PatientDetailsViewModel
                                 {
                                     PatientId = pt.Id,
                                     PersonId = p.Id,
                                     AccounttypeId = a.Id,
                                     RoletypeId = r.Id,
                                     Firstname = p.Firstname,
                                     Lastname = p.Lastname,
                                     Phonenumber = p.Phonenumber,
                                     RoletypeName = r.RoletypeName,
                                     AccounttypeName = a.AccounttypeName,
                                     PatientNumber = pt.PatientNumber,
                                     Photo = pt.Photo,
                                     Gender = pt.Gender,
                                     Birthdate = pt.Birthdate,
                                     PatientDescription = f.Description,
                                     DiagnosisCode = f.DiagnosisCode,
                                     EmployeeId = f.EmployeeId,
                                     IntakeEmployeeId = f.IntakeEmployeeId,
                                     SupervisorId = f.SupervisorId,
                                     CaretakerId = f.CaretakerId,
                                     RegisterDate = f.RegisterDate,
                                     ReleaseDate = f.ReleaseDate,
                                     Notes = f.Notes,
                                     TreatmentPlanId = f.TreatmentPlanId,
                                     Treatments = f.Treatments,
                                     Email = u.Email,
                                     UserId = u.Id,
                                     PatientFileId = f.Id,
                                     SessionLength = tp.SessionLength,
                                     TreatmentsPerWeek = tp.TreatmentsPerWeek
                                 };
            return patientdetails.First();
        }        

        public async Task<PatientDetailsViewModel> GetPeeps()
        {
            var diagnoses = await _api.GetDiagnosesAsync();
            var persons = _db.Persons.ToList();
            var physiotherapistdetails = _phy.GetAll();
            PatientDetailsViewModel vm = new PatientDetailsViewModel()
            {
                Diagnoses = diagnoses,
                Persons = persons,
                PhysiotherapistDetails = physiotherapistdetails,
                TeacherPhysiotherapistDetails = physiotherapistdetails.Where(r => r.RoletypeId == 2)
                
            };
            return vm;
        }

        public async Task<PatientDetailsViewModel> GetOnePeeps(int id)
        {
            var diagnoses = await _api.GetDiagnosesAsync();
            var persons = _db.Persons.ToList();
            var physiotherapistdetails = _phy.GetAll();
            var vm = GetOne(id);
            vm.Diagnoses = diagnoses;
            vm.Persons = persons;
            vm.PhysiotherapistDetails = physiotherapistdetails;
            vm.TeacherPhysiotherapistDetails = physiotherapistdetails.Where(r => r.RoletypeId == 2);
            return vm;
        }

        public void Create(PatientDetailsViewModel vm)
        {
            string photoPath = UploadFile(vm.File);
            string patientNumber = GetUniqueKey(20);
            vm.Persons = _db.Persons.ToList();
            Patient patient = new Patient()
            {
                PatientNumber = patientNumber,
                Photo = photoPath,
                Gender = vm.Gender,
                Birthdate = vm.Birthdate
            };
            _db.Patients.Add(patient);
            _db.SaveChanges();
            FysioAvansWebAppUser user = new FysioAvansWebAppUser()
            {
                Id = Guid.NewGuid().ToString(),
                PasswordHash = HashPassword(vm.Password),
                Email = vm.Email,
                UserName = vm.Email,
                NormalizedEmail = vm.Email.ToUpper(),
                NormalizedUserName = vm.Email.ToUpper(),
                EmailConfirmed = false,
                PatientId = patient.Id,
                PersonId = vm.PersonId,
                AccounttypeId = 1,
                PhysiotherapistId = -1
            };
            _db.FysioUsers.Add(user);
            _db.SaveChanges();
            TreatmentPlan treatmentplan = new TreatmentPlan()
            {
                TreatmentsPerWeek = vm.TreatmentsPerWeek,
                SessionLength = vm.SessionLength
            };
            _fdb.TreatmentPlans.Add(treatmentplan);
            _fdb.SaveChanges();
            PatientFile patientfile = new PatientFile()
            {
                PatientId = patient.Id,
                Description = vm.PatientDescription,
                DiagnosisCode = vm.DiagnosisCode,
                EmployeeId = vm.EmployeeId,
                IntakeEmployeeId = vm.IntakeEmployeeId,
                SupervisorId = vm.SupervisorId,
                CaretakerId = vm.CaretakerId,
                RegisterDate = vm.RegisterDate,
                ReleaseDate = vm.ReleaseDate,
                TreatmentPlanId = treatmentplan.Id
            };            
            _fdb.PatientFiles.Add(patientfile);
            _fdb.SaveChanges();
        }

        public void Update(PatientDetailsViewModel vm)
        {          
            string photoPath = UploadFile(vm.File);
            vm.Persons = _db.Persons.ToList();
            Patient patient = new Patient()
            {
                PatientNumber = vm.PatientNumber,
                Photo = vm.Photo,
                Id = vm.PatientId,
                Gender = vm.Gender,
                Birthdate = vm.Birthdate
            };
            _db.Entry(patient).State = EntityState.Modified;
            _db.SaveChanges();


            var usr = vm.UserId;
            FysioAvansWebAppUser aspuser = _db.Users.SingleOrDefault(x => x.Id == usr);
            aspuser.Email = vm.Email;
            aspuser.UserName = vm.Email;
            aspuser.NormalizedEmail = vm.Email.ToUpper();
            aspuser.NormalizedUserName = vm.Email.ToUpper();
            aspuser.PersonId = vm.PersonId;
            aspuser.PatientId = patient.Id;
            aspuser.AccounttypeId = 1;
            _db.Entry(aspuser).State = EntityState.Modified;
            _db.SaveChanges();

            TreatmentPlan treatmentplan = new TreatmentPlan()
            {
                Id = vm.TreatmentPlanId,
                TreatmentsPerWeek = vm.TreatmentsPerWeek,
                SessionLength = vm.SessionLength
                
            };
            _db.Entry(treatmentplan).State = EntityState.Modified;
            _fdb.SaveChanges();
            PatientFile patientfile = new PatientFile()
            {
                Id = vm.PatientFileId,
                Description = vm.PatientDescription,
                DiagnosisCode = vm.DiagnosisCode,
                EmployeeId = vm.EmployeeId,
                IntakeEmployeeId = vm.IntakeEmployeeId,
                SupervisorId = vm.SupervisorId,
                CaretakerId = vm.CaretakerId,
                RegisterDate = vm.RegisterDate,
                ReleaseDate = vm.ReleaseDate,
                Notes = vm.Notes,
                TreatmentPlanId = vm.TreatmentPlanId
            };
            _db.Entry(patientfile).State = EntityState.Modified;
            _fdb.SaveChanges();
        }

        public void Delete(int Id) {
            Patient patient = _db.Patients.Find(Id);
            FysioAvansWebAppUser user = _db.FysioUsers.Where(r => r.PatientId == Id).FirstOrDefault();
            PatientFile patientfile = _fdb.PatientFiles.Where(r => r.PatientId == Id).FirstOrDefault();
            TreatmentPlan treatmentplan = _fdb.TreatmentPlans.Where(r => r.Id == patientfile.TreatmentPlanId).FirstOrDefault();
            _db.Patients.Remove(patient);
            _db.FysioUsers.Remove(user);
            _fdb.PatientFiles.Remove(patientfile);
            _fdb.TreatmentPlans.Remove(treatmentplan);
            _db.SaveChanges();
            _fdb.SaveChanges();
        }

        private string GetUniqueKey(int maxSize)
        {
            char[] chars = new char[62];
            chars = "123456789".ToCharArray();
            byte[] data = new byte[1];
            RNGCryptoServiceProvider crypto = new RNGCryptoServiceProvider();
            crypto.GetNonZeroBytes(data);
            data = new byte[maxSize];
            crypto.GetNonZeroBytes(data);
            StringBuilder result = new StringBuilder(maxSize);
            foreach (byte b in data) {
                result.Append(chars[b % (chars.Length)]);
            }
            string res = $"PAT{result.ToString()}";
            return res;
        }

        private string UploadFile(IFormFile photo)
        {
            string wwwPath = this._env.WebRootPath;
            string contentPath = this._env.ContentRootPath;

            string path = Path.Combine(wwwPath, "img\\PatientPhotos");
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }

            if (photo == null) {
                return "default.png";
            }
            string fileName = Path.GetFileName(photo.FileName);
            using (FileStream stream = new FileStream(Path.Combine(path, fileName), FileMode.Create))
            {
                photo.CopyTo(stream);
            }

            return fileName;
        }

        public static string HashPassword(string password)
        {
            byte[] salt;
            byte[] buffer2;
            if (password == null)
            {
                throw new ArgumentNullException("password");
            }
            using (Rfc2898DeriveBytes bytes = new Rfc2898DeriveBytes(password, 0x10, 0x3e8))
            {
                salt = bytes.Salt;
                buffer2 = bytes.GetBytes(0x20);
            }
            byte[] dst = new byte[0x31];
            Buffer.BlockCopy(salt, 0, dst, 1, 0x10);
            Buffer.BlockCopy(buffer2, 0, dst, 0x11, 0x20);
            return Convert.ToBase64String(dst);
        }

    }
}
