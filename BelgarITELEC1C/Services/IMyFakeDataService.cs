using BelgarITELEC1C.Models;

namespace BelgarITELEC1C.Services
{
    public interface IMyFakeDataService
    {
            List<Student> StudentList { get; }
            List<Instructor> InstructorList { get; }
    }
}
