using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using System;
using System.Text;
using System.Text.Json.Serialization;
using CourseMicroSerivce.DependencyInjectContainer;
using CourseMicroSerivce.ExtensionMethods;
using CourseMicroSerivce.Helper;
using CourseMicroSerivce.Middlewares;
using Project.BusinessAccessLayer.Repositories.Unit;
using Project.DataAccess;
using Project.ServicessAccessLayer.Contracts.AuthContracts;
using Project.ServicessAccessLayer.Implementations.AuthContractsImplementations;
using Autofac.Core;
using Microsoft.IdentityModel.Tokens;
using CourseMicroSerivce.API.Controllers;
using CourseMicroSerivce.Core.ServicessAccessLayer.Contracts.DomainContracts;
using CourseMicroSerivce.Core.ServicessAccessLayer.Implementations;
using CourseMicroSerivce.Core.BusinessAccessLayer.Repositories.ModelRepositories;
using CourseMicroSerivce.Core.DataAccessLayer.ModelRepositories;
using CourseMicroSerivce.Core.DataAccessLayer.UnitOfWork;
using Microsoft.Extensions.FileProviders;
using CourseMicroSerivce.Domain.AuthenticationModels;
using Microsoft.AspNetCore.Identity;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<SchoolContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("sqlConnection"), x => x.MigrationsAssembly(typeof(Program).Assembly.FullName)));

builder.Services.AddScoped<IAuthManager, AuthManager>();
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
// Add Identity services and configure RoleManager
builder.Services.AddIdentityCore<ApplicationUser>()
    .AddRoles<IdentityRole>() // Add this line to configure RoleManager
    .AddEntityFrameworkStores<SchoolContext>()
    .AddDefaultTokenProviders();
builder.Services.AddScoped<ISchoolThemes_Service, SchoolThemes_Service>();
builder.Services.AddScoped<ISchoolThemes_Repo, SchoolThemes_Repo>();
builder.Services.AddScoped<IClassesSessions_Repo, ClassesSessions_Repo>();

builder.Services.AddScoped<ICoursePosts_Repo, CoursePosts_Repo>();
builder.Services.AddScoped<IQuizPosts_Repo, QuizPosts_Repo>();
builder.Services.AddScoped<ISchoolChapters_Repo, SchoolChapters_Repo>();
builder.Services.AddScoped<ISchoolClasses_Repo, SchoolClasses_Repo>();
builder.Services.AddScoped<ISchoolQuiz_Repo, SchoolQuiz_Repo>();
builder.Services.AddScoped<ISchoolSubjects_Repo, SchoolSubjects_Repo>();
builder.Services.AddScoped<IPermission_Repo, Permission_Repo>();
builder.Services.AddScoped<ISchoolCourses_Repo, SchoolCourses_Repo>();
builder.Services.AddScoped<ISchoolCourses_Service, SchoolCourses_Service>();
builder.Services.AddScoped<IClassesSessions_Service, ClassesSessions_Service>();
builder.Services.AddScoped<ICoursePosts_Service, CoursePosts_Service>();
builder.Services.AddScoped<IQuizPosts_Service, QuizPosts_Service>();
builder.Services.AddScoped<ISchoolChapters_Service, SchoolChapters_Service>();
builder.Services.AddScoped<ISchoolClasses_Service, SchoolClasses_Service>();
builder.Services.AddScoped<ISchoolQuiz_Service, SchoolQuiz_Service>();
builder.Services.AddScoped<ISchoolSubjects_Service, SchoolSubjects_Service>();
builder.Services.AddScoped<IPermission_Service, Permission_Service>();


//builder.Services.AddScoped<GlobalErrorHandlingMiddleware>();
builder.Services.ConfigureIdentity();


builder.Services.AddAutoMapper(typeof(ConfigureDTOS));
builder.Services.ConfigureJwt(builder.Configuration);



builder.Services.AddControllers()
    .AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
    });

builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "Project", Version = "v1" });

    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Description = "Enter Bearer and space with valid token",
        Name = "Authorization",
        Type = SecuritySchemeType.ApiKey,
        Scheme = "Bearer",
        In = ParameterLocation.Header
    });

    c.AddSecurityRequirement(new OpenApiSecurityRequirement
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




builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(builder =>
    {
        builder.AllowAnyOrigin()
               .AllowAnyMethod()
               .AllowAnyHeader();
    });
});

var app = builder.Build();



// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseDeveloperExceptionPage();

app.UseHttpsRedirection();

app.UseRouting();
app.UseStaticFiles(new StaticFileOptions
{
    FileProvider = new PhysicalFileProvider(Path.Combine(Directory.GetCurrentDirectory(), "UploadedImages")),
    RequestPath = "/UploadedImages"
});

app.UseCors();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.UseMiddleware<GlobalErrorHandlingMiddleware>();

app.Run();
