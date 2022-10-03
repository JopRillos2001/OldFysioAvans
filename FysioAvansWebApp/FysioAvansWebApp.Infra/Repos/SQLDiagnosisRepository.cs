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
    public class SQLDiagnosisRepository : IDiagnosisRepo
    {
        private static string baseUrl = "https://localhost:44317";
        private readonly HttpClient _db;

        public SQLDiagnosisRepository(HttpClient db) {
            _db = db;
        }

        public async Task<IEnumerable<VektisDiagnosis>> GetDiagnosesAsync()
        {
            List<VektisDiagnosis> diagnosis = new List<VektisDiagnosis>();
            _db.DefaultRequestHeaders.Clear();

            _db.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            HttpResponseMessage res = await _db.GetAsync("Diagnoses");
            if (res.IsSuccessStatusCode)
            {
                var diagnosisRes = res.Content.ReadAsStringAsync().Result;
                diagnosis = JsonConvert.DeserializeObject<List<VektisDiagnosis>>(diagnosisRes);
            }
            return diagnosis;


        }
    }
}
