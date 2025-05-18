using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Mambo_s_Pizza.Clases;
using Mambo_s_Pizza.Controlador;

namespace Mambo_s_Pizza.Vista
{
    public partial class frmPerfilRepartidor : Form
    {
        int x = 0;
        int y = 0;
        Monticulo mon;
        public frmPerfilRepartidor()
        {
            InitializeComponent();
            CargarDatosRepartidor();
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("¿Cerrar su sesión?", "Salir", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                frmInicioDeSesion frmLogin = new frmInicioDeSesion();
                frmLogin.Show();
                this.Hide();
            }
        }

        private void btnMinimizar_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
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

        void CargarDatosRepartidor()
        {
            try
            {
                Controlador_PerfilRepartidor.CargarDatosRepartidor();

                lblNombre.Text += Controlador_PerfilRepartidor.NombreCompleto;
                lblCorreo.Text += Controlador_PerfilRepartidor.Correo;
                lblUsuario.Text += Controlador_PerfilRepartidor.Usuario;
                lblDUI.Text += Controlador_PerfilRepartidor.DUI;
                lblCalificacion.Text += Controlador_PerfilRepartidor.CalificacionPromedio+"/5";
                lblFechaRegistro.Text += Convert.ToDateTime(Controlador_PerfilRepartidor.FechaRegistro).ToString("dd/MM/yyyy");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnVerRseñas_Click(object sender, EventArgs e)
        {
            frmPerfilRepartidorReseñas frm = new frmPerfilRepartidorReseñas();
            frm.Show();
        }

        private void dgvDatos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void frmPerfilRepartidor_Load(object sender, EventArgs e)
        {
            Monticulo monticulo = new Monticulo();
            DataTable dtPedidos = monticulo.CargarPedidos(); // Obtiene datos ordenados

            dgvDatos.DataSource = dtPedidos;
        }
    }
}
