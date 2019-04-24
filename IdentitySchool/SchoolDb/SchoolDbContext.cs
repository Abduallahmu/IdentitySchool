using IdentitySchool.Models;
using Microsoft.EntityFrameworkCore;

namespace IdentitySchool.SchoolDb
{
    public class SchoolDbContext : DbContext
    {
        public SchoolDbContext(DbContextOptions<SchoolDbContext> options) : base(options) { }
        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Assignment> Assignments { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<StudentsCourses>()
                .HasKey(st => new { st.StudentId, st.CourseId });

            modelBuilder.Entity<StudentsCourses>()
                .HasOne(to => to.Student)
                .WithMany(st => st.StudentsCourses)
                .HasForeignKey(to => to.StudentId);

            modelBuilder.Entity<StudentsCourses>()
                .HasOne(to => to.Course)
                .WithMany(to => to.StudentsCourses)
                .HasForeignKey(to => to.CourseId);

            modelBuilder.Entity<Course>()
                .HasMany(ccoruse => ccoruse.Assignments)
                .WithOne()
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Teacher>()
                .HasMany(to => to.Courses)
                .WithOne(to => to.Teacher);
        }
    }
}
