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
using Mambo_s_Pizza.Modelo;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Mambo_s_Pizza.Vista
{
    public partial class frmVistaClientes : Form
    {
        int x = 0;
        int y = 0;
        int id_pedido = 0, id_cliente = 0;
        bool carrito_finalizado = false;
        mensajes msg = new mensajes();

        public frmVistaClientes()
        {
            InitializeComponent();
            Controlador_Pedidos.IdPedido = id_pedido;
            id_cliente = Modelo_Clientes.EncontrarIdCliente(Controlador_InicioSesion.IdUsuario); //Capturamos el id del cliente
            CargarOfertas();
            CargarHistorialPedidos();
            VerificarCarritoFinalizado();
            CargarPedidosRecibidos();
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


        private void btnCarrito_Click(object sender, EventArgs e)
        {
            if (carrito_finalizado)
            {
                // Ya hay un carrito finalizado
                frmInfoActualPedido frm1 = new frmInfoActualPedido();
                frm1.Show();
                this.Close();
            }
            else
            {
                // Verificar si hay carrito existente
                List<string> datosCarrito = new List<string>();
                // Capturamos el carrito del cliente, si tiene
                datosCarrito = Controlador_Pedidos.VerificarCarrito(id_cliente);

                if (datosCarrito != null && datosCarrito.Count > 0)
                {
                    // Hay un carrito existente
                    id_pedido = int.Parse(datosCarrito[0]);
                    Controlador_Pedidos.IdPedido = id_pedido;
                    //MessageBox.Show("Existe un carrito para: " + Convert.ToString(id_cliente));
                    frmCarrito frm1 = new frmCarrito();
                    frm1.Show();
                    this.Close();
                }
                else
                {
                    // No hay carrito existente
                    MessageBox.Show("Carrito vacio.");
                    //frmCarrito frm = new frmCarrito(false);
                    //frm.Show();
                }
            }

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

        private void CargarOfertas()
        {
            dgvOfertas.DataSource = null; // Quita el origen de datos
            dgvOfertas.Rows.Clear();      // Limpia las filas (por si acaso)
            dgvOfertas.Columns.Clear();   // Limpia las 
            DataTable dt = Controlador_Menus.ObtenerMenus();
            dgvOfertas.DataSource = dt;
        }

        private void CargarPedidosRecibidos()
        {
            dgvEvaluar.DataSource = null; // Quita el origen de datos
            dgvEvaluar.Rows.Clear();      // Limpia las filas (por si acaso)
            dgvEvaluar.Columns.Clear();   // Limpia las 
            DataTable dt = Controlador_Pedidos.ObtenerPedidosEntregados();
            dgvEvaluar.DataSource = dt;
        }

        private void dgvOfertas_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0) // Aseguramos que no se hizo clic en el encabezado
            {
                // Hagarramos el valor del la primera columna (idMenu) 
                int id = Convert.ToInt32(dgvOfertas.Rows[e.RowIndex].Cells[0].Value);

                // Pasa el ID al nuevo formulario
                frmRealizarPedido frm = new frmRealizarPedido(id);
                frm.Show();
            }
;
        }

        private void CargarHistorialPedidos()
        {
            dgvEvaluar.DataSource = null;
            dgvEvaluar.Rows.Clear();
            dgvEvaluar.Columns.Clear();
            DataTable dt = Controlador_Menus.ObtenerHistorialMenus();
            dgvEvaluar.DataSource = dt;
            dgvOfertas.Columns[0].Visible = false;
        }

        private void dgvEvaluar_CellClick(object sender, DataGridViewCellEventArgs e)
        {
          
            if (dgvEvaluar.CurrentRow == null || dgvEvaluar.CurrentRow.IsNewRow) return;
            try
            {
                int idCliente = Controlador_InicioSesion.IdUsuario;
                btnEvaluar.Enabled = true;
                dgvEvaluar.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                List<string> datos = new List<string>();
                datos = Controlador_Pedidos.DatosPedidoRepartidor();
                Controlador_Pedidos.IdPedido = Convert.ToInt32(datos[0]);
                Controlador_Pedidos.IdRepartidor = Convert.ToInt32(datos[1]);
                MessageBox.Show(datos[0]);
                MessageBox.Show(datos[1]);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void btnEvaluar_Click(object sender, EventArgs e)
        {
            frmReseñaDeCliente frm = new frmReseñaDeCliente();
            frm.Show();
            btnEvaluar.Enabled = false;
        }

        private void VerificarCarritoFinalizado()
        {
            // Verificar si hay carrito existente
            List<string> datosCarrito = new List<string>();
            // Capturamos el carrito del cliente, si tiene
            datosCarrito = Controlador_Pedidos.CarritoFinalizado(id_cliente);

            if (datosCarrito != null && datosCarrito.Count > 0)
            {
                MessageBox.Show("Cliente tiene un carrito siendo procesado.");
                // Hay un carrito finalizado, por lo tanto se debe cambiar el boton
                btnCarrito.Text = "Visualizar Pedido";
                id_pedido = int.Parse(datosCarrito[0]);
                Controlador_Pedidos.IdPedido = id_pedido;
                carrito_finalizado = true;

                //MessageBox.Show("Existe un carrito para: " + Convert.ToString(id_cliente));
                //frmCarrito frm1 = new frmCarrito(true);
                //frm1.Show();
            }
            else
            {
                // No hay carrito existente
                MessageBox.Show("No hay carritos finalizados.");
                carrito_finalizado = false;
                //frmCarrito frm = new frmCarrito(false);
                //frm.Show();
            }
        }
    }
}
