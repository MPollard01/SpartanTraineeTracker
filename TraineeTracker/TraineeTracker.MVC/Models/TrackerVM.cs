using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using TraineeTracker.MVC.Utils;

namespace TraineeTracker.MVC.Models
{
    public class TrackerVM
    {
        public int Id { get; set; }
        public string Start { get; set; } = null!;
        public string Stop { get; set; } = null!;
        public string Continue { get; set; } = null!;
        public DateTime StartDate { get; set; }

        [DisplayName("Technical Skill")]
        public string TechnicalSkill { get; set; } = null!;

        [DisplayName("Consultant Skill")]
        public string ConsultantSkill { get; set; } = null!;
    }

    public class TrackerListVM
    {
        public int Id { get; set; }
        public string Start { get; set; } = null!;
        public string Stop { get; set; } = null!;
        public string Continue { get; set; } = null!;
        public DateTime StartDate { get; set; }
        public string TechnicalSkill { get; set; } = null!;
        public string ConsultantSkill { get; set; } = null!;
        public TraineeListVM Trainee { get; set; }
    }

    public class CreateTrackerVM
    {
        [Required]
        public string Start { get; set; } = null!;

        [Required]
        public string Stop { get; set; } = null!;

        [Required]
        public string Continue { get; set; } = null!;

        public string TechnicalSkill { get; set; }

        [ValidateNever]
        public SelectList TechnicalSkills { get; set; }

        public string ConsultantSkill { get; set; }

        [ValidateNever]
        public SelectList ConsultantSkills { get; set; } = null!;
    }

    public class TrackerTraineeListVM
    {
        public PaginatedList<TrackerVM> Trackers { get; set; }
        public CreateTrackerVM CreateTracker { get; set; }
    }

    public class TrackerTraineeVM
    {
        public TrackerVM Tracker { get; set; }
        public DateTime? Date { get; set; }
        public List<DateTime> DateList { get; set; }
        public CreateTrackerVM CreateTracker { get; set; }
    }
}
