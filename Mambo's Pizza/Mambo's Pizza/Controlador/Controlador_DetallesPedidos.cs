using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mambo_s_Pizza.Modelo;

namespace Mambo_s_Pizza.Controlador
{
    public class Controlador_DetallesPedidos
    {
        public static int IdDetallePedido { get; set; }
        public int IdUsuario { get; set; }
        public string Direccion { get; set; }
        public int IdMembresia { get; set; }
        public DateTime FechaExpiracion { get; set; }

        public static bool AgregarDetallePedido(int IdPedido, int IdMenu, int Cantidad, double Precio)
        {
            return Modelo_DetallesPedidos.AgregarDetalle(IdPedido, IdMenu, Cantidad, Precio);
        }

    }
}
