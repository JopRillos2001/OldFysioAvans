using FysioAvansWebApp.Areas.Identity.Data;
using FysioAvansWebApp.Data;
using FysioAvansWebApp.Domain;
using FysioAvansWebApp.Domain.Models;
using FysioAvansWebApp.Infra;
using Microsoft.AspNetCore.Hosting;
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
    public class SQLPhysiotherapistDetailRepository : IPhysiotherapistDetailRepo
    {
        private readonly AuthDbFysioAvansWebAppContext _db;
        private readonly FysioDbContext _fdb;
        private readonly IDiagnosisRepo _api;
        private readonly IWebHostEnvironment _web;

        public SQLPhysiotherapistDetailRepository(AuthDbFysioAvansWebAppContext db, FysioDbContext fdb, IWebHostEnvironment web, IDiagnosisRepo api)
        {
            _db = db;
            _fdb = fdb;
            _web = web;
            _api = api;
        }

        public IEnumerable<PhysiotherapistDetailsViewModel> GetAll()
        {
            List<Person> persons = _db.Persons.ToList();
            List<Roletype> roletypes = _db.Roletypes.ToList();
            List<Accounttype> accounttypes = _db.Accounttypes.ToList();
            List<Physiotherapist> physiotherapists = _db.Physiotherapists.ToList();
            List<FysioAvansWebAppUser> users = _db.FysioUsers.ToList();
            var physiotherapistdetails = from p in persons
                                         join r in roletypes on p.RoletypeId equals r.Id into table1
                                         from r in table1.ToList()
                                         join u in users on p.Id equals u.PersonId into table2
                                         from u in table2.ToList()
                                         join py in physiotherapists on u.PhysiotherapistId equals py.Id into table3
                                         from py in table3.ToList()
                                         join a in accounttypes on u.AccounttypeId equals a.Id into table4
                                         from a in table4.ToList()
                                         where u.AccounttypeId == 2
                                         select new PhysiotherapistDetailsViewModel                                 
                                         {                                     
                                             PhysiotherapistId = py.Id,                                     
                                             PersonId = p.Id,                                     
                                             AccounttypeId = a.Id,                                     
                                             RoletypeId = r.Id,                                     
                                             Firstname = p.Firstname,                                     
                                             Lastname = p.Lastname,                                    
                                             Phonenumber = p.Phonenumber,                                     
                                             RoletypeName = r.RoletypeName,                                     
                                             AccounttypeName = a.AccounttypeName,       
                                             PhysiotherapistNumber = py.PhysiotherapistNumber,                                     
                                             Email = u.Email     
                                         };            
            return physiotherapistdetails;
        }

        public PhysiotherapistDetailsViewModel GetOne(int id)
        {
            List<Person> persons = _db.Persons.ToList();
            List<Roletype> roletypes = _db.Roletypes.ToList();
            List<Accounttype> accounttypes = _db.Accounttypes.ToList();
            List<Physiotherapist> physiotherapists = _db.Physiotherapists.ToList();
            List<FysioAvansWebAppUser> users = _db.FysioUsers.ToList();
            var physiotherapistdetails = from p in persons
                                         join r in roletypes on p.RoletypeId equals r.Id into table1
                                         from r in table1.ToList()
                                         join u in users on p.Id equals u.PersonId into table2
                                         from u in table2.ToList()
                                         join py in physiotherapists on u.PhysiotherapistId equals py.Id into table3
                                         from py in table3.ToList()
                                         join a in accounttypes on u.AccounttypeId equals a.Id into table4
                                         from a in table4.ToList()
                                         where u.AccounttypeId == 2 && py.Id == id
                                         select new PhysiotherapistDetailsViewModel
                                         {
                                             PhysiotherapistId = py.Id,
                                             PersonId = p.Id,
                                             AccounttypeId = a.Id,
                                             RoletypeId = r.Id,
                                             Firstname = p.Firstname,
                                             Lastname = p.Lastname,
                                             Phonenumber = p.Phonenumber,
                                             RoletypeName = r.RoletypeName,
                                             AccounttypeName = a.AccounttypeName,
                                             PhysiotherapistNumber = py.PhysiotherapistNumber,
                                             Email = u.Email
                                         };
            return physiotherapistdetails.First();
        }

    }
}
