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
        // Propiedades
        public int IdDetallePedido { get; set; }
        public int IdPedido { get; set; }
        public int IdMenu { get; set; }
        public int Cantidad { get; set; }
        public decimal PrecioUnitario { get; set; }

        // Constructor para nuevo detalle
        public Controlador_DetallesPedidos(int pIdPedido, int pIdMenu, int pCantidad, decimal pPrecioUnitario)
        {
            IdPedido = pIdPedido;
            IdMenu = pIdMenu;
            Cantidad = pCantidad;
            PrecioUnitario = pPrecioUnitario;
        }

        // Constructor para actualizar detalle (incluye ID)
        public Controlador_DetallesPedidos(int pIdDetallePedido, int pIdPedido, int pIdMenu, int pCantidad, decimal pPrecioUnitario)
        {
            IdDetallePedido = pIdDetallePedido;
            IdPedido = pIdPedido;
            IdMenu = pIdMenu;
            Cantidad = pCantidad;
            PrecioUnitario = pPrecioUnitario;
        }

        // Métodos
        public static DataTable ObtenerDetallesPedidos(int idPedido)
        {
            return Modelo_DetallesPedidos.MostrarDetallesPedidos();
        }

        public bool InsertarDetallePedido()
        {
            return Modelo_DetallesPedidos.AgregarDetallePedido(IdPedido, IdMenu, Cantidad, PrecioUnitario);
        }

        public bool ActualizarDetallePedido()
        {
            return Modelo_DetallesPedidos.ActualizarDetallePedido(IdDetallePedido, IdPedido, IdMenu, Cantidad, PrecioUnitario);
        }

        public static bool EliminarDetallePedido(int idDetallePedido)
        {
            return Modelo_DetallesPedidos.EliminarDetallePedido(idDetallePedido);
        }

        // Método adicional para calcular subtotal
        public decimal CalcularSubtotal()
        {
            return Cantidad * PrecioUnitario;
        }

        internal static bool ObtenerDetallesPedidos(int idPedido, int idMenu, int cantidad, double subtotal)
        {
            throw new NotImplementedException();
        }
    }
}
