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
        public int IdRepartidor { get; set; }
        public string DUI { get; set; }
        public float CalificacionPromedio { get; set; }
        public int TotalCalificaciones { get; set; }
        public DateTime FechaRegistro { get; set; }
        public int IdUsuario { get; set; }
        public string Disponibilidad { get; set; }

    }
}
