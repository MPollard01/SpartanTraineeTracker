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

        public async Task<TrackerTraineeVM> GetTracker(DateTime? date)
        {
            AddBearerToken();
            var trackers = await _client.TrackerAllAsync(true);
            var skills = new List<string>
                { "Skilled", "Partially Skilled", "Low Skilled", "Unskilled" };
            var createTracker = new CreateTrackerVM
            {
                TechnicalSkills = new SelectList(skills),
                ConsultantSkills = new SelectList(skills)
            };

            if(trackers.Count == 0)
            {
                return new TrackerTraineeVM
                {
                    Date = date,
                    DateList = new List<DateTime>(),
                    CreateTracker = createTracker
                };
            }

            var dates = trackers.Select(t => t.StartDate).ToList();           
            date ??= trackers.Max(t => t.StartDate);
            var tracker = trackers.FirstOrDefault(t => t.StartDate == date);
       
            return new TrackerTraineeVM
            {
                Tracker = _mapper.Map<TrackerVM>(tracker),
                Date = date,
                DateList = dates,
                CreateTracker = createTracker
            };
        }

        public async Task<PaginatedList<TrackerListVM>> GetTrackers(string searchString, string sortOrder, string[] filters, int? pageNumber)
        {
            AddBearerToken();
            var trackers = await _client.TrackerAllAsync(false);

            filterTrackers(ref trackers, filters);
            searchTrackers(ref trackers, searchString);
            sortTrackers(ref trackers, sortOrder);

            var trackerVMs = _mapper.Map<List<TrackerListVM>>(trackers);

            return PaginatedList<TrackerListVM>.Create(trackerVMs, pageNumber ?? 1, 10);
        }

        public async Task<PaginatedList<TrackerListVM>> GetTrackersByTrainer(string searchString, string sortOrder, string[] filters, int? pageNumber)
        {
            AddBearerToken();
            var trackers = await _client.TrackerAllbyTrainerAsync();

            filterTrackers(ref trackers, filters);
            searchTrackers(ref trackers, searchString);
            sortTrackers(ref trackers, sortOrder);

            var trackerVMs = _mapper.Map<List<TrackerListVM>>(trackers);

            return PaginatedList<TrackerListVM>.Create(trackerVMs, pageNumber ?? 1, 10);
        }

        public async Task<TrackerTraineeListVM> GetTraineeTrackers(string searchString, string sortOrder, string[] filters, int? pageNumber)
        {
            AddBearerToken();
            var trackers = await _client.TrackerAllAsync(true);

            filterTrackers(ref trackers, filters);
            searchTrackers(ref trackers, searchString);
            sortTrackers(ref trackers, sortOrder);

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

        private void filterTrackers(ref ICollection<TrackerListDto> trackers, string[] filters)
        {
            if (filters.Length > 0)
            {
                trackers = trackers
                .Where(t => filters
                .Any(s => s
                .Equals(t.ConsultantSkill) || s
                .Equals(t.TechnicalSkill)))
                .ToList();
            }
        }

        private void searchTrackers(ref ICollection<TrackerListDto> trackers, string searchString)
        {
            if (!string.IsNullOrEmpty(searchString))
            {
                if (int.TryParse(searchString, out int id))
                {
                    trackers = trackers.Where(t => t.Id == id).ToList();
                }
                else
                {
                    trackers = trackers
                        .Where(u => u.Trainee.FirstName.StartsWith(searchString, StringComparison.OrdinalIgnoreCase)
                            || u.Trainee.LastName.StartsWith(searchString, StringComparison.OrdinalIgnoreCase)
                            || u.Start.StartsWith(searchString, StringComparison.OrdinalIgnoreCase)
                            || u.Stop.StartsWith(searchString, StringComparison.OrdinalIgnoreCase)
                            || u.Continue.StartsWith(searchString, StringComparison.OrdinalIgnoreCase)
                            || u.StartDate.ToShortDateString() == searchString)
                        .ToList();
                }
            }
        }

        private void sortTrackers(ref ICollection<TrackerListDto> trackers, string sortOrder)
        {
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
        }
    }
}
