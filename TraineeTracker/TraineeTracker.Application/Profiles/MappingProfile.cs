using AutoMapper;
using TraineeTracker.Application.DTOs.Answer;
using TraineeTracker.Application.DTOs.Category;
using TraineeTracker.Application.DTOs.Course;
using TraineeTracker.Application.DTOs.Option;
using TraineeTracker.Application.DTOs.Question;
using TraineeTracker.Application.DTOs.SubCategory;
using TraineeTracker.Application.DTOs.Tracker;
using TraineeTracker.Application.DTOs.Trainee;
using TraineeTracker.Application.DTOs.TraineeAnswer;
using TraineeTracker.Application.DTOs.TraineeTest;
using TraineeTracker.Application.DTOs.Trainer;
using TraineeTracker.Application.DTOs.TrainerCourse;
using TraineeTracker.Application.DTOs.TrainerTrainee;
using TraineeTracker.Domain;

namespace TraineeTracker.Application.Profiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Trainer, TrainerDto>().ReverseMap();
            CreateMap<Trainer, TrainerDetailDto>().ReverseMap();
            CreateMap<Trainer, TrainerForTraineeDetailDto>().ReverseMap();
            CreateMap<Trainer, CreateTrainerDto>().ReverseMap();

            CreateMap<Trainee, TraineeDto>().ReverseMap();
            CreateMap<Trainee, TraineeDetailDto>().ReverseMap();         
            CreateMap<Trainee, TraineeForTrainerDetailDto>().ReverseMap();         
            CreateMap<Trainee, TraineeCourseDto>().ReverseMap();         
            CreateMap<Trainee, CreateTraineeDto>().ReverseMap();

            CreateMap<Tracker, TrackerDto>().ReverseMap();
            CreateMap<Tracker, CreateTrackerDto>().ReverseMap();
            CreateMap<Tracker, TrackerListDto>().ReverseMap();

            CreateMap<Course, CourseDto>().ReverseMap();
            CreateMap<Course, CreateCourseDto>().ReverseMap();

            CreateMap<TrainerTrainee, TrainerTraineeDto>().ReverseMap();
            CreateMap<TrainerTrainee, CreateTrainerTraineeDto>().ReverseMap();
            CreateMap<TrainerCourse, TrainerCourseDto>().ReverseMap();
            CreateMap<TrainerCourse, CreateTrainerCourseDto>().ReverseMap();

            CreateMap<Question, QuestionDto>().ReverseMap();
            CreateMap<Answer, AnswerDto>().ReverseMap();
            CreateMap<Option, OptionDto>().ReverseMap();
            CreateMap<Category, CategoryDto>().ReverseMap();
            CreateMap<Category, CategoryDetailDto>().ReverseMap();
            CreateMap<SubCategory, SubCategoryDto>().ReverseMap();
            CreateMap<SubCategory, SubCategoryDetailDto>().ReverseMap();

            CreateMap<TraineeTest, TraineeTestDto>().ReverseMap();
            CreateMap<TraineeTest, TraineeTestDetailDto>().ReverseMap();
            CreateMap<TraineeTest, TraineeTestWithCategoryDto>().ReverseMap();
            CreateMap<TraineeTest, CreateTraineeTestDto>().ReverseMap();

            CreateMap<TraineeAnswer, TraineeAnswerDto>().ReverseMap();
            CreateMap<TraineeAnswer, CreateTraineeAnswerDto>().ReverseMap();
        }
    }
}
