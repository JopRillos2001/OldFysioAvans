using FysioAPI.Domain.IRepos;
using FysioAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FysioAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DiagnosesController : ControllerBase
    {
        private readonly IDiagnosisRepository _db;

        public DiagnosesController(IDiagnosisRepository db) {
            _db = db;
        }

        [HttpGet]
        public async Task<IEnumerable<VektisDiagnosis>> GetDiagnoses() { 
            return await _db.Get();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<VektisDiagnosis>> GetDiagnoses(string id) {
            return await _db.Get(id);
        }
    }
}
