using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Mambo_s_Pizza.Controlador;

namespace Mambo_s_Pizza.Vista
{
    public partial class frmInfoActualPedido : Form
    {
        int x = 0;
        int y = 0;
        int id_pedido = 0;
        string repartidor = "";

        private DateTime comienzoTimer;
        private DateTime finalTimer;
        private Timer cronometroTimer;


        public frmInfoActualPedido()
        {
            InitializeComponent();


            id_pedido = Controlador_Pedidos.IdPedido;
            CargarCarrito();
            CargarInformacion();
            VerificarPedido();

        }

        private void ComenzarTimer()
        {

            // Establecer los tiempos de inicio y fin
            comienzoTimer = DateTime.Now;
            finalTimer = Controlador_Pedidos.ObtenerHoraEntrega(id_pedido);

            // Configurar el Timer
            cronometroTimer = new Timer();
            cronometroTimer.Interval = 1000; // 1 segundo
            cronometroTimer.Tick += CountdownTimer_Tick;
            cronometroTimer.Start();
        }

        // Evento tick para cada cambio del timer
        private void CountdownTimer_Tick(object sender, EventArgs e)
        {
            TimeSpan remaining = finalTimer - DateTime.Now;

            if (remaining.TotalSeconds <= 0)
            {
                cronometroTimer.Stop();
                lblEspera.Text = "¡Tiempo terminado!";
                // Cambiar estado de pedido
                bool confirmar = Controlador_Pedidos.EntregarPedido(id_pedido);
                if (confirmar)
                {
                    MessageBox.Show("¡Esperamos que disfrute su comida! Gracias por confiar en nosotros. \n\nSi necesita algo más, no dude en contactarnos.",
                     "Gracias por su compra",
                     MessageBoxButtons.OK,
                     MessageBoxIcon.Information);
                    frmVistaClientes frm = new frmVistaClientes();
                    frm.Show();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Error papu :(", "Gracias por su compra", 
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                lblEspera.Text = string.Format("Tiempo restante: {0:D2}:{1:D2}:{2:D2}",
                remaining.Hours, remaining.Minutes, remaining.Seconds);
            }
        }


        private void VerificarPedido()
        {
            int estado_pedido = Controlador_Pedidos.ObtenerEstado(id_pedido);
            // Verificar el estado del pedido
            if (estado_pedido == 2)
            {
                // Estado "Esperando confirmacion", por lo que falta confirmacion del repartidor
                lblEspera.Text = "Su pedido esta siendo preparado con los mejores ingredientes.";
                lblRepartidor.Text = "En unos momentos estará en camino."; 
                
            }
            else if(estado_pedido == 3)
            {
                // Estado "En camino", por lo que se le mostraran los datos del repartidor
                repartidor = Controlador_Pedidos.ObtenerRepartidorNombre(id_pedido);
                lblRepartidor.Text = "Repartidor: " + repartidor;
                //lblEspera.Text = "Tiempo restante: ";
                ComenzarTimer();
            }
        }

        private void CargarInformacion()
        {
            string descripcion = Controlador_Pedidos.ObtenerDescripcion(id_pedido);
            if (!string.IsNullOrEmpty(descripcion))
            {
                // La descripción no es nula
                lblDescripcion.Text = "Descripción: " + descripcion;
            }
            else
            {
                lblDescripcion.Text = "";
            }
            string total = Controlador_Pedidos.ObtenerTotal(id_pedido);
            if (!string.IsNullOrEmpty(total))
            {
                // El total no es nulo
                lblTotal.Text = "Total: $" + total;
            }
        }
        private void CargarCarrito()
        {
            dgvPedido.DataSource = null; // Quita el origen de datos
            dgvPedido.Rows.Clear();      // Limpia las filas (por si acaso)
            dgvPedido.Columns.Clear();   // Limpia las 

            DataTable dt = Controlador_Pedidos.CargarCarrito(id_pedido);
            dgvPedido.DataSource = dt;
        }


        private void btnRegresar_Click(object sender, EventArgs e)
        {
            frmVistaClientes frm = new frmVistaClientes();
            frm.Show();
            this.Hide();
        }

        private void btnMinimizar_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
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
    }
}
