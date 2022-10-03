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
    public class SQLAvailabilityDetailRepository : IAvailabilityDetailRepo
    {
        private readonly AuthDbFysioAvansWebAppContext _db;
        private readonly FysioDbContext _fdb;
        private readonly IVTreatmentRepo _api;
        private readonly IPatientDetailRepo _pat;
        private readonly IPhysiotherapistDetailRepo _phy;
        private readonly IWebHostEnvironment _web;
        private readonly IHostingEnvironment _env;

        public SQLAvailabilityDetailRepository(AuthDbFysioAvansWebAppContext db, FysioDbContext fdb, IWebHostEnvironment web, IVTreatmentRepo api, IPatientDetailRepo pat, IPhysiotherapistDetailRepo phy, IHostingEnvironment env) {
            _db = db;
            _fdb = fdb;
            _web = web;
            _api = api;
            _pat = pat;
            _phy = phy;
            _env = env;
        }

        public void Create(AvailabilityDetailsViewModel vm)
        {
            Availability Availability = new Availability()
            {
                StartAvailable = vm.StartAvailability,
                EndAvailable = vm.EndAvailability,
                EmployeeId = vm.EmployeeId
            };
            _fdb.Availability.Add(Availability);
            _fdb.SaveChanges();
            
        }

        public IEnumerable<AvailabilityDetailsViewModel> GetAll()
        {
            List<Availability> Availability = _fdb.Availability.ToList();
            var availabilityDetails = from a in Availability
                                   select new AvailabilityDetailsViewModel
                                   {
                                       AvailabilityId = a.Id,
                                       StartAvailability = a.StartAvailable,
                                       EndAvailability = a.EndAvailable,
                                       EmployeeId = a.EmployeeId,
                                   };
            return availabilityDetails;
        }

        public AvailabilityDetailsViewModel GetOne(int id)
        {
            List<Availability> Availability = _fdb.Availability.ToList();
            var availabilityDetails = from a in Availability
                                      where a.Id == id
                                      select new AvailabilityDetailsViewModel
                                      {
                                          AvailabilityId = a.Id,
                                          StartAvailability = a.StartAvailable,
                                          EndAvailability = a.EndAvailable,
                                          EmployeeId = a.EmployeeId,
                                      };
            return availabilityDetails.First();
        }

        public void Update(AvailabilityDetailsViewModel vm)
        {
            Availability Availability = new Availability()
            {
                StartAvailable = vm.StartAvailability,
                EndAvailable = vm.EndAvailability,
                EmployeeId = vm.EmployeeId,
            };
            _fdb.Entry(Availability).State = EntityState.Modified;
            _fdb.SaveChanges();
        }

        public void Delete(int Id)
        {
            Availability availability = _fdb.Availability.Find(Id);
            _fdb.Availability.Remove(availability);
            _fdb.SaveChanges();
        }

        public IEnumerable<AvailabilityDetailsViewModel> GetAllPlus()
        {
            List<Availability> Availability = _fdb.Availability.ToList();
            List<Physiotherapist> Physio = _db.Physiotherapists.ToList();
            List<FysioAvansWebAppUser> FysioUsers = _db.FysioUsers.ToList();
            List<Person> Person = _db.Persons.ToList();
            var availabilityDetails = from a in Availability
                                      join p in Physio on a.EmployeeId equals p.Id
                                      join u in FysioUsers on p.Id equals u.PhysiotherapistId
                                      join pp in Person on u.PersonId equals pp.Id
                                      select new AvailabilityDetailsViewModel
                                      {
                                          AvailabilityId = a.Id,
                                          StartAvailability = a.StartAvailable,
                                          EndAvailability = a.EndAvailable,
                                          EmployeeId = a.EmployeeId,
                                          PhysioFirstname = pp.Firstname,
                                          PhysioLastname = pp.Lastname
                                      };
            return availabilityDetails;
        }

    }
}
