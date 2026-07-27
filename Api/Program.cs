using Api.Features.Desks.Commands.CreateDesk;
using Api.Infrastructure.DbContext;
using Api.Infrastructure.Integrations.Deepseek;
using Deepseek.AspClient.Client;
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
     

            builder.Services.AddSingleton(new DeepseekClient("sk-ad49a7aa9283442fb581994778ab9f9c"));

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


            builder.Services.AddScoped<IDeepseekService, DeepseekService>();

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


            //deepsek Ai  Deepseek:ApiKey

            //var deepseekApiKey = builder.Configuration.GetValue<string>("Deepseek:ApiKey");
           

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