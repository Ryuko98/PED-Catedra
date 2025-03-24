using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Mambo_s_Pizza
{
    public partial class frmInicioDeSesion : Form
    {
        public frmInicioDeSesion()
        {
            InitializeComponent();
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

        private void label1_MouseEnter(object sender, EventArgs e)
        {
            btnIngresar.BackColor = ColorTranslator.FromHtml("#8C3A42");
        }

        private void label1_MouseLeave(object sender, EventArgs e)
        {
            btnIngresar.BackColor = ColorTranslator.FromHtml("#640D14");
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

        private void btnAlternarVisibilidad_Click(object sender, EventArgs e)
        {
            if (txtClave.PasswordChar == '*')
            {
                txtClave.PasswordChar = '\0'; // Hace visible el texto
                btnAlternarVisibilidad.Image = Properties.Resources.icons8_visible_26;
            }
            else
            {
                txtClave.PasswordChar = '*'; // Oculta el texto
                btnAlternarVisibilidad.Image = Properties.Resources.icons8_invisible_26;
            }
        }

        private void btnIngresar_Click(object sender, EventArgs e)
        {
            if (txtUsuario.Text == "admin")
            {
                Vista.frmPrincipal frm = new Vista.frmPrincipal();
                frm.Show();
            }
            else if (txtUsuario.Text ==  "cliente")
            {
                Vista.frmVistaClientes frm = new Vista.frmVistaClientes();
                frm.Show();
            }
            else if (txtUsuario.Text == "repartidor")
            {
                Vista.frmPerfilRepartidor frm = new Vista.frmPerfilRepartidor();
                frm.Show();
            }
            else
            {
                MessageBox.Show("Verifique nuevamente las credenciales ingresadas", "Credenciales incorrectas", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            this.Hide();
        }
    }
}
