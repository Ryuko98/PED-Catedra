using Mambo_s_Pizza.Modelo;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mambo_s_Pizza.Controlador
{
    public class Controlador_Reseñas
    {
        public static int IdReview { get; set; }
        public int IdRepartidor { get; set; }
        public int IdPedido { get; set; }
        public int Calificacion {  get; set; }
        public string Comentario { get; set; }
        public DateTime FechaReview { get; set; }
        public static DataTable ObtenerReseñas()
        {
            return Modelo_Reseñas.MostrarReseñas();
        }

        public static bool EliminarReseñas()
        {
            return Modelo_Reseñas.EliminarReseña(IdReview);
        }
    }
}
