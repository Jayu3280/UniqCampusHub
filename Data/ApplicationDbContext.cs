using Microsoft.EntityFrameworkCore;
using UniqCampusHub.Models;

namespace UniqCampusHub.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
           : base(options)
        {
        }

        public DbSet<Student> Students { get; set; }
        public DbSet<Attendance> Attendances { get; set; }
        public DbSet<FeeStructure> FeeStructures { get; set; }
        public DbSet<Subject> Subjects { get; set; }
        public DbSet<Professor> Professors { get; set; }

        public DbSet<AttendanceReport> AttendanceReports { get; set; }

        public DbSet<ExamSchedule> ExamSchedules { get; set; }



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Student DateOfBirth as SQL Server 'date' type (only date, no time)
            modelBuilder.Entity<Student>()
                .Property(s => s.DateOfBirth)
                .HasColumnType("date");

            // Seed Subjects
            modelBuilder.Entity<Subject>().HasData(
             new Subject { Id = -1, SubjectName = "Math" },
             new Subject { Id = -2, SubjectName = "English" },
             new Subject { Id = -3, SubjectName = "Marathi" }

            );
        }
    }
}