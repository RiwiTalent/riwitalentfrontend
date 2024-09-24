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
        
        public async Task NewRegister()
        {
            var result = await Swal.FireAsync(new SweetAlertOptions
            {
                Icon = SweetAlertIcon.Success,
                Title = "¿Estás seguro/a de que deseas crear este nuevo registro?",
                Text = "Verifique que la información ingresada este correcta.",
                ShowCancelButton = true,
                ConfirmButtonColor = "#fff",
                ConfirmButtonText = "No, Cancelar",
                CancelButtonColor = "#5ACCA4",
                CancelButtonText="<button style='color:#5ACCA4, background-color:#fff'>Si, Confirmar</button>"
            });

            if (result.IsConfirmed)
            {
                await Swal.FireAsync(new SweetAlertOptions
                {
                    Title = "Deleted!",
                    Text = "Your file has been deleted.",
                    Icon = SweetAlertIcon.Success
                });
            }
        }

        public async Task DataSuccess()
        {
            await Swal.FireAsync(new SweetAlertOptions
                {   
                    Title = "¡Los datos se han guardado exitosamente!",
                    Icon = SweetAlertIcon.Success,
                    ShowConfirmButton = false ,
                    Timer = 1500
                });
        }
        
        public async Task SuccessLogin()
        {
            await Swal.FireAsync(new SweetAlertOptions
                {   
                    Title = "Login Success",
                    Icon = SweetAlertIcon.Success,
                    ShowConfirmButton = false ,
                    Timer = 1500
                });
        }

        public async Task RegisterSuccess()
        {
            await Swal.FireAsync(new SweetAlertOptions
                {   
                    Title = "¡Registro se ha borrado exitosamente!",
                    Icon = SweetAlertIcon.Success,
                    ShowConfirmButton = false ,
                    Timer = 1500
                });
        }

        public async Task Warning()
        {
            await Swal.FireAsync(new SweetAlertOptions
                {   
                    Title = "¡Ups, lo sentimos ocurrió un error!",
                    Icon = SweetAlertIcon.Warning,
                    ShowConfirmButton = false ,
                    Timer = 1500
                });
        }


    }
}