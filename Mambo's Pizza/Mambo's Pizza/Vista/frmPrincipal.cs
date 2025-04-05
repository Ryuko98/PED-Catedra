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
    public partial class frmPrincipal : Form
    {
        int x = 0;
        int y = 0;

        public frmPrincipal()
        {
            InitializeComponent();
            frmInicio frm = new frmInicio();
            MostarPanel(frm);
        }

        void MostarPanel(Form frm)
        {
            while (contenido.Controls.Count > 0)
            {
                contenido.Controls.RemoveAt(0);
            }
            frm.TopLevel = false;
            frm.FormBorderStyle = FormBorderStyle.None;
            frm.Dock = DockStyle.Fill;
            contenido.Controls.Clear();
            contenido.Controls.Add(frm);
            titulo.Text = frm.Text;
            frm.Show();
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

        private void btnCerrar_MouseEnter(object sender, EventArgs e)
        {
            btnCerrar.BackColor = Color.Red;
        }

        private void btnCerrar_MouseLeave(object sender, EventArgs e)
        {
            btnCerrar.BackColor = ColorTranslator.FromHtml("#640D14");
        }

        private void btnMinimizar_MouseEnter(object sender, EventArgs e)
        {
            btnMinimizar.BackColor = ColorTranslator.FromHtml("#8C3A42");
        }

        private void btnMinimizar_MouseLeave(object sender, EventArgs e)
        {
            btnMinimizar.BackColor = ColorTranslator.FromHtml("#640D14");
        }

        private void btnClientes_Click_1(object sender, EventArgs e)
        {
            frmClientes frm = new frmClientes();
            MostarPanel(frm);
        }

        private void btnMembresias_Click(object sender, EventArgs e)
        {
            frmMembresias frm = new frmMembresias();
            MostarPanel(frm);
        }

        private void btnRepartidores_Click(object sender, EventArgs e)
        {
            frmRepartidores frm = new frmRepartidores();
            MostarPanel(frm);
        }

        private void btnReseñas_Click(object sender, EventArgs e)
        {
            frmReseñas frm = new frmReseñas();
            MostarPanel(frm);
        }

        private void btnUsuarios_Click(object sender, EventArgs e)
        {
            frmUsuarios frm = new frmUsuarios();
            MostarPanel(frm);
        }

        private void btnPedidos_Click(object sender, EventArgs e)
        {
            frmPedidos frm = new frmPedidos();
            MostarPanel(frm);
        }

        private void btnDetallesPedidos_Click(object sender, EventArgs e)
        {
            frmDetallesPedido frm = new frmDetallesPedido();
            MostarPanel(frm);
        }

        private void btnEstadosPedidos_Click(object sender, EventArgs e)
        {
            frmEstadosDePedidos frm = new frmEstadosDePedidos();
            MostarPanel(frm);
        }

        private void btnMenus_Click(object sender, EventArgs e)
        {
            frmMenu frm = new frmMenu();
            MostarPanel(frm);
        }

        private void btnInicio_Click(object sender, EventArgs e)
        {
            frmInicio frm = new frmInicio();
            MostarPanel(frm);
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

        private void titulo_MouseMove(object sender, MouseEventArgs e)
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
    }
}
