

using Hangfire;
using HangFire.Service.Interfaces;
using HangFire.Service.Services;
using HangFireCrossCutting.HangFire;

namespace HangFire.Application
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.AddSingleton<IHangService, HangService>();


            builder.Services.AddHangFireConfiguration();
            
            var _fireService = builder.Services.BuildServiceProvider().GetService<IHangService>();
            
            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHangfireDashboard();
            RecurringJob.AddOrUpdate(() => _fireService.JobRecorrente(), Cron.MinuteInterval(2));

            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }
    }
}