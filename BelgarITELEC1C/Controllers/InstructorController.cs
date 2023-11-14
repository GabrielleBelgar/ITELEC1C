using Microsoft.AspNetCore.Mvc;
using BelgarITELEC1C.Models;
using BelgarITELEC1C.Services;

namespace BelgarITELEC1C.Controllers
{
    public class InstructorController : Controller
    {
        private readonly IMyFakeDataService _dummyData;

        public InstructorController(IMyFakeDataService dummyData)
        {
            _dummyData = dummyData;
        }

        public IActionResult Index()
        {
            return View(_dummyData.InstructorList);
        }

        [HttpGet]
        public IActionResult AddInstructor()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddInstructor(Instructor newInstructor)
        {
            _dummyData.InstructorList.Add(newInstructor);
            return RedirectToAction("Index");
        }


        public IActionResult ShowDetails(int id)
        {

            Instructor? instructor = _dummyData.InstructorList.FirstOrDefault(st => st.InstructorId == id);

            if (instructor != null)
             return View(instructor);

            
            
            return NotFound();
        }


        [HttpGet]
        public IActionResult UpdateInstructor(int id)
        {
            Instructor? instructor = _dummyData.InstructorList.FirstOrDefault(st => st.InstructorId == id);

            if (instructor != null)
                return View(instructor);



            return NotFound();
        }


        [HttpPost]
        public IActionResult UpdateInstructor(Instructor instructorChanges)
        {
            Instructor? instructor = _dummyData.InstructorList.FirstOrDefault(st => st.InstructorId == instructorChanges.InstructorId);
            if (instructor != null)
            {
                instructor.InstructorFirstName = instructorChanges.InstructorFirstName;
                instructor.InstructorLastName = instructorChanges.InstructorLastName;
                instructor.InstructorEmail = instructorChanges.InstructorEmail;
                instructor.DateHired = instructorChanges.DateHired;
                instructor.IsTenured = instructorChanges.IsTenured;
                instructor.Rank = instructorChanges.Rank;

            }
            return RedirectToAction("Index");
        }



        [HttpGet]
        public IActionResult DeleteInstructor(int id)
        {

            Instructor? instructor = _dummyData.InstructorList.FirstOrDefault(st => st.InstructorId == id);
            if (instructor != null)
                return View(instructor);    

            return NotFound();
        }


        [HttpPost]
        public IActionResult DeleteInstructor(Instructor newInstructor)
        {
            Instructor? instructor = _dummyData.InstructorList.FirstOrDefault(st => st.InstructorId == newInstructor.InstructorId);

            if (instructor != null)
                _dummyData.InstructorList.Remove(instructor);
            return RedirectToAction("Index");
        }

    }
}

