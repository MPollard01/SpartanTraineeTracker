namespace TraineeTracker.Application.Models.Identity
{
    public class ChangePasswordRequest
    {
        public string UserName { get; set; }
        public string CurrentPassword { get; set; }
        public string NewPassword { get; set; }
    }
}
