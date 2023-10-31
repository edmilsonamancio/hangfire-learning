using Hangfire;
using Hangfire.Server;
using HangFire.Service.Interfaces;

namespace HangFire.Service.Services
{
    public class HangService : IHangService
    {
        public async Task FireAndForge()
        {
            BackgroundJob.Enqueue(() => JobFireAndForget());
        }

        public async Task FireSchedule(int minutos)
        {
            BackgroundJob.Schedule(() => JobShedule(), TimeSpan.FromMinutes(minutos));
        }

        public async Task JobFireAndForget()
        {
            await Task.Run(() => 
            {
                Console.WriteLine("Job Fire And Forget");
            });
        }

        public async Task JobShedule()
        {
            await Task.Run(() => {
                Console.WriteLine("Job Shedule");
            });
        }

        public void JobRecorrente()
        {
            Console.WriteLine("Job Recorrente");
        }
    }
}