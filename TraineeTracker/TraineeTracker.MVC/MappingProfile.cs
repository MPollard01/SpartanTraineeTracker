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
            CreateMap<TraineeDto, TraineeListVM>().ReverseMap();

            CreateMap<CourseDto, CourseVM>().ReverseMap();
        }
    }
}
