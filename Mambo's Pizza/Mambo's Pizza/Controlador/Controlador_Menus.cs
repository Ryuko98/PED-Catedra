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
    public class Controlador_Menus
    {
        public static int IdMenu { get; set; }
        public static string NombreMenu { get; set; }
        public static float Precio { get; set; }
        public static string Descripcion { get; set; }

        public Controlador_Menus(string mNombreMenu, float mPrecio, string mDescripcion)
        {
            NombreMenu = mNombreMenu;
            Precio = mPrecio;
            Descripcion = mDescripcion;
        }

        public static DataTable ObtenerMenus()
        {
            return Modelo_Menus.MostrarMenus();
        }

        public bool InsertarMenus()
        {
            return Modelo_Menus.AgregarMenus(NombreMenu, Precio, Descripcion);
        }

        public bool ActualizarMenus()
        {
            return Modelo_Menus.ActualizarMenu(IdMenu, NombreMenu, Precio, Descripcion);
        }

        public static bool EliminarMenus()
        {
            return Modelo_Menus.EliminarMenu(IdMenu);
        }

        public static DataTable ObtenerHistorialMenus()
        {
            return Modelo_Menus.MostrarHistorialMenus(Controlador_InicioSesion.IdUsuario);
        }

        public static List<string> DatosMenu()
        {
            return Modelo_Menus.DatosMenu(IdMenu);
        }
    }
}
