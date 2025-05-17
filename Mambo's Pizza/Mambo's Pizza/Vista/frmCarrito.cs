using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Mambo_s_Pizza.Controlador;

namespace Mambo_s_Pizza.Vista
{
    public partial class frmCarrito : Form
    {
        public frmCarrito(bool existe_carrito)
        {
            InitializeComponent();
            //dgvCarrito.Rows.Add("Orange Chicken", "2", "18.99");
            CargarOfertas();
        }
        public void CargarOfertas()
        {
            dgvCarrito.DataSource = null; // Quita el origen de datos
            dgvCarrito.Rows.Clear();      // Limpia las filas (por si acaso)
            dgvCarrito.Columns.Clear();   // Limpia las 

            DataTable dt = Controlador_Pedidos.CargarCarrito(Controlador_Pedidos.IdPedido);
            dgvCarrito.DataSource = dt;
        }

        private void btnFinalizarCompra_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Compra realizada exitosamente. Puede monitorear la entrega de su pedido.", "Compra exitosa");
            frmInfoActualPedido frm = new frmInfoActualPedido();
            frm.Show();
            this.Hide();
        }
    }
}
