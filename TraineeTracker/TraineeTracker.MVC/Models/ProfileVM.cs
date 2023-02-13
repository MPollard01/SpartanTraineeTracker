using Microsoft.Build.Framework;
using System.ComponentModel;

namespace TraineeTracker.MVC.Models
{
    public class ProfileVM
    {
        [Required]
        [DisplayName("Current Password")]
        public string CurrentPassword { get; set; }

        [Required]
        [DisplayName("New Password")]
        public string NewPassword { get; set; }
    }
}
