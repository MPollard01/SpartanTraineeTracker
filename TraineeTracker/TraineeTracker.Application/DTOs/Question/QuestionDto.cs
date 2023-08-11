using TraineeTracker.Application.DTOs.Option;

namespace TraineeTracker.Application.DTOs.Question
{
    public class QuestionDto
    {
        public int Id { get; set; }
        public string Value { get; set; } = null!;
        public List<OptionDto> Options { get; } = new List<OptionDto>();
    }
}
