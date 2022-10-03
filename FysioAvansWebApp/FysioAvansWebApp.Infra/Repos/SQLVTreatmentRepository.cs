using FysioAvansWebApp.Domain;
using FysioAvansWebApp.Domain.Models;
using FysioAvansWebApp.Infra;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
//using System.Text.Json;
using System.Threading.Tasks;

namespace FysioAvansWebApp.Models.Repo
{
    public class SQLVTreatmentRepository : IVTreatmentRepo
    {
        private static string baseUrl = "https://localhost:44317";
        private readonly HttpClient _db;

        public SQLVTreatmentRepository(HttpClient db) {
            _db = db;
        }

        public async Task<IEnumerable<VektisTreatment>> GetVTreatmentsAsync()
        {
            List<VektisTreatment> vtreatment = new List<VektisTreatment>();
            _db.DefaultRequestHeaders.Clear();

            _db.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            HttpResponseMessage res = await _db.GetAsync("Treatments");
            if (res.IsSuccessStatusCode)
            {
                var vtreatmentRes = res.Content.ReadAsStringAsync().Result;
                vtreatment = JsonConvert.DeserializeObject<List<VektisTreatment>>(vtreatmentRes);
            }
            return vtreatment;


        }
    }
}
