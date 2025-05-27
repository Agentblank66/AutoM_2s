using AutoMaegler.EFDbContext;
using AutoMaegler.Service;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Net.WebSockets;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Konfiguration
builder.Configuration
    .SetBasePath(Directory.GetCurrentDirectory())
    .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
    .AddJsonFile($"appsettings.{builder.Environment.EnvironmentName}.json", optional: true, reloadOnChange: true)
    .AddEnvironmentVariables();

// Tilføj DB services
builder.Services.AddDbContext<CarDBContext>(options =>
{
    var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
    options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));
});

builder.Services.AddDbContext<ImageDBContext>(options =>
{
    var connectionString = builder.Configuration.GetConnectionString("ImageDb");
    options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));
});

// Dependency injection
builder.Services.AddRazorPages();
builder.Services.AddTransient<DBCarService>();
builder.Services.AddDbContext<OrderDbContext>();
builder.Services.AddScoped<ICarService, CarService>();
builder.Services.AddSingleton<IOrderService, OrderService>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<UserService>();
builder.Services.AddScoped<IImageService, ImageService>();
builder.Services.AddScoped<DBImageService>();
builder.Services.AddDbContext<UserDbContext>();
builder.Services.AddScoped<DbUserService>();

builder.Services.Configure<CookiePolicyOptions>(options =>
{
    options.MinimumSameSitePolicy = SameSiteMode.None;
});

builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(options =>
    {
        options.LoginPath = "/Users/Login/LogInPage";
        options.AccessDeniedPath = "/Users/Account/AccessDenied";
    });

builder.Services.AddMvc().AddRazorPagesOptions(options =>
{
    options.Conventions.AuthorizeFolder("/Car");
}).SetCompatibilityVersion(CompatibilityVersion.Version_3_0);

var app = builder.Build();

// Exception handler og HSTS
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

// HTTPS + static + authentication
app.UseHttpsRedirection();
app.UseStaticFiles();

// WebSocket aktivering
app.UseWebSockets();

app.Use(async (context, next) =>
{
    if (context.Request.Path == "/AutoMaegler")
    {
        if (context.WebSockets.IsWebSocketRequest)
        {
            WebSocket webSocket = await context.WebSockets.AcceptWebSocketAsync();
            await Echo(webSocket);
        }
        else
        {
            context.Response.StatusCode = 400;
        }
    }
    else
    {
        await next();
    }
});

app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();

app.MapRazorPages();

app.Run();

// WebSocket "echo" handler – denne kan du udvide senere
static async Task Echo(WebSocket socket)
{
    var buffer = new byte[1024 * 4];
    var result = await socket.ReceiveAsync(new ArraySegment<byte>(buffer), CancellationToken.None);
    while (!result.CloseStatus.HasValue)
    {
        await socket.SendAsync(new ArraySegment<byte>(buffer, 0, result.Count), result.MessageType, result.EndOfMessage, CancellationToken.None);
        result = await socket.ReceiveAsync(new ArraySegment<byte>(buffer), CancellationToken.None);
    }
    await socket.CloseAsync(result.CloseStatus.Value, result.CloseStatusDescription, CancellationToken.None);
}
