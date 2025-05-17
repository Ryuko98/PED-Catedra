using Mambo_s_Pizza.Modelo;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mambo_s_Pizza.Controlador
{
    public class Controlador_Membresias
    {
        public static int IdMembresia { get; set; }
        public string Membresia { get; set; }
        public string Descripcion { get; set; }

        public Controlador_Membresias(string membresia, string descripcion)
        {
            Membresia = membresia;
            Descripcion = descripcion;
        }
        public static DataTable ObtenerMembresias()
        {
            return Modelo_Membresias.MostrarMembresias();
        }
        public bool InsertarMembresias()
        {
            return Modelo_Membresias.AgregarMembresia(Membresia, Descripcion);
        }
        public bool ActualizarMembresias()
        {
            return Modelo_Membresias.ActualizarMembresia(IdMembresia, Membresia, Descripcion);
        }
        public static bool EliminarMembresias()
        {
            return Modelo_Membresias.EliminarMembresia(IdMembresia);
        }
    }
}
