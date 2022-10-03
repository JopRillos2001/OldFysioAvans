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
    public class TreatmentsController : ControllerBase
    {
        private readonly ITreatmentRepository _db;

        public TreatmentsController(ITreatmentRepository db)
        {
            _db = db;
        }

        [HttpGet]
        public async Task<IEnumerable<VektisTreatment>> GetTreatments()
        {
            return await _db.Get();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<VektisTreatment>> GetTreatments(string id)
        {
            return await _db.Get(id);
        }
    }
}
