using FysioAPI.Models;
using Microsoft.EntityFrameworkCore;
using System;

namespace FysioAPI.Infra
{
    public class FysioAPIDbContext : DbContext
    {
        public FysioAPIDbContext(DbContextOptions<FysioAPIDbContext> options) 
            : base (options)
        {
            Database.EnsureCreated();
        }

        public DbSet<VektisDiagnosis> VektisDiagnoses { get; set; }
        public DbSet<VektisTreatment> VektisTreatments { get; set; }
    }
}
