using ApplicationCore.Contracts.Repositories;
using ApplicationCore.Contracts.Services;
using Infrastructure.Repositories;
using Infrastructure.Services;
using Azure.Storage.Blobs;
using Infrastructure.Data;
using Infrastructure.Helpers;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<MovieShopDbContext>(options =>
    options.UseSqlServer(builder.Configuration
        .GetConnectionString("MovieShopDbConnection")));

// Configure logging
builder.Logging.ClearProviders();
builder.Logging.AddConsole();

//builder.Services.AddAutoMapper(typeof(MovieShopMappingProfile));
ConfigureDependencyInjection(builder.Services);
builder.Services.AddMemoryCache();
builder.Services.AddHttpContextAccessor();

//sets the default authentication scheme for the app
builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie(options =>
{
    options.Cookie.Name = "MovieShopAuthCookie";
    options.ExpireTimeSpan = TimeSpan.FromHours(2);
    options.LoginPath = "/Account/Login";
});


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}



app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    "default",
    "{controller=Home}/{action=Index}/{id?}");

app.Run();


void ConfigureDependencyInjection(IServiceCollection services)
{
    var connectionString = builder.Configuration.GetValue<string>("AzureBlobStorage");
    // var containerName = Configuration.GetValue<string>("MovieShopBlobContainer");
    services.AddTransient<IBlobService>(b =>
        new BlobService(new BlobServiceClient(connectionString)));

    services.AddTransient<IReviewRepository, ReviewRepository>();
    services.AddRepositories();
    services.AddServices();
}