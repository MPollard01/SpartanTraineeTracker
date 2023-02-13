using AutoMapper;
using TraineeTracker.Application.Constants;
using TraineeTracker.MVC.Contracts;
using TraineeTracker.MVC.Models;
using TraineeTracker.MVC.Services.Base;

namespace TraineeTracker.MVC.Services
{
    public class ProfileService : BaseHttpService, IProfileService
    {
        private readonly IMapper _mapper;
        private readonly IHttpContextAccessor _httpContextAccessor;
        public ProfileService(IClient client, ILocalStorageService localStorage, IMapper mapper,
            IHttpContextAccessor httpContextAccessor) 
            : base(client, localStorage)
        {
            _mapper = mapper;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<TraineeVM> GetTraineeProfile()
        {
            AddBearerToken();
            var id = _httpContextAccessor.HttpContext.User.FindFirst(
                    q => q.Type == CustomClaimTypes.Uid)?.Value;
            var trainee = await _client.TraineeGETAsync(id);
            return _mapper.Map<TraineeVM>(trainee);
        }
    }
}
