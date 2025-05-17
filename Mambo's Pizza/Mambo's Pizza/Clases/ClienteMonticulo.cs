using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mambo_s_Pizza.Clases
{
    public class ClienteMonticulo
    {
        public int valor;
        public int id; 
        public int nivel;

        public int CalcularNivel()
        {
            int idnivel = -1; 
            if (id > 0)
            {
                nivel = Convert.ToInt32(Math.Truncate(Math.Log(id) / Math.Log(2)));
            }
            idnivel = nivel;
            return idnivel;
        }

        public ClienteMonticulo()
        {
            valor = 0;
            id = 0;
            nivel = 0;
        }

        public ClienteMonticulo(int valornodo, int idposic = 0)
        {
            valor = valornodo;
            id = idposic;
            nivel = CalcularNivel(); 

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
