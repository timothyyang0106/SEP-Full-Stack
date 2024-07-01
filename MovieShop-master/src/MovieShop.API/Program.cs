using System.Reflection;
using System.Text;
using ApplicationCore.Contracts.Services;
using Azure.Storage.Blobs;
using Infrastructure.Data;
using Infrastructure.Helpers;
using Infrastructure.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using MovieShop.API.Infrastructure;

var builder = WebApplication.CreateBuilder(args);
//builder.Host.UseSerilog((ctx, lc) => lc.WriteTo.File(""));
// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddDbContext<MovieShopDbContext>(options =>
    options.UseSqlServer(builder.Configuration
        .GetConnectionString("MovieShopDbConnection")));
//builder.Services.AddAutoMapper(typeof(MovieShopMappingProfile));
ConfigureDependencyInjection(builder.Services);
builder.Services.AddMemoryCache();
builder.Services.AddHttpContextAccessor();

builder.Services.AddStackExchangeRedisCache(options =>
{
    options.Configuration = builder.Configuration.GetConnectionString("RedisConnection");
    options.InstanceName = "MovieShop_";
});

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateIssuerSigningKey = true,
            ValidIssuer = builder.Configuration["Issuer"],
            ValidAudience = builder.Configuration["Audience"],
            IssuerSigningKey =
                new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["PrivateKey"]))
        };
    });


builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(
    options =>
    {
        options.SwaggerDoc("v1", new OpenApiInfo
        {
            Version = "v1", Title = "Movie Shop API", Description = "API for managing Movie Shop"
        });

        options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
        {
            In = ParameterLocation.Header,
            Description = "Please insert JWT with Bearer into field",
            Name = "Authorization",
            BearerFormat = "JWT",
            Scheme = "bearer",
            Type = SecuritySchemeType.ApiKey
        });

        options.AddSecurityRequirement(new OpenApiSecurityRequirement
        {
            {
                new OpenApiSecurityScheme
                {
                    Reference = new OpenApiReference
                    {
                        Type = ReferenceType.SecurityScheme,
                        Id = "Bearer"
                    }
                },
                new string[] { }
            }
        });

        // using System.Reflection;
        var xmlFilename = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
        options.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, xmlFilename));
    }
);

void ConfigureDependencyInjection(IServiceCollection services)
{
    var connectionString = builder.Configuration.GetValue<string>("AzureBlobStorage");
    // var containerName = Configuration.GetValue<string>("MovieShopBlobContainer");
    if (builder.Environment.IsDevelopment())
    {
        services.AddScoped<IGenreService, GenreRedisCacheService>();
    }
    else
    {
        services.AddScoped<IGenreService, GenreService>();
    }

    services.AddTransient<IBlobService>(b =>
        new BlobService(new BlobServiceClient(connectionString)));

    services.AddRepositories();
    services.AddServices();
}

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    // builder.Services.AddScoped<IGenreService, GenreRedisCacheService>();
}

app.UseMovieShopExceptionMiddleware();
app.UseSwagger();
app.UseSwaggerUI();

app.UseCors(corsPolicyBuilder =>
{
    corsPolicyBuilder.WithOrigins(app.Configuration.GetValue<string>("clientSPAUrl")).AllowAnyHeader()
        .AllowAnyMethod().AllowCredentials();
});

app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();