using Mambo_s_Pizza.Modelo;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mambo_s_Pizza.Controlador
{
    public class Controlador_Clientes
    {
        public static int IdCliente { get; set; }
        public int IdUsuario { get; set; }
        public string Direccion { get; set; }
        public int IdMembresia { get; set; }
        public DateTime FechaExpiracion { get; set; }

        public Controlador_Clientes(int pidUsuario, string pDireccion, int pidMembresia, DateTime pFechaExpiracion)
        {
            IdUsuario = pidUsuario;
            Direccion = pDireccion;
            IdMembresia = pidMembresia;
            FechaExpiracion = pFechaExpiracion;
        }

        public static DataTable ObtenerClientes()
        {
            return Modelo_Clientes.MostrarClientes();
        }

        public static string ObtenerMembresia()
        {
            return Modelo_Clientes.ObtenerMembresia(IdCliente);
        }

        public static string ObtenerUsuario()
        {
            return Modelo_Clientes.ObtenerUsuario(IdCliente);
        }

        public static List<KeyValuePair<int, string>> CargarUsuariosClientes()
        {
            return Modelo_Clientes.CargarUsuariosClientes();
        }
        public static List<KeyValuePair<int, string>> CargarMembresiaCliente()
        {
            return Modelo_Clientes.CargarMembresiaCliente();
        }

        public static int EncontrarIdCliente(int id_usuario)
        {
            return Modelo_Clientes.EncontrarIdCliente(id_usuario);
        }

        public bool InsertarClientes()
        {
            return Modelo_Clientes.AgregarCliente(IdUsuario, Direccion, IdMembresia, FechaExpiracion);
        }

        public bool ActualizarClientes()
        {
            return Modelo_Clientes.ActualizarCliente(IdCliente, Direccion, IdMembresia, FechaExpiracion);
        }

        public static bool EliminarClientes()
        {
            return Modelo_Clientes.EliminarCliente(IdCliente);
        }
    }
}
