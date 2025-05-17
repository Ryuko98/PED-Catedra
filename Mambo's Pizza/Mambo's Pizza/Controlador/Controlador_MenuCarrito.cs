using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mambo_s_Pizza.Modelo;

namespace Mambo_s_Pizza.Controlador
{
    public class Controlador_MenuCarrito
    {
        public static int IdMenu { get; set; }
        public static string NombreMenu { get; set; }
        public static float Precio { get; set; }
        public static string Descripcion { get; set; }

        public static List<string> DatosMenu()
        {
            return Modelo_Menus.DatosMenu(IdMenu);
        }
    }
}
