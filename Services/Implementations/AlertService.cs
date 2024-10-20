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
                Title = "¿Estás seguro/a de que deseas desactivar este registro?",
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
                    Title = "Los datos se han desactivado exitosamente",
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
                    ShowConfirmButton = false,
                    Timer = 1500
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

        public async Task AcceptTerms()
        {
            var result = await _swal.FireAsync(new SweetAlertOptions
            {
                Icon = SweetAlertIcon.Info,
                Title = "Términos y Condiciones",
                Text = "Por favor, lee y acepta los términos y condiciones antes de continuar.",
                ShowCancelButton = true,
                ConfirmButtonText = "Ya los leì",
                ConfirmButtonColor = "#5ACCA4",
                CancelButtonText = "Atràs",
                CancelButtonColor = "#fff"
            });

            if (result.IsConfirmed)
            {
                await _swal.FireAsync(new SweetAlertOptions
                {
                    Title = "¡Gracias por aceptar los términos!",
                    Text = "Se enviarà una copia de la versiòn de tèrminos aceptada al correo asociado al grupo",
                    Icon = SweetAlertIcon.Success,
                    ShowConfirmButton = false,
                    Timer = 1500
                });
            }
            else
            {
                await _swal.FireAsync(new SweetAlertOptions
                {
                    Title = "Has cancelado la aceptación de los términos.",
                    Icon = SweetAlertIcon.Warning,
                    ShowConfirmButton = false,
                    Timer = 1500
                });
            }
        }

        public async Task CancelTerms()
        {
            var result = await _swal.FireAsync(new SweetAlertOptions
            {
                Icon = SweetAlertIcon.Warning,
                Title = "¿Estás seguro/a de que deseas cancelar la aceptación de los términos?",
                Text = "Se requiere de su aceptaciòn para iniciar a la plataforma por primera vez. Una vez aceptados, no se te pedirà de nuevo aceptarlos.",
                ShowCancelButton = true,
                ConfirmButtonText = "Sí, Cancelar",
                ConfirmButtonColor = "#FE654F",
                CancelButtonText = "No, Volver",
                CancelButtonColor = "#fff"
            });

            if (result.IsConfirmed)
            {
                await _swal.FireAsync(new SweetAlertOptions
                {
                    Title = "Has cancelado la aceptación de los términos.",
                    Icon = SweetAlertIcon.Info,
                    ShowConfirmButton = false,
                    Timer = 1500
                });
            }
            else
            {
                await _swal.FireAsync(new SweetAlertOptions
                {
                    Title = "Regresaste a la aceptación de los términos.",
                    Icon = SweetAlertIcon.Success,
                    ShowConfirmButton = false,
                    Timer = 1500
                });
            }
        }



        public async  Task ConfirmDeleteCoder()
        {
            var result = await _swal.FireAsync(new SweetAlertOptions
            {
                Icon = SweetAlertIcon.Warning,
                Title = "¿Estás seguro/a de que deseas desactivar este coder?",
                Text = "Esta acción no se podra deshacer.",
                ShowCancelButton = true,
                ConfirmButtonColor = "#FE654F",
                ConfirmButtonText = "Eliminar",
                CancelButtonColor = "#fff",
                CancelButtonText="<button class='btn-eliminar'>Cancelar</button>"
            });
        }

        //Delete group
        public async Task ConfirmDeleteGroup()
        {
            var result = await _swal.FireAsync(new SweetAlertOptions
            {
                Icon = SweetAlertIcon.Warning,
                Title = "¿Estás seguro/a de que deseas eliminar este grupo?",
                Text = "Esta acción no se podrá deshacer.",
                ShowCancelButton = true,
                ConfirmButtonColor = "#FE654F",
                ConfirmButtonText = "Eliminar",
                CancelButtonColor = "#fff",
                CancelButtonText = "<button style='color:#FE654F; background-color:#fff'>Cancelar</button>"
            });
        }

        public async Task AddCodersToGroup()
        {
            await _swal.FireAsync(new SweetAlertOptions
            {
                Title = "Agregar Coders",
                Text = "Se han agregado al grupo correctamente",
                Icon = SweetAlertIcon.Success,
                ShowConfirmButton = false,
                Timer = 1500
            });
        }
    }
}