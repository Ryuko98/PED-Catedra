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
            ActualizarListaPedidos();
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
                lblCalificacion.Text += Controlador_PerfilRepartidor.CalificacionPromedio + "/5";
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

        private void btnDespacharPedido_Click(object sender, EventArgs e)
        {
            // Primero validar si ya tiene un pedido en curso
            if (Controlador_PedidosHeap.RepartidorTienePedidoEnCurso())
            {
                MessageBox.Show("No puedes aceptar más pedidos. Tienes uno en curso.","Advertencia",MessageBoxButtons.OK,MessageBoxIcon.Warning);
                return;
            }
            // Si no tiene pedido en curso entonces procede a despachar el pedido correspondiente :p
            if (Controlador_PedidosHeap.DespacharPedido())
            {
                MessageBox.Show("Pedido despachado correctamente");
                ActualizarListaPedidos();
            }
            else
            {
                MessageBox.Show("No hay pedidos para despachar");
            }
        }

        private void ActualizarListaPedidos()
        {
            Controlador_PedidosHeap.CargarPedidosPendientes();
            dgvDatos.Rows.Clear();
            dgvDatos.Columns.Clear();
            dgvDatos.Columns.Add("colIdPedido", "ID Pedido");
            dgvDatos.Columns.Add("colMembresia", "Tipo Membresía");
            dgvDatos.Columns.Add("colMembresia", "Nivel Membresía");
            dgvDatos.Columns.Add("colDireccion", "Dirección Entrega");

            var pedidos = Controlador_PedidosHeap.ObtenerPedidosOrdenados();

            foreach (var pedido in pedidos)
            {
                string nivelMembresia;

                switch (pedido.IdMembresia)
                {
                    case 1:
                        nivelMembresia = "Básica";
                        break;
                    case 2:
                        nivelMembresia = "Intermedia";
                        break;
                    case 3:
                        nivelMembresia = "VIP";
                        break;
                    default:
                        nivelMembresia = "Desconocida";
                        break;
                }

                dgvDatos.Rows.Add(pedido.IdPedido, nivelMembresia, pedido.IdMembresia, pedido.Direccion);
                dgvDatos.Rows[0].Selected = true;
            }
        }
    }
}
