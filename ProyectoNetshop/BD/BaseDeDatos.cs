// Importa librerías.
using iTextSharp.text.pdf.codec.wmf;
using Microsoft.Data.SqlClient;
using Microsoft.VisualBasic.ApplicationServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Media3D;

namespace ProyectoNetshop.BD
{
    internal class BaseDeDatos
    {
        // Abre y devuelve una conexión SQL a la base proyectoT:  
        // Crea una instancia de SqlConnection con la cadena especificada, la abre inmediatamente y la retorna lista para usar.
        public static SqlConnection obtenerConexion()
        {
            SqlConnection conexion = new SqlConnection("Server=LAPTOP-KCCIPSRT\\SQLEXPRESS;Database=proyectoT;Trusted_Connection=True;TrustServerCertificate=True;");
            //SqlConnection conexion = new SqlConnection("Server=localhost;Database=proyectoT;Trusted_Connection=True;TrustServerCertificate=True;");

            conexion.Open();

            return conexion;
        }
    }
}