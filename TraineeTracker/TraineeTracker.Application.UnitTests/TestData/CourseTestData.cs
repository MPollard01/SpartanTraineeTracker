using TraineeTracker.Domain;

namespace TraineeTracker.Application.UnitTests.TestData
{
    public class CourseTestData
    {
        public static List<Course> courses = new List<Course>
        {
            new Course { Id = 1, Title = "C# Developer" },
            new Course { Id = 2, Title = "C# SDET" },
            new Course { Id = 3, Title = "Java Developer" },
            new Course { Id = 4, Title = "Java SDET" }
        };
    }
}
