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
    public partial class frmVistaClientes : Form
    {
        int x = 0;
        int y = 0;

        public frmVistaClientes()
        {
            InitializeComponent();
            //dgvOfertas.Rows.Add("Orange Chicken", "9.99");
            //dgvOfertas.Rows.Add("Pizza Mambo's Style", "9999.99");
            //dgvOfertas.Rows.Add("Chop Suey", "4.99");

            CargarOfertas();



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

        private void barra_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left)
            {
                x = e.X;
                y = e.Y;
            }
            else
            {
                Left = Left + (e.X - x);
                Top = Top + (e.Y - y);
            }
        }

        private void btnMinimizar_MouseEnter(object sender, EventArgs e)
        {
            btnMinimizar.BackColor = ColorTranslator.FromHtml("#8C3A42");
        }

        private void btnMinimizar_MouseLeave(object sender, EventArgs e)
        {
            btnMinimizar.BackColor = ColorTranslator.FromHtml("#640D14");
        }

        private void btnCerrar_MouseEnter(object sender, EventArgs e)
        {
            btnCerrar.BackColor = Color.Red;
        }

        private void btnCerrar_MouseLeave(object sender, EventArgs e)
        {
            btnCerrar.BackColor = ColorTranslator.FromHtml("#640D14");
        }

        public void CargarOfertas()
        {
            dgvOfertas.DataSource = null; // Quita el origen de datos
            dgvOfertas.Rows.Clear();      // Limpia las filas (por si acaso)
            dgvOfertas.Columns.Clear();   // Limpia las 
            DataTable dt = Controlador_Menus.ObtenerMenus();
            dgvOfertas.DataSource = dt;
        }


    }
}
