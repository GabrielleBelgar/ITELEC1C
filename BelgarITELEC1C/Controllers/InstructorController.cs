using Microsoft.AspNetCore.Mvc;
using BelgarITELEC1C.Models;
using BelgarITELEC1C.Data;
using Microsoft.AspNetCore.Authorization;

namespace BelgarITELEC1C.Controllers
{
    public class InstructorController : Controller
    {
        private readonly AppDbContext _dbData;
        private readonly IWebHostEnvironment _environment;
        public InstructorController(AppDbContext dbData, IWebHostEnvironment environment)
        {
            _dbData = dbData;
            _environment = environment;
        }


        [Authorize]
        public IActionResult Index()
        {
            return View(_dbData.Instructors);
        }

        [HttpGet]
        public IActionResult AddInstructor()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddInstructor(Instructor newInstructor)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            if (Request.Form.Files.Count > 0)
            {
                var file = Request.Form.Files[0];

                MemoryStream ms = new MemoryStream();
                file.CopyTo(ms);
                newInstructor.InstructorProfilePhoto = ms.ToArray();

                ms.Close();
                ms.Dispose();
            }


            _dbData.Instructors.Add(newInstructor);
            _dbData.SaveChanges();
            return RedirectToAction("Index");
        }


        public IActionResult ShowDetails(int id)
        {

            Instructor? instructor = _dbData.Instructors.FirstOrDefault(st => st.InstructorId == id);


            if (instructor != null)
            {
                if (instructor.InstructorProfilePhoto != null)
                {
                    string imageBase64Data = Convert.ToBase64String(instructor.InstructorProfilePhoto);
                    string imageDataURL = string.Format("data:image/jpg;base64, {0}", imageBase64Data);
                    ViewBag.InstructorProfilePhoto = imageDataURL;
                }
                return View(instructor);
            }



            return NotFound();
        }


        [HttpGet]
        public IActionResult UpdateInstructor(int id)
        {
            Instructor? instructor = _dbData.Instructors.FirstOrDefault(st => st.InstructorId == id);

            if (instructor != null)
                return View(instructor);



            return NotFound();
        }


        [HttpPost]
        public IActionResult UpdateInstructor(Instructor instructorChanges)
        {
            Instructor? instructor = _dbData.Instructors.FirstOrDefault(st => st.InstructorId == instructorChanges.InstructorId);
            if (instructor != null)
            {
                instructor.InstructorFirstName = instructorChanges.InstructorFirstName;
                instructor.InstructorLastName = instructorChanges.InstructorLastName;
                instructor.InstructorEmail = instructorChanges.InstructorEmail;
                instructor.DateHired = instructorChanges.DateHired;
                instructor.IsTenured = instructorChanges.IsTenured;
                instructor.Rank = instructorChanges.Rank;
                _dbData.SaveChanges();


            }
            return RedirectToAction("Index");
        }



        [HttpGet]
        public IActionResult DeleteInstructor(int id)
        {

            Instructor? instructor = _dbData.Instructors.FirstOrDefault(st => st.InstructorId == id);
            if (instructor != null)
                return View(instructor);    

            return NotFound();
        }


        [HttpPost]
        public IActionResult DeleteInstructor(Instructor newInstructor)
        {
            Instructor? instructor = _dbData.Instructors.FirstOrDefault(st => st.InstructorId == newInstructor.InstructorId);

            if (instructor != null)
                _dbData.Instructors.Remove(instructor);
                _dbData.SaveChanges();

            return RedirectToAction("Index");
        }

    }
}

