using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Web;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FysioAvansWebApp.Domain;
using FysioAvansWebApp.Infra;
using FysioAvansWebApp.Data;
using FysioAvansWebApp.Domain.Models;
using FysioAvansWebApp.Models;
using System.Data;
using System.Diagnostics;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using Microsoft.AspNetCore.Authorization;

namespace FysioAvansWebApp.Controllers
{
    [Authorize]
    public class PatientController : Controller
    {
        private string errorMessage = "Unable to update changes.Try again and if the problem persists see your system administrator";
        private readonly IPatientDetailRepo _db;
        private readonly AuthDbFysioAvansWebAppContext _idb;

        public PatientController(IPatientDetailRepo db, AuthDbFysioAvansWebAppContext idb)
        {
            _db = db;
            _idb = idb;
        }
        public IActionResult Index()
        {
            CheckPhysioIndex();
            var model = _db.GetAll();

            return View(model);
        }

        public async Task<IActionResult> Create(int id, int eid)
        {
            CheckPhysioIndex();
            var model = await GetData();
            model.PersonId = id;
            if (eid == 1)
            {
                model.error = "Geboortedatum is incorrect";
            }
            return View(model);
        }

        private async Task<PatientDetailsViewModel> GetData()
        {
            try
            {
                PatientDetailsViewModel vm = await _db.GetPeeps();
                return vm;
            }
            catch (Exception e)
            {
                Debug.Write(e);
                return new PatientDetailsViewModel();
            }
        }

        [HttpPost]
        public IActionResult Create(PatientDetailsViewModel vm)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (vm.Birthdate < DateTime.Now.AddYears(-18))
                    {
                        _db.Create(vm);
                        return RedirectToAction("Index");
                    }
                    else {
                        return RedirectToAction("Create", new { eid = 1 });
                    }

                }
                return View();
            }
            catch (DataException)
            {
                ModelState.AddModelError("", errorMessage);
            }
            return View(vm);
        }

        public async Task<IActionResult> Edit(int id)
        {
            CheckPhysioIndex();
            var model = await GetDataOne(id);
            return View(model);
        }
        private async Task<PatientDetailsViewModel> GetDataOne(int id)
        {
            try
            {
                PatientDetailsViewModel vm = await _db.GetOnePeeps(id);
                return vm;
            }
            catch (Exception e)
            {
                Debug.Write(e);
                return new PatientDetailsViewModel();
            }
        }

        [HttpPost]
        public IActionResult Edit(PatientDetailsViewModel vm)
        {
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
            CheckPhysioIndex();
            if (errors.GetValueOrDefault())
            {
                ModelState.AddModelError("", errorMessage);
            }
            PatientDetailsViewModel patientDetailsViewModel = _db.GetOne(id);
            return View(patientDetailsViewModel);
        }

        [HttpPost]
        public IActionResult Delete(int id)
        {
            try
            {
                PatientDetailsViewModel patientDetailsViewModel = _db.GetOne(id);
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
                PatientDetailsViewModel patientDetailsViewModel = _db.GetOne(patientid);
                return View(patientDetailsViewModel);
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
                Response.Redirect("/Patient/Index");
            }
            else if (CheckAccounttype() == 0)
            {
                Response.Redirect("/");
            }
        }

        public void CheckPhysioIndex()
        {
            if (CheckAccounttype() == 1)
            {
                Response.Redirect("/Patient/MyDetails");
            }
            else if (CheckAccounttype() == 0)
            {
                Response.Redirect("/");
            }
        }
    }
}
