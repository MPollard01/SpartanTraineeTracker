using AutoMapper;
using Newtonsoft.Json;
using NuGet.Protocol;
using TraineeTracker.MVC.Contracts;
using TraineeTracker.MVC.Models;
using TraineeTracker.MVC.Services.Base;

namespace TraineeTracker.MVC.Services
{
    public class HomeService : BaseHttpService, IHomeService
    {
        private readonly IMapper _mapper;
        public HomeService(IClient client, ILocalStorageService localStorage, IMapper mapper) 
            : base(client, localStorage)
        {
            _mapper = mapper;
        }

        public async Task<AdminHomeVM> GetAdminHome()
        {
            AddBearerToken();

            int trainerCount = (await _client.TrainerAllAsync()).Count;
            int traineeCount = (await _client.TraineeAllAsync()).Count;
            int userCount = trainerCount + traineeCount;
            var trackers = await _client.TrackerAllAsync(false);
            int trackerCount = trackers.Count;

            int[] skillCount = new int[4];
            int[] techSkillCount = new int[4];
            int[] trackerMonths = new int[12];

            GetChartInfo(skillCount, techSkillCount, trackerMonths, trackers);

            return new AdminHomeVM
            {
                UserCount = userCount,
                TrackerCount = trackerCount,
                TrainerCount = trainerCount,
                TraineeCount = traineeCount,
                ConsultantSkillCount = skillCount,
                TechnicalSkillCount = techSkillCount,
                TrackersPerMonth = trackerMonths
            };
        }

        public async Task<TraineeHomeVM> GetTraineeHome()
        {
            AddBearerToken();
            var trackers = await _client.TrackerAllAsync(true);
            int[] skillCount = new int[4];
            int[] techSkillCount = new int[4];

            GetChartInfo(skillCount, techSkillCount, trackers);

            DateTime thisMonday = DateTime.Today.AddDays(-(int)DateTime.Today.DayOfWeek + 1);

            return new TraineeHomeVM
            {
                Trackers = _mapper.Map<List<TrackerVM>>(trackers).ToJson(),
                HasThisWeeksTracker = trackers.Any(t => t.StartDate == thisMonday),
                ConsultantSkillCount = skillCount,
                TechnicalSkillCount = techSkillCount,
                Token = _localStorage.GetStorageValue<string>("token")
            };
        }

        public async Task<TrainerHomeVM> GetTrainerHome()
        {
            AddBearerToken();

            int traineeCount = (await _client.TraineeAllByTrainerAsync()).Count;
            var trackers = await _client.TrackerAllbyTrainerAsync();
            int trackerCount = trackers.Count;

            int[] skillCount = new int[4];
            int[] techSkillCount = new int[4];
            int[] trackerMonths = new int[12];

            GetChartInfo(skillCount, techSkillCount, trackerMonths, trackers);

            return new TrainerHomeVM
            {
                TrackerCount = trackerCount,
                TraineeCount = traineeCount,
                ConsultantSkillCount = skillCount,
                TechnicalSkillCount = techSkillCount,
                TrackersPerMonth = trackerMonths
            };
        }

        private void GetChartInfo(int[] skillCount, int[] techSkillCount, int[] trackerMonths, ICollection<TrackerListDto> trackers)
        {
            foreach (var tracker in trackers)
            {
                if (tracker.ConsultantSkill == "Skilled") skillCount[0]++;
                if (tracker.ConsultantSkill == "Partially Skilled") skillCount[1]++;
                if (tracker.ConsultantSkill == "Low Skilled") skillCount[2]++;
                if (tracker.ConsultantSkill == "Unskilled") skillCount[3]++;
                if (tracker.TechnicalSkill == "Skilled") techSkillCount[0]++;
                if (tracker.TechnicalSkill == "Partially Skilled") techSkillCount[1]++;
                if (tracker.TechnicalSkill == "Low Skilled") techSkillCount[2]++;
                if (tracker.TechnicalSkill == "Unskilled") techSkillCount[3]++;

                if (tracker.StartDate.Year == DateTime.Now.Year)
                {
                    for (int month = 1, i = 0; i < trackerMonths.Length; i++, month++)
                        if (tracker.StartDate.Month == month) trackerMonths[i]++;
                }

            }
        }

        private void GetChartInfo(int[] skillCount, int[] techSkillCount, ICollection<TrackerListDto> trackers)
        {
            foreach (var tracker in trackers)
            {
                if (tracker.ConsultantSkill == "Skilled") skillCount[0]++;
                if (tracker.ConsultantSkill == "Partially Skilled") skillCount[1]++;
                if (tracker.ConsultantSkill == "Low Skilled") skillCount[2]++;
                if (tracker.ConsultantSkill == "Unskilled") skillCount[3]++;
                if (tracker.TechnicalSkill == "Skilled") techSkillCount[0]++;
                if (tracker.TechnicalSkill == "Partially Skilled") techSkillCount[1]++;
                if (tracker.TechnicalSkill == "Low Skilled") techSkillCount[2]++;
                if (tracker.TechnicalSkill == "Unskilled") techSkillCount[3]++;

            }
        }
    }
}
