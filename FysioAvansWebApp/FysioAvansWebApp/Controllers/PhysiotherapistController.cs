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
using FysioAvansWebApp.Models;
using Microsoft.AspNetCore.Authorization;

namespace TaskList.Controllers
{
    [Authorize]
    public class PhysiotherapistController : Controller
    {
        
        private readonly ILogger<PhysiotherapistController> _logger;
        private readonly IPhysiotherapistDetailRepo _db;
        private readonly AuthDbFysioAvansWebAppContext _idb;

        public PhysiotherapistController(ILogger<PhysiotherapistController> logger, IPhysiotherapistDetailRepo db, AuthDbFysioAvansWebAppContext idb)
        {
            _logger = logger;
            _db = db;
            _idb = idb;
        }
        public IActionResult Index()
        {
            Response.Redirect("/");
            var model = _db.GetAll();
            return View(model);
        }

        [HttpGet]
        public IActionResult MyDetails()
        {
            if (CheckAccounttype() == 2)
            {
                int physiotherapistid = GetLoggedInPhysioId();
                PhysiotherapistDetailsViewModel physiotherapistDetailsViewModel = _db.GetOne(physiotherapistid);
                return View(physiotherapistDetailsViewModel);
            }
            else if (CheckAccounttype() == 1) {
                Response.Redirect("/Patient/MyDetails");
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
                Response.Redirect("/Patient/MyDetails");
            }
            else if (CheckAccounttype() == 0)
            {
                Response.Redirect("/");
            }
        }

        //public IActionResult Create()
        //{
        //    return View(new Physiotherapist());
        //}

        //[HttpPost]
        //public IActionResult Create(PhysiotherapistDetailsViewModel vm)
        //{
        //    try
        //    {
        //        if (ModelState.IsValid)
        //        {
        //            _db.Create(vm);
        //            return RedirectToAction("Index");

        //        }
        //        return View();
        //    }
        //    catch (DataException)
        //    {
        //        ModelState.AddModelError("", errorMessage);
        //    }
        //    return View(vm);
        //}
    }
}
