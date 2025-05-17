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

        public Controlador_Clientes(int idUsuario, string direccion, int idMembresia, DateTime fechaExpiracion)
        {
            IdUsuario = idUsuario;
            Direccion = direccion;
            IdMembresia = idMembresia;
            FechaExpiracion = fechaExpiracion;
        }

        public static DataTable ObtenerClientes()
        {
            return Modelo_Clientes.MostrarClientes();
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
    }
}
