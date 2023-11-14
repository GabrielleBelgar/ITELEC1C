using System.ComponentModel.DataAnnotations;

namespace BelgarITELEC1C.Models
{
    public enum Rank
    {
        Instructor, AssistantProfessor, Professor, AssociateProfessor
    }

    public enum IsTenured
    {
        Permanent, Probationary
    }
    public class Instructor
    {
        public int InstructorId { get; set; }
        public string InstructorName { get; set; }

        [Display(Name ="First Name")]
        public string InstructorFirstName { get; set; }
        public string InstructorLastName { get; set;}

        public string InstructorEmail { get; set;}

        [Display(Name = "Date Hired")]
        public DateTime DateHired { get; set; }
        public IsTenured IsTenured { get; set; }

        [Display(Name = "Academic Rank")]
        public Rank Rank { get; set;}


    }
}
