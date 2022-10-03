using FysioAvansWebApp.Domain;
using FysioAvansWebApp.Domain.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace FysioAvansWebApp.Controllers
{
    public class DiagnosesController : Controller
    {
        private IDiagnosisRepo _db;
        public DiagnosesController(IDiagnosisRepo db)
        {
            _db = db;
        }

        public async Task<ActionResult> Index()
        {
            Response.Redirect("/");
            var diagnoses = await GetDiagnoses();
            return View(diagnoses);
        }

        private async Task<IEnumerable<VektisDiagnosis>> GetDiagnoses()
        {
            Response.Redirect("/");
            try
            {
                var diagnoses = await _db.GetDiagnosesAsync();
                return diagnoses;
            }
            catch(Exception e)
            {
                Debug.Write(e);
                return Enumerable.Empty<VektisDiagnosis>();
            }
        }
    }
}
