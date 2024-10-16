using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Reflection;
using System.Text;
using TestWebApp;
using TestWebApp.AutoMapper.Task;
using TestWebApp.AutoMapper.User;
using TestWebApp.Options;
using TestWebApp.Repository;
using TestWebApp.Services.Auth;

var builder = WebApplication.CreateBuilder(args);
var services = builder.Services;
// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(setup =>
{
    setup.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Scheme = JwtBearerDefaults.AuthenticationScheme,
        Name = "Authorization",
        In = ParameterLocation.Query,
        Type = SecuritySchemeType.Http
    });
    setup.AddSecurityRequirement(new OpenApiSecurityRequirement
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
            Array.Empty<string>()
        }
    });
});

services.AddDbContext<ApplicationDbContext>(dbContext =>
{
    var connectionString = builder.Configuration["DbConnection"];
    dbContext.UseNpgsql(connectionString);
});

services.AddScoped<IUnitOfWork, UnitOfWork>();
services.AddScoped<ITaskRepository, TaskRepository>();
services.AddScoped<IUserRepository, UserRepository>();

services.AddScoped<IJwtProvider, JwtProvider>();
services.ConfigureOptions<JwtOptionsSetup>();


services.AddAuthentication().AddJwtBearer(o =>
{
    var option = builder.Configuration
                        .GetSection("Jwt")
                        .Get<JwtOptions>();
    
    o.TokenValidationParameters = new TokenValidationParameters()
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        ValidIssuer = option.Issuer,
        ValidAudience = option.Audience,
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(option.SecretKey))
    };
});

services.AddMediatR(conf => conf.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));
services.AddAutoMapper(conf =>
{
    conf.AddProfile<TaskProfile>();
    conf.AddProfile<UserProfile>();
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
