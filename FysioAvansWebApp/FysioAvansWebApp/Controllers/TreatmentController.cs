using FysioAvansWebApp.Data;
using FysioAvansWebApp.Domain;
using FysioAvansWebApp.Domain.Models;
using FysioAvansWebApp.Infra;
using FysioAvansWebApp.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace FysioAvansWebApp.Controllers
{
    [Authorize]
    public class TreatmentController : Controller
    {
        private string errorMessage = "Unable to update changes.Try again and if the problem persists see your system administrator";
        private readonly ITreatmentDetailRepo _db;
        private readonly AuthDbFysioAvansWebAppContext _idb;
        private readonly FysioDbContext _fdb;

        public TreatmentController(ITreatmentDetailRepo db, AuthDbFysioAvansWebAppContext idb, FysioDbContext fdb)
        {
            _db = db;
            _idb = idb;
            _fdb = fdb;
        }
        public IActionResult Index()
        {
            Console.WriteLine("Index");
            CheckPhysio();
            var model = _db.GetAll();
            return View(model);
        }

        public async Task<IActionResult> Create(int id)
        {
            Console.WriteLine("Create");
            var model = await GetData();
            if (id == 1)
            {
                model.error = "Sommige velden zijn niet ingevuld!";
            } else if(id == 2)
            {
                model.error = "Deze datum valt niet binnen het behandelplan";
            }

            return View(model);
        }

        private async Task<TreatmentDetailsViewModel> GetData()
        {
            Console.WriteLine("GetData");
            try
            {
                TreatmentDetailsViewModel vm = await _db.GetExtraDataTables();
                return vm;
            }
            catch (Exception e)
            {
                Debug.Write(e);
                return new TreatmentDetailsViewModel();
            }
        }

        [HttpPost]
        public async Task<IActionResult> Create(TreatmentDetailsViewModel vm)
        {
            Console.WriteLine("Create Post");
            CheckPhysio();
            try
            {
                if (vm.TypeId != 0 || vm.Description != null || vm.Notes != null || vm.Room != null || vm.CaretakerId != 0 || vm.PatientFileId != 0)
                {
                    TreatmentDetailsViewModel vmm = await GetData();
                    int a = (from t in vmm.Treatments
                             where t.PatientFileId == vm.PatientFileId
                             select t).Count();                    
                    Console.WriteLine("a: " + a);
                    int b = (from tp in vmm.TreatmentPlans
                             join pf in vmm.PatientFiles on tp.Id equals pf.TreatmentPlanId
                             where pf.PatientFileId == vm.PatientFileId
                             select tp.TreatmentsPerWeek).FirstOrDefault();

                    Console.WriteLine("b: " + b);
                    if (a < b)
                    {
                        _db.Create(vm);
                        return RedirectToAction("Index");
                    }
                    else 
                    {
                        return RedirectToAction("Create", new { id = 2 });
                    }
                }
                return RedirectToAction("Create", new { id=1});
            }
            catch (DataException)
            {
                ModelState.AddModelError("", errorMessage);
            }
            return View(vm);
        }        

        public async Task<IActionResult> Edit(int id)
        {
            CheckPhysio();
            var model = await GetDataOne(id);
            return View(model);
        }
        private async Task<TreatmentDetailsViewModel> GetDataOne(int id)
        {
            CheckPhysio();
            try
            {
                TreatmentDetailsViewModel vm = await _db.GetExtraDataTable(id);
                return vm;
            }
            catch (Exception e)
            {
                Debug.Write(e);
                return new TreatmentDetailsViewModel();
            }
        }

        [HttpPost]
        public IActionResult Edit(TreatmentDetailsViewModel vm)
        {
            CheckPhysio();
            try
            {
                if (ModelState.IsValid)
                {
                    _db.Update(vm);
                    return RedirectToAction("Index");
                }
                return View();
            }
            catch (DataException)
            {
                ModelState.AddModelError("", errorMessage);
            }
            return View(vm);
        }

        [HttpGet]
        public IActionResult Delete(int id, bool? errors)
        {
            CheckPhysio();
            if (errors.GetValueOrDefault())
            {
                ModelState.AddModelError("", errorMessage);
            }
            TreatmentDetailsViewModel vm = _db.GetOne(id);
            return View(vm);
        }

        [HttpPost]
        public IActionResult Delete(int id)
        {
            CheckPhysio();
            try
            {
                TreatmentDetailsViewModel vm = _db.GetOne(id);
                _db.Delete(id);
            }
            catch (DataException)
            {
                return RedirectToAction("Delete", new RouteValueDictionary {
                    { "id", id },
                    { "errors", true}
                });
            }
            return RedirectToAction("Index");
        }

        public int CheckAccounttype()
        {
            var users = _idb.FysioUsers.ToList();
            foreach (var user in users)
            {
                if (user.UserName == User.Identity.Name.ToString())
                {
                    if (user.AccounttypeId == 2)
                    {
                        return 2;
                    }
                    return 1;
                }
            }
            return 0;
        }

        public int CheckPatientfileId()
        {
            var users = _idb.FysioUsers.ToList();
            foreach (var user in users)
            {
                if (user.UserName == User.Identity.Name.ToString())
                {                    
                    return (from u in users
                            join p in _idb.Patients on u.PatientId equals p.Id
                            join pf in _fdb.PatientFiles on p.Id equals pf.PatientId
                            select pf.Id).FirstOrDefault();
                }
            }
            return 0;
        }

        public int GetLoggedInPatientId()
        {
            var users = _idb.FysioUsers.ToList();
            foreach (var user in users)
            {
                if (user.UserName == User.Identity.Name.ToString())
                {
                    int patientid = user.PatientId ?? default(int);
                    return patientid;
                }
            }
            return 0;
        }

        public void CheckPhysio()
        {
            if (CheckAccounttype() == 1)
            {
                Response.Redirect("/PTreatment/Index");
            }
            else if (CheckAccounttype() == 0)
            {
                Response.Redirect("/");
            }
        }
    }
}
