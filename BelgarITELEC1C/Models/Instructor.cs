using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

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
        [Key]
        [Display(Name = "Id")]
        public int InstructorId { get; set; }

        [Required]
        [Display(Name ="First Name")]
        public string InstructorFirstName { get; set; }
        [Required(ErrorMessage = "Please enter your First Name")]
      

        [Display(Name = "Last Name")]
        public string InstructorLastName { get; set; }
        [Required(ErrorMessage = "Please enter your Last Name")]
        


        [Display(Name = "Email Address")]
        [EmailAddress]
        public string? InstructorEmail { get; set; }


        [Phone]
        [RegularExpression("[0-9]{2}-[0-90]{3}-[0-9]{4}", ErrorMessage = "You must follow this format 00-000-0000")]
        public string? Phone { get; set; }


        [Display(Name = "Date Hired")]
        [DataType(DataType.Date)]
        public DateTime DateHired { get; set; }


        [Display(Name = "Status")]
        public IsTenured IsTenured { get; set; }


        [Display(Name = "Academic Rank")]
        public Rank Rank { get; set;}


        [Display(Name = "Profile Picture")]
        public byte[]? InstructorProfilePhoto { get; set; }

    }
}
