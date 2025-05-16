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
    public class Controlador_Usuarios
    {
        public static int IdUsuario { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public string Correo { get; set; }
        public string Usuario { get; set; }
        public string Contraseña { get; set; }
        public string Rol { get; set; }

        public Controlador_Usuarios(string pNombre, string pApellido, DateTime pFechaNacimiento, string pCorreo, string pUsuario, string pContraseña, string pRol) 
        { 
            Nombre = pNombre;
            Apellido = pApellido;
            FechaNacimiento = pFechaNacimiento;
            Correo = pCorreo;
            Usuario = pUsuario;
            Contraseña = pContraseña;
            Rol = pRol;
        }

        public static DataTable ObtenerUsuarios()
        {
            return Modelo_Usuarios.MostrarUsuarios();
        }

        public  bool InsertarUsuarios()
        {
            return Modelo_Usuarios.AgregarUsuarios(Nombre, Apellido, FechaNacimiento, Correo, Usuario, Contraseña, Rol);
        }

        public  bool ActualizarUsuarios()
        {
            return Modelo_Usuarios.ActualizarUsuario(IdUsuario, Nombre, Apellido, FechaNacimiento, Correo, Usuario, Contraseña, Rol);
        }

        public static bool EliminarUsuarios()
        {
            return Modelo_Usuarios.EliminarUsuario(IdUsuario);
        }

    }
}
