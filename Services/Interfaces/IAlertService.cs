namespace riwitalentfrontend.Services.Interfaces
{
    public interface IAlertService
    {
        Task DeleteRegister();
        Task SaveChangesRegister();
        Task NewRegister();
        Task Warning();
        Task AcceptTerms();
        Task CancelTerms(); 
        Task ConfirmDeleteCoder();
        Task ConfirmDeleteGroup();
        Task AddCodersToGroup();

    }

}

