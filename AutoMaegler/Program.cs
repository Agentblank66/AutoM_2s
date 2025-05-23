using AutoMaegler.EFDbContext;
using AutoMaegler.Service;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddDbContext<CarDBContext>();
builder.Services.AddTransient<DBCarService>(); // brugte AddTransient
builder.Services.AddSingleton<IOrderService, OrderService>();
builder.Services.AddSingleton<IUserService, UserService>();
builder.Services.AddDbContext<UserDbContext>();
builder.Services.AddTransient<DbUserService>();

builder.Services.Configure<CookiePolicyOptions>(options => {
    // This lambda determines whether user consent for non-essential cookies is needed for a given request. options.CheckConsentNeeded = context => true;
    options.MinimumSameSitePolicy = SameSiteMode.None;

});

builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie(Options => {
    Options.LoginPath = "/Users/Login/LogInPage";
    


});

builder.Services.AddMvc().AddRazorPagesOptions(options => {
    options.Conventions.AuthorizeFolder("/Car");

}).SetCompatibilityVersion(CompatibilityVersion.Version_3_0);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();

app.MapRazorPages();

app.Run();
