using CurrieTechnologies.Razor.SweetAlert2;

namespace riwi.Services.Interfaces;

public interface IAlertService
{
    Task DeleteRegister();
    Task SaveChangesRegister();
    Task NewRegister();
    Task Warning();
}