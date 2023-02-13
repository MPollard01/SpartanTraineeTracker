namespace TraineeTracker.Application.Models.Identity
{
    public class ChangePasswordResponse
    {
        public bool Succeeded { get; set; }
        public IEnumerable<string> Errors { get; set; }
    }
}
