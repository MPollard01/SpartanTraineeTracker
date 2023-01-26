using TraineeTracker.Domain;

namespace TraineeTracker.Application.UnitTests.TestData
{
    public class TraineeTestData
    {
        public static List<Trainee> trainees = new List<Trainee>
        {
            new Trainee
            {
                Id = "7e6adc8b-0a6e-4970-af0c-18f7fe18336d",
                Email = "carlangle@sparta.com",
                FirstName = "Carl",
                LastName = "Angle",
                CourseId = 1,
            },
            new Trainee
            {
                Id = "2cbdecbb-791e-45c0-93de-51abc9b71859",
                Email = "kimsale@sparta.com",
                FirstName = "Kim",
                LastName = "Sale",
                CourseId = 2
            }
        };

        public static IEnumerable<object[]> TestDataTrainees =>
            new[]
            {
                new object[]
                {
                    new Trainee
                    {
                        Id = "7e6adc8b-0a6e-4970-af0c-18f7fe18336d",
                        Email = "carlangle@sparta.com",
                        FirstName = "Carl",
                        LastName = "Angle",
                        CourseId = 1,
                        Course = CourseTestData.courses[0],
                        Trainers = TrainerTestData.trainers
                    },
                    "7e6adc8b-0a6e-4970-af0c-18f7fe18336d"
                },
                new object[]
                {
                    new Trainee
                    {
                        Id = "2cbdecbb-791e-45c0-93de-51abc9b71859",
                        Email = "kimsale@sparta.com",
                        FirstName = "Kim",
                        LastName = "Sale",
                        CourseId = 2,
                        Course = CourseTestData.courses[1],
                        Trainers = TrainerTestData.trainers
                    },
                    "2cbdecbb-791e-45c0-93de-51abc9b71859"
                }
            };
    }
}
