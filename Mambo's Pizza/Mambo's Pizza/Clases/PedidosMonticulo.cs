using Mambo_s_Pizza.Controlador;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mambo_s_Pizza.Clases
{
    public class PedidosMonticulo
    {
        public int id;
        public string descripcion;
        public string menu;
        public string direccion;
        public string membresia;
        public decimal totalPrecio;
        public int prioridad;

        public PedidosMonticulo(int id, string descripcion, string menu, string direccion, string membresia, decimal totalPrecio)
        {
            this.id = id;
            this.descripcion = descripcion;
            this.menu = menu;
            this.direccion = direccion;
            this.membresia = membresia;
            this.totalPrecio = totalPrecio;
            this.prioridad = AsignarPrioridad(membresia);
        }


        private int AsignarPrioridad(string tipoMembresia)
        {
            return Controlador_PerfilRepartidor.OrdenarPrioridad();
        }


        public int Padre()
        {
            if (id == 0)
            {
                return -1;
            }
            else
            {
                return id / 2;
            }
        }
        public int Hijo1()
        {
            return 2 * id;
        }
    }
}
