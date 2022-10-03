using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FysioAvansWebApp.Domain;
using FysioAvansWebApp.Infra;
using FysioAvansWebApp.Data;
using FysioAvansWebApp.Domain.Models;
using System.Data;
using System.Web;
using Microsoft.AspNetCore.Routing;
using Microsoft.AspNetCore.Authorization;

namespace TaskList.Controllers
{
    [Authorize]
    public class PersonController : Controller
    {
        private string errorMessage = "Unable to update changes.Try again and if the problem persists see your system administrator";
        private readonly ILogger<PersonController> _logger;
        private readonly IPersonRepo _db;
        private readonly AuthDbFysioAvansWebAppContext _idb;

        public PersonController(ILogger<PersonController> logger, IPersonRepo db, AuthDbFysioAvansWebAppContext idb)
        {
            _logger = logger;
            _db = db;
            _idb = idb;
        }
        public IActionResult Index()
        {
            CheckPhysio();
            var model = _db.GetAll();
            return View(model);
        }

        public IActionResult Create()
        {
            CheckPhysio();
            return View(new Person());
        }

        [HttpPost]
        public IActionResult Create(Person person)
        {
            CheckPhysio();
            try
            {
                if (ModelState.IsValid)
                {
                    _db.Create(person);
                    _db.Save();
                    return RedirectToAction("Index");

                }
                return View();
            }
            catch (DataException)
            {
                ModelState.AddModelError("", errorMessage);
            }
            return View(person);
        }

        public IActionResult Edit(int id)
        {
            CheckPhysio();
            Person person = _db.GetOne(id);
            return View(person);
        }

        [HttpPost]
        public IActionResult Edit(Person person)
        {
            CheckPhysio();
            try
            {
                if (ModelState.IsValid)
                {
                    _db.Update(person);
                    _db.Save();
                    return RedirectToAction("Index");
                }
            }
            catch (DataException)
            { 
                ModelState.AddModelError("", errorMessage);
            }
            return View(person);
        }

        [HttpGet]
        public IActionResult Delete(int id, bool? errors)
        {
            CheckPhysio();
            if (errors.GetValueOrDefault())
            {
                ModelState.AddModelError("", errorMessage);
            }
            Person person = _db.GetOne(id);
            return View(person);
        }

        [HttpPost]
        public IActionResult Delete(int id)
        {
            CheckPhysio();
            try
            {
                Person person = _db.GetOne(id);
                _db.Delete(id);
                _db.Save();
            }
            catch(DataException)
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

        public void CheckPhysio()
        {
            if (CheckAccounttype() != 2)
            {
                Response.Redirect("/");
            }
        }
    }
}
