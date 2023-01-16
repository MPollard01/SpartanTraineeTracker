namespace TraineeTracker.Application.DTOs.Trainee
{
    public class TraineeDto : ITraineeDto
    {
        public string Id { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
    }
}
