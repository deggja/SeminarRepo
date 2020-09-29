using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using seminarapi.Models;

namespace seminarapi.Data
{
    public class SeminarContext : DbContext
    {
        public SeminarContext(DbContextOptions<SeminarContext> options) : base(options)
        {
        }

        public DbSet<Course> Courses { get; set; }
        public DbSet<Instructor> Instructors { get; set; }
        public DbSet<Participant> Participants { get; set; }
        public DbSet<Enrollment> Enrollments { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Course>().ToTable("Course");
            modelBuilder.Entity<Instructor>().ToTable("Instructor");
            modelBuilder.Entity<Participant>().ToTable("Participant");
            modelBuilder.Entity<Enrollment>().ToTable("Enrollment");
        }
    }
}
