using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mambo_s_Pizza.Controlador
{
    class Controlador_Pedidos
    {
        public int IdPedido { get; set; }
        public string Descripcion { get; set; }
        public int IdCliente { get; set; }
        public DateTime HoraPedido { get; set; }
        public DateTime HoraEntrega { get; set; }
        public int IdRepartidor { get; set; }
        public int IdEstadoPedido { get; set; }
        public decimal TotalPrecio { get; set; }
    }
}
