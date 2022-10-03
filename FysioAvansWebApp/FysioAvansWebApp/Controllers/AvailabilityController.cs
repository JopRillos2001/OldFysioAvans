using FysioAvansWebApp.Data;
using FysioAvansWebApp.Domain;
using FysioAvansWebApp.Domain.Models;
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
    public class AvailabilityController : Controller
    {
        private string errorMessage = "Unable to update changes.Try again and if the problem persists see your system administrator";
        private readonly IAvailabilityDetailRepo _db;
        private readonly AuthDbFysioAvansWebAppContext _idb;

        public AvailabilityController(IAvailabilityDetailRepo db, AuthDbFysioAvansWebAppContext idb)
        {
            _db = db;
            _idb = idb;
        }
        public IActionResult Index()
        {
            CheckPhysio();
            var model = _db.GetAll();
            return View(model);
        }

        public async Task<IActionResult> Create(int id)
        {
            var model = new AvailabilityDetailsViewModel();
            if (id == 1)
            {
                model.error = "De startdatum moet voor de einddatum liggen";
            }
            return View(model);
        }

        [HttpPost]
        public IActionResult Create(AvailabilityDetailsViewModel vm)
        {
            CheckPhysio();
            try
            {
                int res = DateTime.Compare(vm.StartAvailability, vm.EndAvailability);
                if (res < 0)
                {
                    vm.StartAvailability = vm.StartAvailability;
                    vm.EndAvailability = vm.EndAvailability;
                    vm.EmployeeId = GetLoggedInPhysioId();
                    _db.Create(vm);
                    return RedirectToAction("Index");

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
            AvailabilityDetailsViewModel availability = _db.GetOne(id);
            return View(availability);
        }

        [HttpPost]
        public IActionResult Edit(AvailabilityDetailsViewModel vm)
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
            AvailabilityDetailsViewModel vm = _db.GetOne(id);
            return View(vm);
        }

        [HttpPost]
        public IActionResult Delete(int id)
        {
            CheckPhysio();
            try
            {
                AvailabilityDetailsViewModel vm = _db.GetOne(id);
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
        public IActionResult Availability()
        {
            if (CheckAccounttype() == 1)
            {
                var model = _db.GetAllPlus();
                
                return View(model);
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

        public int GetLoggedInPhysioId()
        {
            var users = _idb.FysioUsers.ToList();
            foreach (var user in users)
            {
                if (user.UserName == User.Identity.Name.ToString())
                {
                    int physioid = user.PhysiotherapistId ?? default(int);
                    return physioid;
                }
            }
            return 0;
        }

        public void CheckPhysio()
        {
            if (CheckAccounttype() == 1)
            {
                Response.Redirect("/Availability/Availability");
            }
            else if (CheckAccounttype() == 0)
            {
                Response.Redirect("/");
            }
        }
    }
}
