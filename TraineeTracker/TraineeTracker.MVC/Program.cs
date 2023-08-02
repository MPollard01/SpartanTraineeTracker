using Microsoft.AspNetCore.Authentication.Cookies;
using System.Reflection;
using TraineeTracker.MVC.Contracts;
using TraineeTracker.MVC.Middleware;
using TraineeTracker.MVC.Services;
using TraineeTracker.MVC.Services.Base;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddHttpContextAccessor();
builder.Services.Configure<CookiePolicyOptions>(options =>
{
    options.MinimumSameSitePolicy = SameSiteMode.None;
});

builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie();
builder.Services.AddTransient<IAuthenticationService, AuthenticationService>();

builder.Services.AddHttpClient<IClient, Client>(c => c.BaseAddress = new Uri(builder.Environment.IsDevelopment() ? "https://localhost:7162" : "https://traineetrackerapi.fly.dev"));
builder.Services.AddAutoMapper(Assembly.GetExecutingAssembly());
builder.Services.AddSingleton<ILocalStorageService, LocalStorageService>();
builder.Services.AddScoped<ITraineeService, TraineeService>();
builder.Services.AddScoped<ITrainerService, TrainerService>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<ITrackerService, TrackerService>();
builder.Services.AddScoped<IHomeService, HomeService>();
builder.Services.AddScoped<IProfileService, ProfileService>();
builder.Services.AddScoped<ITestService, TestService>();

builder.Services.AddControllersWithViews();

//builder.Services.AddDistributedMemoryCache();
//builder.Services.AddSession(options =>
//{
//    options.Cookie.HttpOnly = true;
//    options.Cookie.IsEssential = true;
//    options.IdleTimeout = TimeSpan.FromHours(2);
//});

//builder.Services.AddDataProtection()
//            .SetApplicationName("TraineeTracker")
//            .AddKeyManagementOptions(options =>
//            {
//                options.NewKeyLifetime = new TimeSpan(180, 0, 0, 0);
//                options.AutoGenerateKeys = true;
//            });


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseMiddleware<RequestMiddleware>();

app.UseCookiePolicy();
app.UseAuthentication();

//app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

//app.UseSession();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
