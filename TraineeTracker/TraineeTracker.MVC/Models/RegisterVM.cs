using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace TraineeTracker.MVC.Models
{
    public class RegisterVM
    {
        [Required]
        [DisplayName("First Name")]
        public string FirstName { get; set; }

        [Required]
        [DisplayName("Last Name")]
        public string LastName { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [DisplayName("Username")]
        public string UserName { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }

    public class RegisterTrainerVM : RegisterVM
    {
        public SelectList TraineeList { get; set; }
        public List<TraineeVM> Trainees  { get; set; }
        public SelectList CourseList { get; set; }
        public List<CourseVM> Courses { get; set; }
    }

    public class RegisterTraineeVM : RegisterVM
    {
        public SelectList TrainerList { get; set; }
        public List<TrainerVM> Trainers { get; set; }
        public SelectList CourseList { get; set; }
        public CourseVM Course { get; set; }
    }
}
