using BelgarITELEC1C.Models;
using BelgarITELEC1C.Services;

namespace BelgarITELEC1C.Services
{
    public class MyFakeDataService : IMyFakeDataService
    {
        public List<Student> StudentList { get; }
        public List<Instructor> InstructorList { get; }

        public MyFakeDataService() //Constructor
        {
            StudentList = new List<Student>
            {
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
                }
            };




            InstructorList = new List<Instructor>
            {
                new Instructor()
                {
                    InstructorId = 1,
                    InstructorName = "Gabriel Montano",
                    InstructorFirstName = "Gabriel",
                    InstructorLastName ="Montano",
                            DateHired = DateTime.Now,
                            InstructorEmail = "gdmontano@ust.edu.ph",
                            IsTenured = IsTenured.Permanent,
                            Rank = Rank.Instructor
                        },


                new Instructor()
                {
                    InstructorId = 2,
                    InstructorName = "Eugenia Zhuo",
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
                    InstructorName = "Leo Lintag",
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
                    InstructorName = "Beatriz Lacsamana",
                    InstructorFirstName = "Beatriz",
                    InstructorLastName = "Lacsamana",
                            DateHired = DateTime.Parse("25/4/2002"),
                            InstructorEmail = "mllacsamana@ust.edu.ph",
                            IsTenured = IsTenured.Probationary,
                            Rank = Rank.Professor
                        },

            };
        }

    }
        
}
    

   