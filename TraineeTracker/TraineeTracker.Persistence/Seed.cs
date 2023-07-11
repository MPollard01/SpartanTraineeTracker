using TraineeTracker.Domain;

namespace TraineeTracker.Persistence
{
    public class Seed
    {
        public static async Task SeedData(TraineeTrackerDbContext context)
        {
            if (!context.Course.Any())
            {
                var courses = new List<Course>
                {
                    new Course { Id = 1, Title = "C# Developer" },
                    new Course { Id = 2, Title = "C# SDET" },
                    new Course { Id = 3, Title = "Java Developer" },
                    new Course { Id = 4, Title = "Java SDET" }
                };

                await context.Course.AddRangeAsync(courses);
            }

            if (!context.Trainer.Any())
            {
                var trainers = new List<Trainer>
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

                await context.Trainer.AddRangeAsync(trainers);
            }

            if (!context.Trainee.Any())
            {
                var trainees = new List<Trainee>
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

                await context.Trainee.AddRangeAsync(trainees);
            }

            if (!context.TrainerTrainee.Any())
            {
                var trainerTrainees = new List<TrainerTrainee>
                {
                    new TrainerTrainee
                    {
                        TrainerId = "9e224968-33e4-4652-b7b7-8574d048cdb9",
                        TraineeId = "7e6adc8b-0a6e-4970-af0c-18f7fe18336d"
                    },
                    new TrainerTrainee
                    {
                        TrainerId = "9e224968-33e4-4652-b7b7-8574d048cdb9",
                        TraineeId = "2cbdecbb-791e-45c0-93de-51abc9b71859"
                    },
                    new TrainerTrainee
                    {
                        TrainerId = "0c1518f6-e6bc-4568-b694-e50fb2a3eac1",
                        TraineeId = "7e6adc8b-0a6e-4970-af0c-18f7fe18336d"
                    },
                    new TrainerTrainee
                    {
                        TrainerId = "0c1518f6-e6bc-4568-b694-e50fb2a3eac1",
                        TraineeId = "2cbdecbb-791e-45c0-93de-51abc9b71859"
                    }
                };

                await context.TrainerTrainee.AddRangeAsync(trainerTrainees);
            }

            if (!context.TrainerCourse.Any())
            {
                var trainerCourses = new List<TrainerCourse>
                {
                    new TrainerCourse
                    {
                        TrainerId = "9e224968-33e4-4652-b7b7-8574d048cdb9",
                        CourseId = 1
                    },
                    new TrainerCourse
                    {
                        TrainerId = "9e224968-33e4-4652-b7b7-8574d048cdb9",
                        CourseId = 2
                    },
                    new TrainerCourse
                    {
                        TrainerId = "0c1518f6-e6bc-4568-b694-e50fb2a3eac1",
                        CourseId = 1
                    },
                    new TrainerCourse
                    {
                        TrainerId = "0c1518f6-e6bc-4568-b694-e50fb2a3eac1",
                        CourseId = 2
                    }
                };

                await context.TrainerCourse.AddRangeAsync(trainerCourses);
            }

            if (!context.Tracker.Any())
            {
                var trackers = new List<Tracker>
                {
                    new Tracker
                    {
                        Id = 1,
                        Start = "Studying every day",
                        Stop = "Making silly mistakes",
                        Continue = "Learning C#",
                        StartDate = new DateTime(2022, 10, 12, 0, 0, 0, DateTimeKind.Utc),
                        CreatedDate = new DateTime(2022, 10, 12, 0, 0, 0, DateTimeKind.Utc),
                        TechnicalSkill = "Skilled",
                        ConsultantSkill = "Partially Skilled",
                        TraineeId = "7e6adc8b-0a6e-4970-af0c-18f7fe18336d",
                        CreatedBy = "Carl Angle"
                    }
                };
                
                await context.Tracker.AddRangeAsync(trackers);
            }

            if (context.ChangeTracker.HasChanges())
                await context.SaveChangesAsync();
        }
    }
}
