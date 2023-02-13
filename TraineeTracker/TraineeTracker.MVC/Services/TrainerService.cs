using AutoMapper;
using TraineeTracker.MVC.Contracts;
using TraineeTracker.MVC.Models;
using TraineeTracker.MVC.Services.Base;

namespace TraineeTracker.MVC.Services
{
    public class TrainerService : BaseHttpService, ITrainerService
    {
        private readonly IMapper _mapper;
        private readonly IAuthenticationService _authenticationService;
        public TrainerService(IClient client, ILocalStorageService localStorage, 
            IMapper mapper, IAuthenticationService authenticationService) 
            : base(client, localStorage)
        {
            _mapper = mapper;
            _authenticationService = authenticationService;
        }

        public async Task<Response<int>> CreateTrainer(RegisterTrainerVM trainerVM)
        {
            try
            {
                var response = new Response<int>();
                var createTrainer = _mapper.Map<CreateTrainerDto>(trainerVM);

                if(trainerVM.CourseIds.Count == 0)
                {
                    response.ValidationErrors = "Must select at least one course";
                    return response;
                }

                AddBearerToken();
                var userId = await _authenticationService.Register(trainerVM, "Trainer");

                if (string.IsNullOrEmpty(userId))
                {
                    response.ValidationErrors = "Failed to Register";
                    return response;
                }

                createTrainer.Id = userId;
                var apiResponse = await _client.TrainerPOSTAsync(createTrainer);

                if (!apiResponse.Success)
                {
                    response.ValidationErrors =
                        string.Join(Environment.NewLine, apiResponse.Errors);

                    return response;
                }

                foreach (var courseId in trainerVM.CourseIds)
                {
                    var trainees = await _client.TraineeAllByCourseAsync(courseId);
                    await _client.TrainerCourseAsync(new CreateTrainerCourseDto
                    {
                        TrainerId = userId,
                        CourseId = courseId
                    });

                    foreach (var trainee in trainees)
                    {

                        var res = await _client.TrainerTraineeAsync(new CreateTrainerTraineeDto
                        {
                            TrainerId = userId,
                            TraineeId = trainee.Id
                        });

                        if (!res.Success)
                        {
                            response.ValidationErrors =
                                string.Join(Environment.NewLine, res.Errors);
                            return response;
                        }
                    }
                }

                response.Data = apiResponse.Id;
                response.Success = true;
                response.Message = apiResponse.Message;

                return response;
            }
            catch (ApiException ex)
            {
                return ConvertApiExceptions<int>(ex);
            }
        }

        public async Task<TrainerVM> GetTrainer(string id)
        {
            AddBearerToken();
            var trainer = await _client.TrainerGETAsync(id);
            return _mapper.Map<TrainerVM>(trainer);
        }

        public async Task<List<TrainerListVM>> GetTrainers()
        {
            AddBearerToken();
            var trainers = await _client.TrainerAllAsync();
            return _mapper.Map<List<TrainerListVM>>(trainers);
        }
    }
}
