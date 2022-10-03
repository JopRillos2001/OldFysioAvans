using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FysioAvansWebApp.Domain;
using System.Net.Http;
using System.Net.Http.Headers;
using Newtonsoft.Json;

namespace FysioAvansWebApp.Infra
{
    public partial class FysioDbContext : DbContext
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public FysioDbContext(DbContextOptions<FysioDbContext> options, IHttpContextAccessor httpContextAccessor) : base(options)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public DbSet<PatientFile> PatientFiles { get; set; }
        public DbSet<Availability> Availability { get; set; }
        public DbSet<Treatment> Treatments { get; set; }
        public DbSet<TreatmentPlan> TreatmentPlans { get; set; }
        public DbSet<TypeNotes> TypeNotess { get; set; }


    }
}
