using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace Mambo_s_Pizza
{
    public class Conexion
    {
        private SqlConnection conexion;

        public  Conexion()
        {
            conexion = new SqlConnection("server= localhost; database= PED_Catedra; user = sa; password = 12345; Trusted_Connection=True;");
        }

        public SqlConnection AbrirConexion()
        {
            if (conexion.State == System.Data.ConnectionState.Closed)
                conexion.Open();
            return conexion;
        }

        public void CerrarConexion()
        {
            if (conexion.State == System.Data.ConnectionState.Open)
                conexion.Close();
        }
    }
}
