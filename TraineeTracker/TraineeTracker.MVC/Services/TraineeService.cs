using AutoMapper;
using TraineeTracker.MVC.Contracts;
using TraineeTracker.MVC.Models;
using TraineeTracker.MVC.Services.Base;

namespace TraineeTracker.MVC.Services
{
    public class TraineeService : BaseHttpService, ITraineeService
    {
        private readonly IMapper _mapper;
        private readonly IAuthenticationService _authenticationService;
        public TraineeService(IClient client, ILocalStorageService localStorage, IMapper mapper,
            IAuthenticationService authenticationService) 
            : base(client, localStorage)
        {
            _mapper = mapper;
            _authenticationService = authenticationService;
        }

        public async Task<Response<int>> CreateTrainee(RegisterTraineeVM traineeVM)
        {
            try
            {
                var response = new Response<int>();
                var createTrainee = _mapper.Map<CreateTraineeDto>(traineeVM);

                AddBearerToken();
                var userId = await _authenticationService.Register(traineeVM, "Trainee");

                if (string.IsNullOrEmpty(userId))
                {
                    response.ValidationErrors = "Failed to Register";
                    return response;
                }

                createTrainee.Id = userId;
                var apiResponse = await _client.TraineePOSTAsync(createTrainee);

                if (!apiResponse.Success)
                {
                    response.ValidationErrors =
                        string.Join(Environment.NewLine, apiResponse.Errors);

                    return response;
                }

                var trainers = await _client.TrainerAllByCourseAsync(createTrainee.CourseId);

                foreach(var trainer in trainers)
                {
                    var res = await _client.TrainerTraineeAsync(new CreateTrainerTraineeDto
                    {
                        TrainerId = trainer.Id,
                        TraineeId = userId
                    });

                    if (!res.Success)
                    {
                        response.ValidationErrors =
                            string.Join(Environment.NewLine, res.Errors);
                        return response;
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

        public async Task<List<TraineeListVM>> GetTrainees()
        {
            AddBearerToken();
            var trainees = await _client.TraineeAllAsync();
            return _mapper.Map<List<TraineeListVM>>(trainees);
        }
    }
}
