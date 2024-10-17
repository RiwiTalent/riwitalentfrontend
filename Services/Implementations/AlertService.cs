using CurrieTechnologies.Razor.SweetAlert2;

using riwitalentfrontend.Services.Interfaces;

namespace riwitalentfrontend.Services.Implementations
{
    public class AlertService : IAlertService
    {
        private readonly SweetAlertService _swal;
        public AlertService(SweetAlertService swal)
        {
            _swal = swal;
        }

        public async Task DeleteRegister(){
            var result = await _swal.FireAsync(new SweetAlertOptions
            {
                Icon = SweetAlertIcon.Warning,
                Title = "¿Estás seguro/a de que deseas eliminar este registro?",
                Text = "Esta acción no se podra deshacer.",
                ShowCancelButton = true,
                ConfirmButtonColor = "#FE654F",
                ConfirmButtonText = "Eliminar",
                CancelButtonColor = "#fff",
                CancelButtonText="<button class='btn-eliminar'>Cancelar</button>"
            });

            if (result.IsConfirmed)
            {
                await _swal.FireAsync(new SweetAlertOptions
                {
                    Title = "Los datos se han eliminado exitosamente",
                    Icon = SweetAlertIcon.Success,
                    ShowConfirmButton = false 
                });
            }
        }

        public async Task SaveChangesRegister(){
            var result = await _swal.FireAsync(new SweetAlertOptions
            {
                Icon = SweetAlertIcon.Success,
                Title = "¿Estás seguro/a de que deseas guardar los cambios de este registro?",
                Text = "Esta acción actualizará la información y no podrá recuperarse.",
                ShowCancelButton = true,
                ConfirmButtonColor = "#5ACCA4",
                ConfirmButtonText = "Si, Confirmar",
                CancelButtonColor = "#fff",
                CancelButtonText="<button style='color:#5ACCA4, background-color:#fff'>No, Cancelar</button>"
            });

            if (result.IsConfirmed)
            {
                await _swal.FireAsync(new SweetAlertOptions
                {
                    Title = "Los datos se han guardado exitosamente",
                    Icon = SweetAlertIcon.Success,
                    ShowConfirmButton = false 
                });
            }
        }
        
        public async Task NewRegister()
        {
            var result = await _swal.FireAsync(new SweetAlertOptions
            {
                Icon = SweetAlertIcon.Success,
                Title = "¿Estás seguro/a de que deseas crear este nuevo registro?",
                Text = "Verifique que la información ingresada este correcta.",
                ShowCancelButton = true,
                CancelButtonColor = "#fff",
                CancelButtonText="<button style='color:#5ACCA4, background-color:#fff'>No, Cancelar</button>",
                ConfirmButtonText = "Si, Confirmar",
                ConfirmButtonColor = "#5ACCA4"
            });

            if (result.IsConfirmed)
            {
                await _swal.FireAsync(new SweetAlertOptions
                {
                    Title = "Registro Creado Exitosamente",
                    Icon = SweetAlertIcon.Success,
                    ShowConfirmButton = false 
                });
            }
        }
        
        public async Task Warning()
        {
            await _swal.FireAsync(new SweetAlertOptions
                {   
                    Title = "¡Ups, lo sentimos ocurrió un error!",
                    Icon = SweetAlertIcon.Warning,
                    ShowConfirmButton = false ,
                    Timer = 1500
                });
        }

        public async  Task ConfirmDeleteCoder()
        {
            var result = await _swal.FireAsync(new SweetAlertOptions
            {
                Icon = SweetAlertIcon.Warning,
                Title = "¿Estás seguro/a de que deseas eliminar este programador?",
                Text = "Esta acción no se podra deshacer.",
                ShowCancelButton = true,
                ConfirmButtonColor = "#FE654F",
                ConfirmButtonText = "Eliminar",
                CancelButtonColor = "#fff",
                CancelButtonText="<button class='btn-eliminar'>Cancelar</button>"
            });
        }
    }
}