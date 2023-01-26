using AutoMapper;
using TraineeTracker.MVC.Contracts;
using TraineeTracker.MVC.Models;
using TraineeTracker.MVC.Services.Base;
using TraineeTracker.MVC.Utils;

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

        public async Task<TraineeVM> GetTraineeDetails(string id)
        {
            AddBearerToken();
            var trainee = await _client.TraineeGETAsync(id);
            return _mapper.Map<TraineeVM>(trainee);
        }

        public async Task<List<TraineeListVM>> GetTrainees()
        {
            AddBearerToken();
            var trainees = await _client.TraineeAllAsync();
            return _mapper.Map<List<TraineeListVM>>(trainees);
        }

        public async Task<TrainerViewTraineesVM> GetTraineesByTrainer(string searchString, string sortOrder, string[] filters, int? pageNumber)
        {
            AddBearerToken();
            var trainees = await _client.TraineeAllByTrainerAsync();
            var courses = trainees.Select(t => t.Course.Title).Distinct().ToList();

            if(filters.Length > 0)
                trainees = trainees
                    .Where(t => filters
                    .Any(f => t.Course.Title == f))
                    .ToList();

            if (!string.IsNullOrEmpty(searchString))
            {
                    trainees = trainees
                    .Where(t => t.FirstName
                    .StartsWith(searchString, StringComparison.OrdinalIgnoreCase) || t.LastName
                    .StartsWith(searchString, StringComparison.OrdinalIgnoreCase) || t.Course.Title
                    .StartsWith(searchString, StringComparison.OrdinalIgnoreCase) || t.Id
                    .StartsWith(searchString, StringComparison.OrdinalIgnoreCase))
                    .ToList();
            }

            switch (sortOrder)
            {
                case "firstname":
                    trainees = trainees.OrderBy(t => t.FirstName).ToList();
                    break;
                case "lastname":
                    trainees = trainees.OrderBy(t => t.LastName).ToList();
                    break;
                case "id":
                    trainees = trainees.OrderBy(t => t.Id).ToList();
                    break;
                case "course":
                    trainees = trainees.OrderBy(t => t.Course.Title).ToList();
                    break;
            }

            var traineeList = _mapper.Map<List<TraineesVM>>(trainees);

            return new TrainerViewTraineesVM
            {
                Trainees = PaginatedList<TraineesVM>.Create(traineeList, pageNumber ?? 1, 10),
                Courses = courses
            };
        }
    }
}
