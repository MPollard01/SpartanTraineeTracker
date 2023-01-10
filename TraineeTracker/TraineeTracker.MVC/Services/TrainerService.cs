using AutoMapper;
using TraineeTracker.MVC.Contracts;
using TraineeTracker.MVC.Models;
using TraineeTracker.MVC.Services.Base;

namespace TraineeTracker.MVC.Services
{
    public class TrainerService : BaseHttpService, ITrainerService
    {
        private readonly IMapper _mapper;
        public TrainerService(IClient client, ILocalStorageService localStorage, IMapper mapper) 
            : base(client, localStorage)
        {
            _mapper = mapper;
        }

        public async Task<Response<int>> CreateTrainer(RegisterTrainerVM trainerVM)
        {
            try
            {
                var response = new Response<int>();
                var createTrainer = _mapper.Map<CreateTrainerDto>(trainerVM);
                AddBearerToken();
                var apiResponse = await _client.TrainerPOSTAsync(createTrainer);

                if (apiResponse.Success)
                {
                    response.Data = apiResponse.Id;
                    response.Success = true;
                    response.Message = apiResponse.Message;
                }
                else
                {
                    response.ValidationErrors =
                        string.Join(Environment.NewLine, apiResponse.Errors);
                }

                return response;
            }
            catch (ApiException ex)
            {
                return ConvertApiExceptions<int>(ex);
            }
        }

        public async Task<List<TrainerVM>> GetTrainers()
        {
            AddBearerToken();
            var trainers = await _client.TrainerAllAsync();
            return _mapper.Map<List<TrainerVM>>(trainers);
        }
    }
}
