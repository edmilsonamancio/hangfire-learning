namespace HangFire.Service.Interfaces
{
    public interface IHangService
    {
        Task FireAndForge();
        Task FireSchedule(int minutos);
        void JobRecorrente();
    }
}
