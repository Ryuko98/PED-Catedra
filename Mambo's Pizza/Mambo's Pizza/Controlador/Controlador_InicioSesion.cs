using Mambo_s_Pizza.Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mambo_s_Pizza.Controlador
{
    public class Controlador_InicioSesion
    {
        public static int IdUsuario { get; set; }
        public static string Nombre { get; set; }
        public static string Apellido { get; set; }
        public static DateTime FechaNacimiento { get; set; }
        public static string Correo { get; set; }
        public static string Usuario { get; set; }
        public static string Contraseña { get; set; }
        public static string Rol { get; set; }

        public static bool IniciarSesion()
        {
            return Modelo_Usuarios.IniciarSesion(Usuario, Contraseña);
        }

        public static List<string> DatosUsuario()
        {
            return Modelo_Usuarios.DatosUsuario(Usuario);
        }
    }
}
