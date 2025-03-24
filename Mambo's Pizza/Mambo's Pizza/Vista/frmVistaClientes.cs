using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Mambo_s_Pizza.Vista
{
    public partial class frmVistaClientes : Form
    {
        public frmVistaClientes()
        {
            InitializeComponent();
            dgvOfertas.Rows.Add("Orange Chicken", "9.99");
            dgvOfertas.Rows.Add("Pizza Mambo's Style", "9999.99");
            dgvOfertas.Rows.Add("Chop Suey", "4.99");

            dgvVolverPedir.Rows.Add("Pizza Mambo's Style EXTRA Spicy","19.99");
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("¿Cerrar el sistema?", "Cerrar", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                Application.Exit();
        }

        private void btnMinimizar_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        private void dgvOfertas_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            frmRealizarPedido frm = new frmRealizarPedido();
            frm.Show();
        }

        private void btnCarrito_Click(object sender, EventArgs e)
        {
            frmCarrito frm = new frmCarrito();
            frm.Show();
        }
    }
}
