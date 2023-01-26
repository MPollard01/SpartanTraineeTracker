using TraineeTracker.Domain;

namespace TraineeTracker.Application.UnitTests.TestData
{
    public static class TrainerTestData
    {
        public static List<Trainer> trainers = new List<Trainer>
        {
            new Trainer
            {
                Id = "9e224968-33e4-4652-b7b7-8574d048cdb9",
                Email = "johndoe@sparta.com",
                FirstName = "John",
                LastName = "Doe",
            },
            new Trainer
            {
                Id = "0c1518f6-e6bc-4568-b694-e50fb2a3eac1",
                Email = "janedoe@sparta.com",
                FirstName = "Jane",
                LastName = "Doe",
            }
        };

        public static IEnumerable<object[]> TestTrainerData =>
            new[]
            {
                new object[] 
                { 
                    new Trainer
                    {
                        Id = "9e224968-33e4-4652-b7b7-8574d048cdb9",
                        Email = "johndoe@sparta.com",
                        FirstName = "John",
                        LastName = "Doe",
                        Trainees = TraineeTestData.trainees,
                        Courses = new List<Course> { CourseTestData.courses[0], CourseTestData.courses[1] }
                    },
                    "9e224968-33e4-4652-b7b7-8574d048cdb9"
                },
                new object[]
                {
                    new Trainer
                    {
                        Id = "0c1518f6-e6bc-4568-b694-e50fb2a3eac1",
                        Email = "janedoe@sparta.com",
                        FirstName = "Jane",
                        LastName = "Doe",
                        Trainees = TraineeTestData.trainees,
                        Courses = new List<Course> { CourseTestData.courses[0], CourseTestData.courses[1] }
                    },
                    "0c1518f6-e6bc-4568-b694-e50fb2a3eac1"
                }
            };
    }
}
