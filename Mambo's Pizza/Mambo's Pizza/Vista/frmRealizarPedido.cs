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
    public partial class frmRealizarPedido : Form
    {
        public frmRealizarPedido()
        {
            InitializeComponent();
        }

        private void btnAñadir_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("¿Finalizar la compra?", "Detalles del pedido", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                frmCarrito frm = new frmCarrito();
                frm.Show();
                this.Hide();
            }
            else
            {
                this.Hide();
            }
        }
    }
}
