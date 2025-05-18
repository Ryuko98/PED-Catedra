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
        int x = 0;
        int y = 0;
        int id_pedido = 0;
        string total = "";

        public frmCarrito()
        {
            InitializeComponent();
            id_pedido = Controlador_Pedidos.IdPedido;
            CargarCarrito();
            CargarInformacion();
        }
        private void CargarCarrito()
        {
            dgvCarrito.DataSource = null; // Quita el origen de datos
            dgvCarrito.Rows.Clear();      // Limpia las filas (por si acaso)
            dgvCarrito.Columns.Clear();   // Limpia las 

            DataTable dt = Controlador_Pedidos.CargarCarrito(id_pedido);
            dgvCarrito.DataSource = dt;
        }

        private void CargarInformacion()
        {
            string descripcion = Controlador_Pedidos.ObtenerDescripcion(id_pedido);
            if (!string.IsNullOrEmpty(descripcion))
            {
                // La descripción no es nula
                txtDescipcion.Text = descripcion;
            }
            total = Controlador_Pedidos.ObtenerTotal(id_pedido);
            if (!string.IsNullOrEmpty(total))
            {
                // El total no es nulo
                lblTotal.Text = "$"+ total;
            }


        }


        private void btnFinalizarCompra_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("¿Desea confirmar su compra?", "Confirmar carrito", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
            {
                // Confirmar pedido
                DateTime horaActual = DateTime.Now;
                bool confirmarCarrito = Controlador_Pedidos.FinalizarPedido(id_pedido, txtDescipcion.Text, horaActual, double.Parse(total));
                if (confirmarCarrito)
                {
                    MessageBox.Show("Compra realizada exitosamente. Puede monitorear la entrega de su pedido", "Gracias por su compra", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    frmVistaClientes frm = new frmVistaClientes();
                    frm.Show();
                    this.Hide();
                }
            }
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

        private void btnRegresar_Click(object sender, EventArgs e)
        {
            frmVistaClientes frm = new frmVistaClientes();
            frm.Show();
            this.Hide();
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
            btnMinimizar.BackColor = Color.Red;
        }

        private void btnCerrar_MouseLeave(object sender, EventArgs e)
        {
            btnCerrar.BackColor = ColorTranslator.FromHtml("#640D14");
        }
    }
}
