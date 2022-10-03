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
    public class PTreatmentController : Controller
    {
        private string errorMessage = "Unable to update changes.Try again and if the problem persists see your system administrator";
        private readonly ITreatmentDetailRepo _db;
        private readonly AuthDbFysioAvansWebAppContext _idb;
        private readonly FysioDbContext _fdb;

        public PTreatmentController(ITreatmentDetailRepo db, AuthDbFysioAvansWebAppContext idb, FysioDbContext fdb)
        {
            _db = db;
            _idb = idb;
            _fdb = fdb;
        }
        public IActionResult Index()
        {
            if (CheckAccounttype() == 1)
            {
                int patientfileid = CheckPatientfileId();
                Console.WriteLine("PatientId: " + patientfileid);
                var treatmentDetailsViewModel = _db.GetAll().Where(r => r.PatientFileId == patientfileid);
                return View(treatmentDetailsViewModel);
            }
            else
            {
                Response.Redirect("/");
            }
            return View();
        }

        public async Task<IActionResult> Create(int id)
        {
            Console.WriteLine("PCreate");
            if (CheckAccounttype() == 1)
            {
                var model = await GetData();
                if (id == 1)
                {
                    model.error = "Sommige velden zijn niet ingevuld!";
                }
                else if (id == 2)
                {
                    model.error = "Deze datum valt niet binnen de beschikbaarheid";
                }

                return View(model);
            }
            else
            {
                Response.Redirect("/");
            }
            return View();
        

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
            Console.WriteLine("PCreate Post");
            if (CheckAccounttype() == 1)
            {
                try
                {
                    if (vm.TypeId != 0 || vm.Description != null || vm.Notes != null || vm.Room != null || vm.CaretakerId != 0)
                    {
                        vm.PatientFileId = CheckPatientfileId();

                        TreatmentDetailsViewModel vmm = await GetData();
                        Console.WriteLine(vmm.Availability.Count());
                        List<Availability> alist = (from av in vmm.Availability where av.EmployeeId == vm.CaretakerId select av).ToList();
                        bool place = false;
                        foreach (var aitem in alist) {
                            if (vm.TreatmentDate >= aitem.StartAvailable && vm.TreatmentDate < aitem.EndAvailable) {
                                place = true;
                            }
                        }                        
                        if (place)
                        {
                            Console.WriteLine("a < b P");
                            _db.Create(vm);
                            return RedirectToAction("Index");
                        }
                        else
                        {
                            Console.WriteLine("else 2");
                            return RedirectToAction("Create", new { id = 2 });
                        }
                    }
                    Console.WriteLine("else 1");
                    return RedirectToAction("Create", new { id = 1 });
                }
                catch (DataException)
                {
                    ModelState.AddModelError("", errorMessage);
                }
                return View(vm);
            }
            else
            {
                Response.Redirect("/");
            }
            return View();
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

        [HttpGet]
        public IActionResult MyDetails()
        {
            if (CheckAccounttype() == 1)
            {
                int patientid = GetLoggedInPatientId();
                var treatmentDetailsViewModel = _db.GetAll().Where(r => r.PatientId == patientid);
                return View(treatmentDetailsViewModel);
            }
            else
            {
                Response.Redirect("/");
            }
            return View();
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
            if (CheckAccounttype() == 2)
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
