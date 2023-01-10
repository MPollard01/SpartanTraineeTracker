using AutoMapper;
using TraineeTracker.MVC.Contracts;
using TraineeTracker.MVC.Models;
using TraineeTracker.MVC.Services.Base;

namespace TraineeTracker.MVC.Services
{
    public class TraineeService : BaseHttpService, ITraineeService
    {
        private readonly IMapper _mapper;
        public TraineeService(IClient client, ILocalStorageService localStorage, IMapper mapper) 
            : base(client, localStorage)
        {
            _mapper = mapper;
        }

        public async Task<Response<int>> CreateTrainee(RegisterTraineeVM traineeVM)
        {
            try
            {
                var response = new Response<int>();
                var createTrainee = _mapper.Map<CreateTraineeDto>(traineeVM);
                AddBearerToken();
                var apiResponse = await _client.TraineePOSTAsync(createTrainee);

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

        public async Task<List<TraineeVM>> GetTrainees()
        {
            AddBearerToken();
            var trainees = await _client.TraineeAllAsync();
            return _mapper.Map<List<TraineeVM>>(trainees);
        }
    }
}
