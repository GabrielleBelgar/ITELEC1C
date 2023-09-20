using Microsoft.AspNetCore.Mvc;
using BelgarITELEC1C.Models;

namespace BelgarITELEC1C.Controllers
{
    public class InstructorController : Controller
    {
        List<Instructor> InstructorList = new List<Instructor>()
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
        public IActionResult Index()
        {
            return View(InstructorList);
        }

        [HttpGet]
        public IActionResult AddInstructor()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddInstructor(Instructor newInstructor)
        {
            InstructorList.Add(newInstructor);
            return View("Index", InstructorList);
        }


        public IActionResult ShowDetails(int id)
        {

            Instructor? instructor = InstructorList.FirstOrDefault(st => st.InstructorId == id);

            if (instructor != null)
             return View(instructor);

            
            
            return NotFound();
        }


        [HttpGet]
        public IActionResult UpdateInstructor(int id)
        {
            Instructor? instructor = InstructorList.FirstOrDefault(st => st.InstructorId == id);

            if (instructor != null)
                return View(instructor);



            return NotFound();
        }


        [HttpPost]
        public IActionResult UpdateInstructor(Instructor instructorChanges)
        {
            Instructor? instructor = InstructorList.FirstOrDefault(st => st.InstructorId == instructorChanges.InstructorId);
            if (instructor != null)
            {
                instructor.InstructorFirstName = instructorChanges.InstructorFirstName;
                instructor.InstructorLastName = instructorChanges.InstructorLastName;
                instructor.InstructorEmail = instructorChanges.InstructorEmail;
                instructor.DateHired = instructorChanges.DateHired;
                instructor.IsTenured = instructorChanges.IsTenured;
                instructor.Rank = instructorChanges.Rank;

            }
            return View("Index", InstructorList);
        }

    }
}

