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
using Project.DataAccess.InterfacesImplementations;
using Project.ServicessAccessLayer.Contracts.AuthContracts;
using Project.ServicessAccessLayer.Implementations.AuthContractsImplementations;
using Autofac.Core;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<Coursecontext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("sqlConnection"), x => x.MigrationsAssembly(typeof(Program).Assembly.FullName)));

builder.Services.AddScoped<IAuthManager, AuthManager>();
//builder.Services.AddScoped<GlobalErrorHandlingMiddleware>();
builder.Services.ConfigureIdentity();
builder.Services.ConfigureJwt(builder.Configuration);

builder.Services.AddAutoMapper(typeof(ConfigureDTOS));
builder.Services.AddAuthentication();

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

app.UseAuthorization();

app.MapControllers();

app.UseMiddleware<GlobalErrorHandlingMiddleware>();

app.Run();

