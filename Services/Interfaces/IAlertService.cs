namespace RTFrontend.Services.Interfaces
{
    public interface IAlertService
    {
        Task DeleteRegister();
        Task SaveChangesRegister();
        Task NewRegister();
        Task Warning();
    }
}

