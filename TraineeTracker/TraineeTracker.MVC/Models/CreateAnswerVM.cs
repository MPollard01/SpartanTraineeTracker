using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace TraineeTracker.MVC.Models
{
    public class CreateAnswerVM
    {
        public int QuestionId { get; set; }

        [BindProperty, Required]
        public List<string> Answers { get; set; }
    }
}
