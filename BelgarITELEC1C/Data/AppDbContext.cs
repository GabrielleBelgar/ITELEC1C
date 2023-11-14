using Microsoft.EntityFrameworkCore;
using BelgarITELEC1C.Models;

namespace BelgarITELEC1C.Data
{

    public class AppDbContext : DbContext
    {
        public DbSet<Student> Students { get; set; }
        public DbSet<Instructor> Instructors { get; set; }


        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) 
        { 
        }
        //Data Seeding
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Student>().HasData(

                new Student()
                {
                    StudentId = 1,
                    StudentName = "Gabrielle Joanna Marie Belgar",
                    StudentFirstName = "Gabrielle Joanna Marie",
                    StudentLastName = "Belgar",
                    StudentCourse = StudentCourse.BSIT,
                    DateEnrolled = DateTime.Now,
                    StudentEmail = "gabriellejoanna.belgar.cics@ust.edu.ph",
                    GPA = 1
                },


                new Student()
                {
                    StudentId = 2,
                    StudentName = "Charlene Arlante",
                    StudentFirstName = "Charlene",
                    StudentLastName = "Arlante",
                    StudentCourse = StudentCourse.BSCS,
                    DateEnrolled = DateTime.Parse("09/08/2023"),
                    StudentEmail = "charlene.arlante.cics@ust.edu.ph",
                    GPA = 1.25
                },


                new Student()
                {
                    StudentId = 3,
                    StudentName = "Roxanne Debil",
                    StudentFirstName = "Roxanne",
                    StudentLastName = "Debil",
                    StudentCourse = StudentCourse.BSIS,
                    DateEnrolled = DateTime.Parse("10/07/2023"),
                    StudentEmail = "roxanne.debil.cics@ust.edu.ph",
                    GPA = 1.50
                },


                new Student()
                {
                    StudentId = 4,
                    StudentName = "Yvonne Girao",
                    StudentFirstName = "Yvonne",
                    StudentLastName = "Girao",
                    StudentCourse = StudentCourse.BSIT,
                    DateEnrolled = DateTime.Parse("05/06/2023"),
                    StudentEmail = "yvonne.girao.cics@ust.edu.ph",
                    GPA = 1.75
                });
        }
    }
}
