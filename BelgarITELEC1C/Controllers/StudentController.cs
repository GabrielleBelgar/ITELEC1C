using Microsoft.AspNetCore.Mvc;
using BelgarITELEC1C.Models;
using BelgarITELEC1C.Services;

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
        private readonly IMyFakeDataService _dummyData;

        public StudentController(IMyFakeDataService dummyData)
        {
            _dummyData = dummyData;
        }


        public IActionResult Index()
        {
            return View(_dummyData.StudentList);
        }

        [HttpGet]
        public IActionResult AddStudent()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddStudent(Student newStudent)
        {
            _dummyData.StudentList.Add(newStudent);
            return RedirectToAction("Index");

        }
        public IActionResult ShowDetails(int id)
        {

            Student? student = _dummyData.StudentList.FirstOrDefault(st => st.StudentId == id);

            if (student != null)
                return View(student);



            return NotFound();
        }

        [HttpGet]
        public IActionResult UpdateStudent(int id)
        {
            Student? student = _dummyData.StudentList.FirstOrDefault(st => st.StudentId == id);

            if (student != null)
                return View(student);



            return NotFound();
        }


        [HttpPost]
        public IActionResult UpdateStudent(Student studentChanges)
        {
            Student? student = _dummyData.StudentList.FirstOrDefault(st => st.StudentId == studentChanges.StudentId);
            if (student != null)
            {
                student.StudentFirstName = studentChanges.StudentFirstName;
                student.StudentLastName = studentChanges.StudentLastName;
                student.StudentEmail = studentChanges.StudentEmail;
                student.StudentCourse = studentChanges.StudentCourse;
                student.GPA = studentChanges.GPA;
                student.DateEnrolled = studentChanges.DateEnrolled;

            }
            return RedirectToAction("Index");
        }


        [HttpGet]
        public IActionResult DeleteStudent(int id)
        {
            Student? student = _dummyData.StudentList.FirstOrDefault(st => st.StudentId == id);

            if (student != null)
                return View(student);



            return NotFound();
        }


        [HttpPost]
        public IActionResult DeleteStudent(Student newStudent)
        {
            Student? student = _dummyData.StudentList.FirstOrDefault(st => st.StudentId == newStudent.StudentId);

            if (student != null)
                _dummyData.StudentList.Remove(student);
            return RedirectToAction("Index");
        }

    }
}

