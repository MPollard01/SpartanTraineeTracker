using AutoMapper;
using TraineeTracker.MVC.Contracts;
using TraineeTracker.MVC.Models;
using TraineeTracker.MVC.Services.Base;
using TraineeTracker.MVC.Utils;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace TraineeTracker.MVC.Services
{
    public class TrackerService : BaseHttpService, ITrackerService
    {
        private readonly IMapper _mapper;

        public TrackerService(IClient client, ILocalStorageService localStorage, IMapper mapper) 
            : base(client, localStorage)
        {
            _mapper = mapper;
        }

        public async Task<Response<int>> CreateTracker(CreateTrackerVM trackerVM)
        {
            try
            {
                var response = new Response<int>();
                var createTracker = _mapper.Map<CreateTrackerDto>(trackerVM);
                AddBearerToken();
                var apiResponse = await _client.TrackerPOSTAsync(createTracker);

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

        public async Task<TrackerTraineeVM> GetTracker(int id)
        {
            AddBearerToken();
            var trainer = await _client.TrackerGETAsync(id);
            var skills = new List<string> 
                { "Skilled", "Partially Skilled", "Low Skilled", "Unskilled" };

            return new TrackerTraineeVM
            {
                Tracker = _mapper.Map<TrackerVM>(trainer),
                CreateTracker = new CreateTrackerVM
                {
                    TechnicalSkills = new SelectList(skills),
                    ConsultantSkills = new SelectList(skills)
                }
            };
        }

        public async Task<PaginatedList<TrackerListVM>> GetTrackers(string searchString, string sortOrder, string[] filters, int? pageNumber)
        {
            AddBearerToken();
            var trackers = await _client.TrackerAllAsync(false);

            foreach(var filter in filters)
            {
                trackers = trackers.Where(t => t.TechnicalSkill == filter 
                    || t.ConsultantSkill == filter).ToList();
            }

            if (!string.IsNullOrEmpty(searchString))
            {
                if(int.TryParse(searchString, out int id))
                {
                    trackers = trackers.Where(t => t.Id == id).ToList();
                }
                else
                {
                    trackers = trackers.Where(u => u.Trainee.FirstName.StartsWith(searchString, StringComparison.OrdinalIgnoreCase)
                                       || u.Trainee.LastName.StartsWith(searchString, StringComparison.OrdinalIgnoreCase)).ToList();
                }           
            }

            switch (sortOrder)
            {
                case "firstname":
                    trackers = trackers.OrderBy(u => u.Trainee.FirstName).ToList();
                    break;
                case "lastname":
                    trackers = trackers.OrderBy(u => u.Trainee.LastName).ToList();
                    break;
                case "id":
                    trackers = trackers.OrderBy(u => u.Id).ToList();
                    break;
                case "technical":
                    trackers = trackers.OrderBy(t => t.TechnicalSkill).ToList();
                    break;
                case "consultant":
                    trackers = trackers.OrderBy(t => t.ConsultantSkill).ToList();
                    break;
                case "date":
                    trackers = trackers.OrderBy(t => t.StartDate).ToList();
                    break;
            }

            var trackerVMs = _mapper.Map<List<TrackerListVM>>(trackers);

            return PaginatedList<TrackerListVM>.Create(trackerVMs, pageNumber ?? 1, 10);
        }

        public async Task<TrackerTraineeListVM> GetTraineeTrackers(string searchString, string sortOrder, string[] filters, int? pageNumber)
        {
            AddBearerToken();
            var trackers = await _client.TrackerAllAsync(true);

            foreach (var filter in filters)
            {
                trackers = trackers.Where(t => t.TechnicalSkill == filter
                    || t.ConsultantSkill == filter).ToList();
            }

            if (!string.IsNullOrEmpty(searchString))
            {
                if (int.TryParse(searchString, out int id))
                {
                    trackers = trackers.Where(t => t.Id == id).ToList();
                }
               
            }

            switch (sortOrder)
            {
                case "id":
                    trackers = trackers.OrderBy(u => u.Id).ToList();
                    break;
                case "technical":
                    trackers = trackers.OrderBy(t => t.TechnicalSkill).ToList();
                    break;
                case "consultant":
                    trackers = trackers.OrderBy(t => t.ConsultantSkill).ToList();
                    break;
                case "date":
                    trackers = trackers.OrderBy(t => t.StartDate).ToList();
                    break;

            }

            var skills = new List<string> 
                { "Skilled", "Partially Skilled", "Low Skilled", "Unskilled" };
            var trackerList = _mapper.Map<List<TrackerVM>>(trackers);

            return new TrackerTraineeListVM
            {
                Trackers = PaginatedList<TrackerVM>.Create(trackerList, pageNumber ?? 1, 10),
                CreateTracker = new CreateTrackerVM
                {
                    TechnicalSkills = new SelectList(skills),
                    ConsultantSkills = new SelectList(skills)
                }
            };
        }
    }
}
