using Api.Features.Desks.Commands.CreateDesk;
using Api.Infrastructure.DbContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi;
using Microsoft.OpenApi.Models;
using System.Text.Json.Serialization;
namespace Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);


            // dodanie ¿eby w swagger enum wyswietla³ siê jako nazwa a nie jako 1,2,3
            builder.Services.AddControllers().AddJsonOptions(option =>
            {

                option.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
                option.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
            }
);


            builder.Services.AddMediatR(cfg =>
            {
                cfg.RegisterServicesFromAssemblyContaining<CreateDeskCommand>();
            });


            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen(option =>
            {
                option.SupportNonNullableReferenceTypes();
                option.SwaggerDoc("v1", new OpenApiInfo { Title = "Zadanie Cetus Pro", Version = "v1" });


                option.EnableAnnotations();
            });
            builder.Services.AddDbContext<ApplicationContext>(options =>
            {
                options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection"));
            });
            builder.Services.AddScoped<IApplicationContext, ApplicationContext>();

            // dodanie polityki cors
            builder.Services.AddCors(options =>
            {
                options.AddDefaultPolicy(policy =>
                {
                    policy.AllowAnyMethod()
                          .AllowAnyHeader()
                          .WithMethods("GET")
                               .WithOrigins("http://localhost:55600") //zmieniæ przy buildzie na serwer
                          .AllowCredentials();
                });
            });

            var app = builder.Build();
            app.UseCors();

            //if (app.Environment.IsDevelopment())
            //{


            app.UseSwagger();
                app.UseSwaggerUI();
                app.MapSwagger();
            //}

            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }
    }
}