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

            if (!context.Categories.Any())
            {
                var categories = new List<Category>
                {
                    new Category
                    {
                        Id = 1,
                        Name = "C#"
                    }
                };

                await context.Categories.AddRangeAsync(categories);
            }

            if (!context.SubCategories.Any())
            {
                var subCategories = new List<SubCategory>
                {
                    new SubCategory
                    {
                        Id = 1,
                        Name = ".Net",
                        CategoryId = 1
                    }
                };

                await context.SubCategories.AddRangeAsync(subCategories);
            }

            if (!context.Questions.Any())
            {

                var questions = new List<Question>
                {
                    new Question
                    {
                        Id = 1,
                        Value = "Whats the difference between .NET and C#?",
                        CategoryId = 1
                    },
                    new Question
                    {
                        Id = 2,
                        Value = "Whats the difference between .NET Core and .NET Framework?",
                        CategoryId = 1
                    },
                    new Question
                    {
                        Id = 3,
                        Value = "What is IL code?",
                        CategoryId = 1
                    },
                    new Question
                    {
                        Id = 4,
                        Value = "Who compiles the IL code?",
                        CategoryId = 1
                    },
                    new Question
                    {
                        Id = 5,
                        Value = "How does JIT compilation work?",
                        CategoryId = 1
                    },
                    new Question
                    {
                        Id = 6,
                        Value = "What are the different types of JIT?",
                        CategoryId = 1
                    },
                    new Question
                    {
                        Id = 7,
                        Value = "What is Native Image Generator (Ngen.exe)?",
                        CategoryId = 1
                    },
                    new Question
                    {
                        Id = 8,
                        Value = "What does CLR stand for?",
                        CategoryId = 1
                    },
                    new Question
                    {
                        Id = 9,
                        Value = "What are the 4 primary aspects of the CLR?",
                        CategoryId = 1
                    },
                    new Question
                    {
                        Id = 10,
                        Value = "What is a garbage collector?",
                        CategoryId = 1
                    }
                };

                await context.Questions.AddRangeAsync(questions);
            }

            if (!context.Answers.Any())
            {
                var answers = new List<Answer>
                {
                    new Answer
                    {
                        Id = 1,
                        QuestionId = 1,
                        Value = ".NET is a framework and C# is a programming language",
                        Description = ".NET framework has collection of ready-made libraries. So for example you want List, Dictionary it has “System.collections.dll” , you want to make HTTP calls it has “System.Net.Http.dll” and so on. While C# is programming language uses syntax, grammar, it has “for loops”,” IF” conditions and so on."
                    },
                    new Answer
                    {
                        Id = 2,
                        QuestionId = 2,
                        Value = ".Net framework is only for windows",
                        Description = ".NET 5.0 is a unified platform which unifies all .NET runtime like .NET framework, .NET core , Mono and so on."
                    },
                    new Answer
                    {
                        Id = 3,
                        QuestionId = 2,
                        Value = ".Net core is cross platform",
                        Description = "Developers no longer need to choose between .Net Core, .Net Framework and Mono, based on which platform they’re developing their applications. This provides a common experience to developers irrespective on which .NET version they are working."
                    },
                    new Answer
                    {
                        Id = 4,
                        QuestionId = 3,
                        Value = "Intermediate language code is partially compiled code",
                        Description = "Half compiled means this code is not yet compiled to machine/CPU specific instructions. We do not know in what kind of environment .NET code will run. In other words we do not know what can be the end operating system, CPU configuration, machine configuration, security configuration etc. So the IL code is half compiled and on runtime this code is compiled to machine specific using the environmental properties (CPU,OS, machine configuration etc)."
                    },
                    new Answer
                    {
                        Id = 5,
                        QuestionId = 4,
                        Value = "IL code is compiled by the Just in time compiler",
                        Description = "IL code is compiled by the JIT compiler also know as the Just in time compiler"
                    },
                    new Answer
                    {
                        Id = 6,
                        QuestionId = 5,
                        Value = "JIT compiles the code just before execution",
                        Description = "JIT compiles the code just before execution and then saves this translation in memory. Just before execution JIT can compile per-file, per function or a code fragment."
                    },
                    new Answer
                    {
                        Id = 7,
                        QuestionId = 6,
                        Value = "Normal-JIT",
                        Description = "Normal-JIT compiles only those methods that are called at runtime.\r\nThese methods are compiled the first time they are called, and then they are stored in cache. When the same methods are called again, the compiled code from cache is used for execution."
                    },
                    new Answer
                    {
                        Id = 8,
                        QuestionId = 6,
                        Value = "Econo-JIT",
                        Description = "Econo-JIT compiles only those methods that are called at runtime. However, these\r\ncompiled methods are not stored in cache so that RAM memory can be utilized in an optimal manner."
                    },
                    new Answer
                    {
                        Id = 9,
                        QuestionId = 6,
                        Value = "Pre-JIT",
                        Description = "Pre-JIT compiles complete source code into native code in a single compilation cycle. This is done at the time of deployment of the application. We can implement Pre-jit by using ngen.exe."
                    },
                    new Answer
                    {
                        Id = 10,
                        QuestionId = 7,
                        Value = "Ngen stores fully compiled .NET native code in to cache",
                        Description = "In other words rather than dynamically compiling the code on run time a full image of native compiled code is stored in cache while installing the application. This leads to better performance as the assembly loads and execute faster."
                    },
                    new Answer
                    {
                        Id = 11,
                        QuestionId = 8,
                        Value = "Common language run time",
                        Description = "CLR (Common language run time) is the heart of.NET framework."
                    },
                    new Answer
                    {
                        Id= 12,
                        QuestionId= 9,
                        Value = "Garbage collection",
                    },
                    new Answer
                    {
                        Id= 13,
                        QuestionId= 9,
                        Value = "CAS(Code Access security)",
                    },
                    new Answer
                    {
                        Id= 14,
                        QuestionId= 9,
                        Value = "CV(Code verification)",
                    },
                    new Answer
                    {
                        Id= 15,
                        QuestionId= 9,
                        Value = "IL to native translation",
                    },
                    new Answer
                    {
                        Id = 16,
                        QuestionId = 10,
                        Value = "Garbage collector is a feature of CLR which cleans unused managed objects and reclaims memory",
                        Description = "It’s a back ground thread which runs continuously checks if there are any unused objects whose memory can be claimed. It does not clean unmanaged objects."
                    }
                };

                await context.Answers.AddRangeAsync(answers);
            }

            if (!context.Options.Any())
            {
                var options = new List<Option>
                {
                    new Option
                    {
                        Id = 1,
                        QuestionId = 1,
                        Value = ".NET is a framework and C# is a programming language"
                    },
                    new Option
                    {
                        Id = 2,
                        QuestionId = 1,
                        Value = ".NET is a programming language and C# is a framework"
                    },
                    new Option
                    {
                        Id = 3,
                        QuestionId = 1,
                        Value = "C# and .NET are the same"
                    },
                    new Option
                    {
                        Id = 4,
                        QuestionId = 2,
                        Value = ".NET core is only for windows"
                    },
                    new Option
                    {
                        Id = 5,
                        QuestionId = 2,
                        Value = ".NET framework is only for windows"
                    },
                    new Option
                    {
                        Id = 6,
                        QuestionId = 2,
                        Value = ".NET framework is faster"
                    },
                    new Option
                    {
                        Id = 7,
                        QuestionId = 2,
                        Value = ".NET core is slower"
                    },
                    new Option
                    {
                        Id = 8,
                        QuestionId = 2,
                        Value = ".NET core is cross platform"
                    },
                    new Option
                    {
                        Id = 9,
                        QuestionId = 3,
                        Value = "IL code is fully compiled code"
                    },
                    new Option
                    {
                        Id = 10,
                        QuestionId = 3,
                        Value = "Intermediate language code is partially compiled code"
                    },
                    new Option
                    {
                        Id = 11,
                        QuestionId = 3,
                        Value = "Internal language code is partially compiled code"
                    },
                    new Option
                    {
                        Id= 12,
                        QuestionId = 4,
                        Value = "IL code is compiled by the pre-compiler"
                    },
                    new Option
                    {
                        Id= 13,
                        QuestionId = 4,
                        Value = "IL code is compiled by the just in time compiler"
                    },
                    new Option
                    {
                        Id= 14,
                        QuestionId = 4,
                        Value = "IL code is compiled by the machine language compiler"
                    },
                    new Option
                    {
                        Id = 15,
                        QuestionId = 5,
                        Value = "JIT compiles code after execution"
                    },
                    new Option
                    {
                        Id = 16,
                        QuestionId = 5,
                        Value = "JIT compiles code during execution"
                    },
                    new Option
                    {
                        Id = 17,
                        QuestionId = 5,
                        Value = "JIT compiles the code just before execution"
                    },
                    new Option
                    {
                        Id = 18,
                        QuestionId = 6,
                        Value = "Pre-JIT"
                    },
                    new Option
                    {
                        Id = 19,
                        QuestionId = 6,
                        Value = "Post-JIT"
                    },
                    new Option
                    {
                        Id = 20,
                        QuestionId = 6,
                        Value = "Econo-JIT"
                    },
                    new Option
                    {
                        Id = 21,
                        QuestionId = 6,
                        Value = "Normal-JIT"
                    },
                    new Option
                    {
                        Id = 22,
                        QuestionId = 6,
                        Value = "Pro-JIT"
                    },
                    new Option
                    {
                        Id = 23,
                        QuestionId = 6,
                        Value = "Internal-JIT"
                    },
                    new Option
                    {
                        Id = 24,
                        QuestionId = 7,
                        Value = "Ngen stores fully compiled .NET native code in to cache"
                    },
                    new Option
                    {
                        Id = 25,
                        QuestionId = 7,
                        Value = "Ngen stores partially compiled .NET native code in to cache"
                    },
                    new Option
                    {
                        Id = 26,
                        QuestionId = 7,
                        Value = "Ngen stores fully compiled .NET native code in to RAM"
                    },
                    new Option
                    {
                        Id = 27,
                        QuestionId = 8,
                        Value = "Command line run time"
                    },
                    new Option
                    {
                        Id = 28,
                        QuestionId = 8,
                        Value = "Command line rendering"
                    },
                    new Option
                    {
                        Id = 29,
                        QuestionId = 8,
                        Value = "Common language run time"
                    },
                    new Option
                    {
                        Id = 30,
                        QuestionId = 9,
                        Value = "CLI"
                    },
                    new Option
                    {
                        Id = 31,
                        QuestionId = 9,
                        Value = "CV(Code verification)",
                    },
                    new Option
                    {
                        Id = 32,
                        QuestionId = 9,
                        Value = "CM(Code Manager)",
                    },
                    new Option
                    {
                        Id= 33,
                        QuestionId = 9,
                        Value = "CAS(Code Access Security)",
                    },
                    new Option
                    {
                        Id = 34,
                        QuestionId = 9,
                        Value = "Garbage collection"
                    },
                    new Option
                    {
                        Id = 35,
                        QuestionId = 10,
                        Value = "Garbage collector is a feature of CLR which cleans unused managed objects and reclaims memory"
                    },
                    new Option
                    {
                        Id = 36,
                        QuestionId = 10,
                        Value = "Garbage collector is a feature of CLR which cleans unmanaged objects and reclaims memory"
                    },
                    new Option
                    {
                        Id = 37,
                        QuestionId = 10,
                        Value = "Garbage collector is a feature of CLR which allocates memory to managed objects"
                    }
                };

                await context.Options.AddRangeAsync(options);
            }

            if (context.ChangeTracker.HasChanges())
                await context.SaveChangesAsync();
        }
    }
}
