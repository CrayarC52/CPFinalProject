using System;
using CPFinalProjet.Models;
using Microsoft.EntityFrameworkCore;

namespace CPFinalProject.Data
{
    public class StudentsContext : DbContext
    {
        public StudentsContext(DbContextOptions<StudentsContext> options) : base(options) {}

        public DbSet<Student> Students { get; set; }
        public DbSet<Appearance> Appearances { get; set; }
        public DbSet<Preference> Preferences { get; set; }
        public DbSet<Family> Families { get; set; }
    }
}