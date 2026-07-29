using Api.Features.Desks.Commands.CreateDesk;
using Api.Infrastructure.DbContext;
using Api.Infrastructure.Integrations.Deepseek;
using Api.Shared.Behaviors;
using Api.Shared.Exceptions;
using Deepseek.AspClient.Client;
using FluentValidation;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using System.Text.Json.Serialization;

namespace Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddSingleton(
                new DeepseekClient("TWÓJ_KLUCZ"));

            // Controllers + Enum jako string w Swagger/JSON
            builder.Services.AddControllers()
                .AddJsonOptions(option =>
                {
                    option.JsonSerializerOptions.ReferenceHandler =
                        ReferenceHandler.IgnoreCycles;

                    option.JsonSerializerOptions.Converters.Add(
                        new JsonStringEnumConverter());
                });

            // MediatR
            builder.Services.AddMediatR(cfg =>
            {
                cfg.RegisterServicesFromAssemblyContaining<CreateDeskCommand>();
            });

            // FluentValidation
            builder.Services.AddValidatorsFromAssemblyContaining<CreateDeskValidator>();

            // MediatR Validation Pipeline
            builder.Services.AddTransient(
                typeof(IPipelineBehavior<,>),
                typeof(ValidationBehavior<,>));

            // Deepseek
            builder.Services.AddScoped<IDeepseekService, DeepseekService>();

            // Swagger
            builder.Services.AddEndpointsApiExplorer();

            builder.Services.AddSwaggerGen(option =>
            {
                option.SupportNonNullableReferenceTypes();

                option.SwaggerDoc("v1",
                    new OpenApiInfo
                    {
                        Title = "Zadanie Cetus Pro",
                        Version = "v1"
                    });

                option.EnableAnnotations();
            });

            // Database
            builder.Services.AddDbContext<ApplicationContext>(options =>
            {
                options.UseNpgsql(
                    builder.Configuration.GetConnectionString("DefaultConnection"));
            });

            builder.Services.AddScoped<IApplicationContext, ApplicationContext>();

            // CORS
            builder.Services.AddCors(options =>
            {
                options.AddDefaultPolicy(policy =>
                {
                    policy
                        .AllowAnyMethod()
                        .AllowAnyHeader()
                        .WithOrigins("http://localhost:51868")
                        .AllowCredentials();
                });
            });


            var app = builder.Build();


            // Obs³uga ValidationException
            app.UseMiddleware<ValidationExceptionHandler>();


            app.UseCors();


            // Swagger
            app.UseSwagger();
            app.UseSwaggerUI();
            app.MapSwagger();


            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }
    }
}