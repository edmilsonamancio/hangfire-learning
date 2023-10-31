using Hangfire;
using Hangfire.MemoryStorage;
using Microsoft.Extensions.DependencyInjection;

namespace HangFireCrossCutting.HangFire
{
    public static class ConfigureHangFire
    {
        public static void AddHangFireConfiguration(this IServiceCollection service)
        {
            service.AddHangfire(op => 
            {
                op.UseMemoryStorage();
            });
            service.AddHangfireServer();
        }
    }
}
