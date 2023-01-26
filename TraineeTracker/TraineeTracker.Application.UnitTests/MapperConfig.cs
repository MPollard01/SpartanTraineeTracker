using AutoMapper;
using TraineeTracker.Application.Profiles;

namespace TraineeTracker.Application.UnitTests
{
    internal class MapperConfig
    {
        public static IMapper Configure()
        {
            return new MapperConfiguration(c => c
                .AddProfile<MappingProfile>())
                .CreateMapper();
        }
    }
}
