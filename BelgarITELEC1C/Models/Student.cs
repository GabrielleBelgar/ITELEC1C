using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BelgarITELEC1C.Models;
public enum StudentCourse //data type
    {
        BSIT, BSCS, BSIS 
    }

public class Student
{
    public int StudentId { get; set; }


    [Display(Name = "First Name")]
    [Required(ErrorMessage = "Please enter your First Name")]
    public string StudentFirstName { get; set; }


    [Display(Name = "Last Name")]
    [Required(ErrorMessage = "Please enter your Last Name")]
    public string StudentLastName { get; set; }


    public StudentCourse StudentCourse { get; set; }


    [Display(Name = "Email Address")]
    [EmailAddress]
    public string StudentEmail { get; set; }

    [Phone]
    [RegularExpression("[0-9]{2}-[0-90]{3}-[0-9]{4}", ErrorMessage = "You must follow this format 00-000-0000")]
    public string? Phone { get; set; }


    [Display(Name = "Date Enrolled")]
    [DataType(DataType.Date)]
    public DateTime DateEnrolled { get; set; }


    public double GPA { get; set; }

    [NotMapped]
    public IFormFile? UploadedPhoto { get; set; } //get the filename of the photo
    [Display(Name = "Profile Picture")]
    public string? imagePath { get; set; }


}

