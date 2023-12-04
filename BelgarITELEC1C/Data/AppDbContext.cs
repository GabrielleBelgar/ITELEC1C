using Microsoft.EntityFrameworkCore;
using BelgarITELEC1C.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace BelgarITELEC1C.Data
{

    public class AppDbContext : IdentityDbContext<User>
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
                    StudentFirstName = "Yvonne",
                    StudentLastName = "Girao",
                    StudentCourse = StudentCourse.BSIT,
                    DateEnrolled = DateTime.Parse("05/06/2023"),
                    StudentEmail = "yvonne.girao.cics@ust.edu.ph",
                    GPA = 1.75
                });


            modelBuilder.Entity<Instructor>().HasData(

                 new Instructor()
                 {
                     InstructorId = 1,
                     InstructorFirstName = "Gabriel",
                     InstructorLastName = "Montano",
                     DateHired = DateTime.Now,
                     InstructorEmail = "gdmontano@ust.edu.ph",
                     IsTenured = IsTenured.Permanent,
                     Rank = Rank.Instructor
                 },


                new Instructor()
                {
                    InstructorId = 2,
                    InstructorFirstName = "Eugenia",
                    InstructorLastName = "Zhuo",
                    DateHired = DateTime.Parse("25/3/2000"),
                    InstructorEmail = "erzhuo@ust.edu.ph",
                    IsTenured = IsTenured.Permanent,
                    Rank = Rank.AssistantProfessor
                },

                  new Instructor()
                  {
                      InstructorId = 3,
                      InstructorFirstName = "Leo",
                      InstructorLastName = "Lintag",
                      DateHired = DateTime.Parse("25/3/2001"),
                      InstructorEmail = "Lintag@ust.edu.ph",
                      IsTenured = IsTenured.Permanent,
                      Rank = Rank.AssociateProfessor
                  },

                   new Instructor()
                   {
                       InstructorId = 4,
                       InstructorFirstName = "Beatriz",
                       InstructorLastName = "Lacsamana",
                       DateHired = DateTime.Parse("25/4/2002"),
                       InstructorEmail = "mllacsamana@ust.edu.ph",
                       IsTenured = IsTenured.Probationary,
                       Rank = Rank.Professor
                   }


                );

        }
    }
}
