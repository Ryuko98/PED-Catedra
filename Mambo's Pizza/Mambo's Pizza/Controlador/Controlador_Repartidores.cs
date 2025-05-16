using Mambo_s_Pizza.Modelo;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mambo_s_Pizza.Controlador
{
    class Controlador_Repartidores
    {
        public static int IdRepartidor { get; set; }
        public string DUI { get; set; }
        public float CalificacionPromedio { get; set; }
        public int TotalCalificaciones { get; set; }
        public DateTime FechaRegistro { get; set; }
        public int IdUsuario { get; set; }
        public string Disponibilidad { get; set; }


        public Controlador_Repartidores(string pDUI, float pCalificacion, int pTotalCalificacion, DateTime pFechaRegistro, int pIdUsuario, string pDisponibilidad)
        {
            DUI = pDUI;
            CalificacionPromedio = pCalificacion;
            TotalCalificaciones = pTotalCalificacion;
            FechaRegistro = pFechaRegistro;
            IdUsuario = pIdUsuario;
            Disponibilidad = pDisponibilidad;
        }

        public static DataTable ObtenerRepartidores()
        {
            return Modelo_Repartidores.MostrarRepartidores();
        }

        public bool InsertarRepartidor()
        {
            return Modelo_Repartidores.AgregarRepartidor(DUI, CalificacionPromedio, TotalCalificaciones, FechaRegistro, IdUsuario, Disponibilidad);
        }
        public bool ActualizarRepartidor()
        {
            return Modelo_Repartidores.ActualizarRepartidor(IdRepartidor, DUI, CalificacionPromedio, TotalCalificaciones, FechaRegistro, IdUsuario, Disponibilidad);
        }
        public static bool EliminarRepartidor()
        {
            return Modelo_Repartidores.EliminarRepartidor(IdRepartidor);
        }

        public static DataTable ObtenerUsuarios()
        {
            return Modelo_Repartidores.MostrarUsuarios();
        }
    }
}
