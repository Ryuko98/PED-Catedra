using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mambo_s_Pizza.Modelo;

namespace Mambo_s_Pizza.Controlador
{
    class Controlador_PerfilRepartidor
    {
        public static int IdRepartidor { get; set; }
        public static string NombreCompleto { get; set; }
        public static string Correo { get; set; }
        public static string Usuario { get; set; }
        public static string DUI { get; set; }
        public static float CalificacionPromedio { get; set; }
        public static DateTime FechaRegistro { get; set; }
        public static int IdUsuario { get; set; }

        public Controlador_PerfilRepartidor(string mNombreCompleto, string mCorreo, string mUsuario, string pDUI, float pCalificacion, int pTotalCalificacion, DateTime pFechaRegistro, int pIdUsuario)
        {
            NombreCompleto = mNombreCompleto;
            Correo = mCorreo;
            Usuario = mUsuario;
            DUI = pDUI;
            CalificacionPromedio = pCalificacion;
            FechaRegistro = pFechaRegistro;
            IdUsuario = pIdUsuario;
        }

        public static void CargarDatosRepartidor()
        {
            DataTable dt = ObtenerInformacionRepartidor();

            if (dt.Rows.Count > 0)
            {
                DataRow row = dt.Rows[0];
                NombreCompleto = row["NombreCompleto"].ToString();
                Correo = row["Correo"].ToString();
                Usuario = row["Usuario"].ToString();
                DUI = row["DUI"].ToString();
                CalificacionPromedio = Convert.ToSingle(row["CalificacionPromedio"]);
                FechaRegistro = Convert.ToDateTime(row["FechaRegistro"]);
                IdUsuario = Controlador_InicioSesion.IdUsuario;
            }
        }

        public static DataTable ObtenerInformacionRepartidor()
        {
            return Modelo_PerfilRepartidor.ObtenerInformacionRepartidor(Controlador_InicioSesion.IdUsuario);
        }

        public static DataTable CargarReseñasRepartidor()
        {
            return Modelo_PerfilRepartidor.CargarReseñasRepartidor(Controlador_InicioSesion.IdUsuario);
        }

        public static int OrdenarPrioridad()
        {
            return Modelo_PerfilRepartidor.PrioridadMembresia();
        }

        public static DataTable ObtenerPedidos()
        {
            return Modelo_PerfilRepartidor.MostrarPedidosEnEspera();
        }
    }
}
