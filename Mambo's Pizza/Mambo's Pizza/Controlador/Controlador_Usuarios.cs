using Mambo_s_Pizza.Modelo;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Mambo_s_Pizza.Controlador
{
    class Controlador_Usuarios
    {
        public int IdUsuario { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public string Correo { get; set; }
        public string Usuario { get; set; }
        public string Contraseña { get; set; }
        public string Rol { get; set; }

        public static DataTable ObtenerUsuarios()
        {
            return Modelo_Usuarios.MostrarUsuarios();
        }


        public static int InsertarUsuarios(string Nombre, string Apellido, DateTime FechaNacimiento, string Correo, string Usuario, string Contraseña, string Rol)
        {
            return Modelo_Usuarios.AgregarUsuarios(Nombre, Apellido, FechaNacimiento, Correo, Usuario, Contraseña, Rol);
        }

        public static int ActualizarUsuarios(string Nombre, string Apellido, DateTime FechaNacimiento, string Correo, string Usuario, string Contraseña, string Rol, int IdUsuario)
        {
            return Modelo_Usuarios.ActualizarUsuario(Nombre, Apellido, FechaNacimiento, Correo, Usuario, Contraseña, Rol, IdUsuario);
        }

        public static int EliminarUsuarios(int IdUsuario)
        {
            return Modelo_Usuarios.EliminarUsuario(IdUsuario);
        }

        public static int IniciarSesion(string Usuario, string Contraseña)
        {
            return Modelo_Usuarios.IniciarSesion(Usuario, Contraseña);
        }

    }
}
