using AutoMapper;
using TraineeTracker.MVC.Models;
using TraineeTracker.MVC.Services.Base;

namespace TraineeTracker.MVC
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<TrainerDto, TrainerVM>().ReverseMap();
            CreateMap<TrainerDto, TrainerListVM>().ReverseMap();
            CreateMap<CreateTrainerDto, RegisterTrainerVM>().ReverseMap();

            CreateMap<RegistrationRequest, RegisterVM>().ReverseMap();

            CreateMap<TraineeDto, TraineeVM>().ReverseMap();
            CreateMap<TraineeDetailDto, TraineeVM>().ReverseMap();
            CreateMap<TraineeDto, TraineeListVM>().ReverseMap();
            CreateMap<TraineeCourseDto, TraineesVM>().ReverseMap();
            CreateMap<CreateTraineeDto, RegisterTraineeVM>().ReverseMap();

            CreateMap<CourseDto, CourseVM>().ReverseMap();

            CreateMap<TrackerDto, TrackerVM>().ReverseMap();
            CreateMap<TrackerListDto, TrackerListVM>().ReverseMap();
            CreateMap<TrackerListDto, TrackerVM>().ReverseMap();
            CreateMap<CreateTrackerDto, CreateTrackerVM>().ReverseMap();
        }
    }
}
