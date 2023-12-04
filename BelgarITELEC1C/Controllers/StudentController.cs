using Microsoft.AspNetCore.Mvc;
using BelgarITELEC1C.Models;
using BelgarITELEC1C.Data;
using Microsoft.AspNetCore.Authorization;

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
        private readonly AppDbContext _dbData;
        private readonly IWebHostEnvironment _environment;


        public StudentController(AppDbContext dbData, IWebHostEnvironment environment)
        {
            _dbData = dbData;
            _environment = environment;
        }

        
        public IActionResult Index()
        {
            return View(_dbData.Students);
        }

        [HttpGet]
        public IActionResult AddStudent()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddStudent(Student newStudent)
        {


            string folder = "students/images/"; //create folder
            string serverFolder = Path.Combine(_environment.WebRootPath, folder); //concatenate Webrootpath to folder
            string uniqueFileName = Guid.NewGuid().ToString() + "_" + newStudent.UploadedPhoto.FileName;
            string filePath = Path.Combine(serverFolder, uniqueFileName); //combine the filename to the server
            using(var fileStream = new FileStream(filePath, FileMode.Create)) //saving the photo in filepath
            {
                newStudent.UploadedPhoto.CopyTo(fileStream);

            }
            newStudent.imagePath = folder + uniqueFileName;



                /*
                //if a file/image was uploaded, convert it to byte and save it
                if (Request.Form.Files.Count > 0) //did a user upload a file?
                {
                    var file = Request.Form.Files[0]; //our view will allow one file

                    MemoryStream ms = new MemoryStream();
                    file.CopyTo(ms); //copy the file into a memory stream object
                    newStudent.StudentProfilePhoto = ms.ToArray(); //save bytes into newStudent

                    ms.Close();
                    ms.Dispose();
                }*/

           

            if (!ModelState.IsValid)
                return View(new Student());

            _dbData.Students.Add(newStudent);
            _dbData.SaveChanges();
            return RedirectToAction("Index");

        }
        public IActionResult ShowDetails(int id)
        {
            
            Student? student = _dbData.Students.FirstOrDefault(st => st.StudentId == id);

            
            if (student != null)
            {
                /*if(student.StudentProfilePhoto != null)
                {
                    string imageBase64Data = Convert.ToBase64String(student.StudentProfilePhoto);
                    string imageDataURL = string.Format("data:image/jpg;base64, {0}", imageBase64Data);
                    ViewBag.StudentProfilePhoto = imageDataURL;
                }*/
             
                return View(student);

            }

            return NotFound();
        }

        [HttpGet]
        public IActionResult UpdateStudent(int id)
        {
            Student? student = _dbData.Students.FirstOrDefault(st => st.StudentId == id);

            if (student != null)
                return View(student);



            return NotFound();
        }


        [HttpPost]
        public IActionResult UpdateStudent(Student studentChanges)
        {
            Student? student = _dbData.Students.FirstOrDefault(st => st.StudentId == studentChanges.StudentId);
            if (student != null)
            {
                student.StudentFirstName = studentChanges.StudentFirstName;
                student.StudentLastName = studentChanges.StudentLastName;
                student.StudentEmail = studentChanges.StudentEmail;
                student.StudentCourse = studentChanges.StudentCourse;
                student.GPA = studentChanges.GPA;
                student.DateEnrolled = studentChanges.DateEnrolled;
                _dbData.SaveChanges();


            }
            return RedirectToAction("Index");
        }


        [HttpGet]
        public IActionResult DeleteStudent(int id)
        {
            Student? student = _dbData.Students.FirstOrDefault(st => st.StudentId == id);

            if (student != null)
                return View(student);



            return NotFound();
        }


        [HttpPost]
        public IActionResult DeleteStudent(Student newStudent)
        {
            Student? student = _dbData.Students.FirstOrDefault(st => st.StudentId == newStudent.StudentId);

            if (student != null)
                _dbData.Students.Remove(student);
                _dbData.SaveChanges();

            return RedirectToAction("Index");
        }

    }
}

