using AutoMapper;
using Microsoft.AspNetCore.Mvc.Rendering;
using TraineeTracker.MVC.Contracts;
using TraineeTracker.MVC.Models;
using TraineeTracker.MVC.Services.Base;

namespace TraineeTracker.MVC.Services
{
    public class UserService : BaseHttpService, IUserService
    {
        private readonly IMapper _mapper;
        public UserService(IClient client, ILocalStorageService localStorage, IMapper mapper) 
            : base(client, localStorage)
        {
            _mapper = mapper;
        }

        public async Task<UserAdminViewVM> GetUserAdminList()
        {
            AddBearerToken();

            var trainers = await _client.TrainerAllAsync();
            var trainees = await _client.TraineeAllAsync();
            var trainerVMs = _mapper.Map<List<TrainerVM>>(trainers);
            var traineesVMs = _mapper.Map<List<TraineeVM>>(trainees);
            var trainerList = new SelectList(trainers, "Id", "LastName");
            var traineeList = new SelectList(trainees, "Id", "LastName");

            return new UserAdminViewVM
            {
                Trainers = trainerVMs,
                Trainees = traineesVMs,
                RegisterTrainers = new RegisterTrainerVM { TraineeList = traineeList },
                RegisterTrainees = new RegisterTraineeVM { TrainerList = trainerList }
            };
        }
    }
}
