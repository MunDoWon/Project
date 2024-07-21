using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace LastPatient.Controllers
{
    public class PatientDbContext : DbContext
    {
        public PatientDbContext()
        {
        }
        public PatientDbContext(DbContextOptions<PatientDbContext> options) : base(options)
        {

        }
        public DbSet<Patient> Data { get; set; }
        public DbSet<VisitPatients> VisitPeople { get; set; }
        public DbSet<User> User { get; set; }
        public DbSet<Prescription>? Prescription { get; set; }
        public object Patient { get; internal set; }
    }
}

