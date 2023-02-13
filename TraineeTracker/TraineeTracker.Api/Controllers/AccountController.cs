using Microsoft.AspNetCore.Mvc;
using TraineeTracker.Application.Contracts.Identity;
using TraineeTracker.Application.Models.Identity;

namespace TraineeTracker.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IAuthService _authenticationService;
        public AccountController(IAuthService authenticationService)
        {
            _authenticationService = authenticationService;
        }

        [HttpPost("login")]
        public async Task<ActionResult<AuthResponse>> Login(AuthRequest request)
        {
            return Ok(await _authenticationService.Login(request));
        }

        [HttpPost("register")]
        public async Task<ActionResult<RegistrationResponse>> Register(RegistrationRequest request, string role)
        {
            return Ok(await _authenticationService.Register(request, role));
        }

        [HttpPost("changepassword")]
        public async Task<ActionResult<ChangePasswordResponse>> ChangePassword(ChangePasswordRequest request)
        {
            return Ok(await _authenticationService.ChangePassword(request));
        }
    }
}
