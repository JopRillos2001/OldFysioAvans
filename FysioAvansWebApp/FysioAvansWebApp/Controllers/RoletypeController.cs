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
    public class RoletypeController : Controller
    {
        private string errorMessage = "Unable to update changes.Try again and if the problem persists see your system administrator";
        private readonly ILogger<RoletypeController> _logger;
        private readonly IRoletypeRepo _db;

        public RoletypeController(ILogger<RoletypeController> logger, IRoletypeRepo db)
        {
            _logger = logger;
            _db = db;
        }
        public IActionResult Index()
        {
            Response.Redirect("/");
            var model = _db.GetAll();
            return View(model);
        }

        public IActionResult Create()
        {
            Response.Redirect("/");
            return View(new Roletype());
        }

        [HttpPost]
        public IActionResult Create(Roletype roletype)
        {
            Response.Redirect("/");
            try
            {
                if (ModelState.IsValid)
                {
                    _db.Create(roletype);
                    _db.Save();
                    return RedirectToAction("Index");

                }
                return View();
            }
            catch (DataException)
            {
                ModelState.AddModelError("", errorMessage);
            }
            return View(roletype);
        }

        public IActionResult Edit(int id)
        {
            Response.Redirect("/");
            Roletype roletype = _db.GetOne(id);
            return View(roletype);
        }

        [HttpPost]
        public IActionResult Edit(Roletype roletype)
        {
            Response.Redirect("/");
            try
            {
                if (ModelState.IsValid)
                {
                    _db.Update(roletype);
                    _db.Save();
                    return RedirectToAction("Index");
                }
            }
            catch (DataException)
            { 
                ModelState.AddModelError("", errorMessage);
            }
            return View(roletype);
        }

        [HttpGet]
        public IActionResult Delete(int id, bool? errors)
        {
            Response.Redirect("/");
            if (errors.GetValueOrDefault())
            {
                ModelState.AddModelError("", errorMessage);
            }
            Roletype roletype = _db.GetOne(id);
            return View(roletype);
        }

        [HttpPost]
        public IActionResult Delete(int id)
        {
            Response.Redirect("/");
            try
            {
                Roletype roletype = _db.GetOne(id);
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
    }
}
