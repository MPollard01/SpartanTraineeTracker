using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

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
        public List<int> CourseIds { get; set; }

        [ValidateNever]
        public MultiSelectList CourseList { get; set; }
    }

    public class RegisterTraineeVM : RegisterVM
    {
        [ValidateNever]
        public SelectList CourseList { get; set; }
        public CourseVM Course { get; set; }
    }
}
