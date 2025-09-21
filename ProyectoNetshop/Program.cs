//using System;
//using System.Windows.Forms;
//using vistaDeProyectoC;
//namespace ProyectoNetshop
//{
//    internal static class Program
//    {
//        /// <summary>
//        ///  The main entry point for the application.
//        /// </summary>
//        [STAThread]
//        static void Main()
//        {
//            // To customize application configuration such as set high DPI settings or default font,
//            // see https://aka.ms/applicationconfiguration.
//            ApplicationConfiguration.Initialize();
//            Application.Run(new FInicioSesion());
//            Application.Run(new principal());
//        }
//    }
//}

using Microsoft.VisualBasic.Logging;
using ProyectoNetshop;       // namespace de tu principal
using System;
using System.Windows.Forms;
using vistaDeProyectoC;      // namespace de tu FInicioSesion

internal static class Program
{
    [STAThread]
    static void Main()
    {
        //ApplicationConfiguration.Initialize();

        //// 1) Abrir el login en modo modal
        //using (var login = new FInicioSesion())
        //{
        //    if (login.ShowDialog() != DialogResult.OK)
        //        return;    // Sale de Main() y termina la app
        //}

        //// 2) Si ShowDialog devolvió OK, lanza el form principal
        //Application.Run(new principal(login.IdPerfil));

        ApplicationConfiguration.Initialize();

        using var login = new FInicioSesion();
        if (login.ShowDialog() != DialogResult.OK)
            return;

        Application.Run(new principal(login.IdPerfil));

        //Application.Run(new principal());
    }
}