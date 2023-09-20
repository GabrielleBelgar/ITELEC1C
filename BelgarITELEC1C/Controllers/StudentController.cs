using Microsoft.AspNetCore.Mvc;
using BelgarITELEC1C.Models;

namespace BelgarITELEC1C.Controllers
{
    /*
    public IActionResult Index()
    {
        Student st = new Student();
        st.StudentId = 1;
        st.StudentName = "Gabrielle Belgar";
        st.DateEnrolled = DateTime.Parse("30/8/23");
        st.StudentCourse = StudentCourse.BSIT;
        st.Email = "gabriellejoanna.belgar.cics@ust.edu.ph";
        ViewBag.Student = st; //container viewbag

        return View();
    }
    */



    public class StudentController : Controller
    {
        List<Student> StudentList = new List<Student>()
            {
                new Student()
        {
            StudentId = 1,
            StudentName = "Gabrielle Joanna Marie Belgar",
            StudentFirstName = "Gabrielle Joanna Marie",
            StudentLastName ="Belgar",
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
            StudentLastName ="Arlante",
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
            StudentLastName ="Debil",
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
            StudentLastName ="Girao",
            StudentCourse = StudentCourse.BSIT,
            DateEnrolled = DateTime.Parse("05/06/2023"),
            StudentEmail = "yvonne.girao.cics@ust.edu.ph",
            GPA = 1.75
                },

    };
        public IActionResult Index()
        {
            return View(StudentList);
        }

        [HttpGet]
        public IActionResult AddStudent()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddStudent(Student newStudent)
        {
            StudentList.Add(newStudent);
            return View("Index", StudentList);
        }
        public IActionResult ShowDetails(int id)
        {

            Student? student = StudentList.FirstOrDefault(st => st.StudentId == id);

            if (student != null)
                return View(student);



            return NotFound();
        }

        [HttpGet]
        public IActionResult UpdateStudent(int id)
        {
            Student? student = StudentList.FirstOrDefault(st => st.StudentId == id);

            if (student != null)
                return View(student);



            return NotFound();
        }


        [HttpPost]
        public IActionResult UpdateStudent(Student studentChanges)
        {
            Student? student = StudentList.FirstOrDefault(st => st.StudentId == studentChanges.StudentId);
            if (student != null)
            {
                student.StudentFirstName = studentChanges.StudentFirstName;
                student.StudentLastName = studentChanges.StudentLastName;
                student.StudentEmail = studentChanges.StudentEmail;
                student.StudentCourse = studentChanges.StudentCourse;
                student.GPA = studentChanges.GPA;
                student.DateEnrolled = studentChanges.DateEnrolled;

            }
            return View("Index", StudentList);
        }
    }
}

