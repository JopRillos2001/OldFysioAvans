using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FysioAvansWebApp.Domain;
using FysioAvansWebApp.Infra;
using FysioAvansWebApp.Data;
using FysioAvansWebApp.Models;
using FysioAvansWebApp.Domain.Models;
using Microsoft.AspNetCore.Authorization;

namespace TaskList.Controllers
{
    [Authorize]
    public class PatientDetailsController : Controller
    {
        private readonly ILogger<PatientDetailsController> _logger;
        private readonly IPatientDetailRepo _db;

        public PatientDetailsController(ILogger<PatientDetailsController> logger, IPatientDetailRepo db)
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

        public IActionResult Deatils(int id)
        {
            Response.Redirect("/");
            var model = _db.GetAll();
            return View(model);
        }
    }
}
