using HospitalManagment.Library.Domain;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace HospitalManagement.Api.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<Patient> Patients { get; set; }
        public DbSet<Disease> Diseases { get; set; }
        public DbSet<Allergies> Allergiess { get; set; }
        public DbSet<Allergies_Details> AllergiesDetails { get; set; }
        public DbSet<NCD> NCDs { get; set; }
        public DbSet<NCD_Details> NCDsDetails { get; set; }
    }
}
