using Microsoft.VisualBasic.Logging;
using ProyectoNetshop;
using System;
using System.Windows.Forms;
using vistaDeProyectoC;

internal static class Program
{
    [STAThread]
    static void Main()
    {
        // Ajusta estilos y configuración visual antes de crear formularios
        ApplicationConfiguration.Initialize();

        //// Crea el formulario de inicio de sesión
        using var login = new FInicioSesion();

        // Pregunta si es usuario validó
        if (login.ShowDialog() == DialogResult.OK)
        {
            Application.Run(new principal(
                login.IdPerfil,
                login.VendedorDni,
                login.VendedorNombre));
        }

        //Application.Run(new principal(1, 30123457, "Juan"));
    }
}