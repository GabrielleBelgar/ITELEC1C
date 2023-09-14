    namespace BelgarITELEC1C.Models;
    public enum StudentCourse //data type
    {
        BSIT, BSCS, BSIS 
    }

    public class Student
    {
        public int StudentId { get; set; }
        public string StudentName { get; set; }
        public string StudentFirstName { get; set; } 
        public string StudentLastName { get; set; }
        public StudentCourse StudentCourse { get; set; }
        public string StudentEmail { get; set; }
        public DateTime DateEnrolled { get; set; }
        public double GPA { get; set; }




    }

