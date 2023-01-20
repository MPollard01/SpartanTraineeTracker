using AutoMapper;
using Microsoft.AspNetCore.Mvc.Rendering;
using TraineeTracker.MVC.Contracts;
using TraineeTracker.MVC.Models;
using TraineeTracker.MVC.Services.Base;
using TraineeTracker.MVC.Utils;

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

        public async Task<UserAdminViewVM> GetUserAdminList(string searchString, 
            string sortOrder, string[] filter, int? pageNumber)
        {
            AddBearerToken();

            var trainers = await _client.TrainerAllAsync();
            var trainees = await _client.TraineeAllAsync();
            var courses = await _client.CourseAllAsync();
            var trainerVMs = _mapper.Map<List<TrainerListVM>>(trainers);
            var traineeVMs = _mapper.Map<List<TraineeListVM>>(trainees);
            var courseList = new SelectList(courses, "Id", "Title");
            var users = new List<UserListVM>();

            if (filter.Length > 0)
            {
                if(filter.Contains("trainer"))
                    users.AddRange(trainerVMs);
                if(filter.Contains("trainee"))
                    users.AddRange(traineeVMs);
            }
            else
            {
                users.AddRange(trainerVMs);
                users.AddRange(traineeVMs);
            }

            if (!string.IsNullOrEmpty(searchString))
            {
                users = users.Where(u => u.FirstName.StartsWith(searchString, StringComparison.OrdinalIgnoreCase)
                                        || u.LastName.StartsWith(searchString, StringComparison.OrdinalIgnoreCase)).ToList();
            }

            switch (sortOrder)
            {
                case "firstname":
                    users = users.OrderBy(u => u.FirstName).ToList();
                    break;
                case "lastname":
                    users = users.OrderBy(u => u.LastName).ToList();
                    break;
                case "id":
                    users = users.OrderBy(u => u.Id).ToList();
                    break;
                case "email":
                    users = users.OrderBy(u => u.Email).ToList();
                    break;
                case "role":
                    users.Reverse();
                    break;
            }
            
            return new UserAdminViewVM
            {
                Users = PaginatedList<UserListVM>.Create(users, pageNumber ?? 1, 5),
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
