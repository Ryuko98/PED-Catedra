using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mambo_s_Pizza.Modelo;

namespace Mambo_s_Pizza.Controlador
{
    class Controlador_Menus
    {
        public int IdMenu { get; set; }
        public string NombreMenu { get; set; }
        public float precio { get; set; }
        public string Descripcion { get; set; }

        public static DataTable ObtenerMenus()
        {
            return Modelo_Menus.MostrarMenus();
        }

        public static DataTable ObtenerHistorialMenus()
        {
            return Modelo_Menus.MostrarHistorialMenus(Controlador_InicioSesion.IdUsuario);
        }
    }
}
