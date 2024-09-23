using CurrieTechnologies.Razor.SweetAlert2;

namespace riwi.Services
{
    public class AlertServices
    {
        private readonly SweetAlertService Swal;
        public AlertServices(SweetAlertService swal)
        {
            Swal = swal;
        }
        public async Task SuccessSweetAlert()
        {
            await Swal.FireAsync(new SweetAlertOptions
                {   
                    Title = "Login Success",
                    Icon = SweetAlertIcon.Success,
                    ShowConfirmButton = false ,
                    Timer = 1500
                });
        }
    }
}