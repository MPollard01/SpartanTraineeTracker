using AutoMapper;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using TraineeTracker.MVC.Contracts;
using TraineeTracker.MVC.Models;
using TraineeTracker.MVC.Services.Base;
using IAuthenticationService = TraineeTracker.MVC.Contracts.IAuthenticationService;

namespace TraineeTracker.MVC.Services
{
    public class AuthenticationService : BaseHttpService, IAuthenticationService
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IMapper _mapper;
        private JwtSecurityTokenHandler _tokenHandler;

        public AuthenticationService(IClient client, ILocalStorageService localStorage, 
            IHttpContextAccessor httpContextAccessor, IMapper mapper)
            : base(client, localStorage)
        {
            this._httpContextAccessor = httpContextAccessor;
            this._mapper = mapper;
            this._tokenHandler = new JwtSecurityTokenHandler();

        }

        public async Task<bool> Authenticate(string email, string password)
        {
            try
            {
                AuthRequest authenticationRequest = new() { Email = email, Password = password };
                var authenticationResponse = await _client.LoginAsync(authenticationRequest);

                if (authenticationResponse.Token != string.Empty)
                {
                    //Get Claims from token and Build auth user object
                    var tokenContent = _tokenHandler.ReadJwtToken(authenticationResponse.Token);
                    var claims = ParseClaims(tokenContent);
                    var user = new ClaimsPrincipal(new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme));
                    var login = _httpContextAccessor.HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, user);
                    _localStorage.SetStorageValue("token", authenticationResponse.Token);

                    //if (string.IsNullOrWhiteSpace(_httpContextAccessor.HttpContext.Session.GetString("_Name")))
                    //    _httpContextAccessor.HttpContext.Session.SetString("_Name", email);
                   
                    return true;
                }
                return false;
            }
            catch
            {
                return false;
            }
        }

        public async Task<string> Register(RegisterVM registration, string role)
        {
            RegistrationRequest registrationRequest = _mapper.Map<RegistrationRequest>(registration);
            var response = await _client.RegisterAsync(role, registrationRequest);
            return response.UserId;
        }

        public async Task Logout()
        {
            _localStorage.ClearStorage(new List<string> { "token" });
            await _httpContextAccessor.HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
        }

        private IList<Claim> ParseClaims(JwtSecurityToken tokenContent)
        {
            var claims = tokenContent.Claims.ToList();
            claims.Add(new Claim(ClaimTypes.Name, tokenContent.Subject));
            return claims;
        }

        public async Task<ChangePasswordResponse> ChangePassword(ProfileVM profile)
        {
            try
            {
                ChangePasswordRequest changePasswordRequest = new()
                {
                    UserName = _httpContextAccessor.HttpContext.User.Identity.Name,
                    CurrentPassword = profile.CurrentPassword,
                    NewPassword = profile.NewPassword
                };

                var response = await _client.ChangepasswordAsync(changePasswordRequest);

                if (!response.Succeeded)
                {
                    var errors = string.Join(" ", response.Errors);
                    throw new Exception($"Could Not Change Password: {errors}");
                }

                return response;
            }
            catch (Exception e)
            {
                return new ChangePasswordResponse 
                { 
                    Succeeded = false, Errors = new List<string> { e.Message } 
                };
            }
        }
    }
}
