using Microsoft.AspNetCore.Components;
using CediadDataBase;

namespace CediadRegistroBlazorServer.Pages.CajaDiaria;

public partial class AltaRegistro
{
    [Parameter]
    public Registro Registro { get; set; }
    protected override void OnInitialized()
    {
        // Inicializa la fecha de pago con la fecha de hoy
        Registro ??= new Registro();
        Registro.FechaDePago = DateTime.Today;
    }

    private async Task HandleValidSubmit()
    {
        // Lógica para guardar el registro en la base de datos usando el servicio
        bool success = await service.AddRegistro(Registro);
        if (success)
        {
            //NavigationManager.NavigateTo("/lista-registro");
        }
        else
        {
            // Maneja el caso de error, muestra un mensaje de error, etc.
        }
    }
}