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
        public string InstructorFirstName { get; set; }
        public string InstructorLastName { get; set;}

        public string InstructorEmail { get; set;}
        public DateTime DateHired { get; set; }
        public IsTenured IsTenured { get; set; }
        public Rank Rank { get; set;}


    }
}
