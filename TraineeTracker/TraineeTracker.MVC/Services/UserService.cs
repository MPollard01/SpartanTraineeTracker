using AutoMapper;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections;
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
            var courses = await _client.CourseAllAsync();
            var trainerVMs = _mapper.Map<List<TrainerListVM>>(trainers);
            var traineesVMs = _mapper.Map<List<TraineeListVM>>(trainees);
            var courseList = new SelectList(courses, "Id", "Title");
            var users = new ArrayList();
            
            users.AddRange(trainerVMs);
            users.AddRange(traineesVMs);

            return new UserAdminViewVM
            {
                Users = users,
                RegisterTrainers = new RegisterTrainerVM
                {
                    CourseList = courseList,
                },
                RegisterTrainees = new RegisterTraineeVM
                {
                    CourseList = courseList
                }
            };
        }
    }
}
