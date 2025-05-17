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
    public partial class frmRealizarPedido : Form
    {
        private int idMenu;
        public frmRealizarPedido(int id)
        {
            InitializeComponent();
            idMenu = id;
            CargarMenu();
        }
        private void CargarMenu()
        {
            Controlador_Menus.IdMenu = idMenu;
            List<string> datos = new List<string>();
            datos = Controlador_Menus.DatosMenu();
            Controlador_Menus.NombreMenu = datos[1];
            Controlador_Menus.Precio = float.Parse(datos[2]);
            lblMenu.Text =  "Menu: " + datos[1];
            lblPrecio.Text =  "Precio: $" + datos[2];
            lblDescripcion.Text =  "Descripcion: " + datos[3];
        }

        private void btnAñadir_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtCantidad.Text) != true)
            {
                float subtotal = float.Parse(txtCantidad.Text) * Controlador_Menus.Precio;
                if (MessageBox.Show("¿Desea agregar " + txtCantidad.Text + " " + Controlador_Menus.NombreMenu + " al carrito por un total de $"
                    + subtotal + "?",
                    "Detalles del pedido", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    // Se agrega el menu al carro
                    // Verificar si existe carrito
                    //if() 
                    int id_Cliente = Modelo.Modelo_Clientes.EncontrarIdCliente(Controlador_InicioSesion.IdUsuario);
                    MessageBox.Show(Convert.ToString(id_Cliente));
                    List<string> datosCarrito = new List<string>();
                    // Capturamos el carrito del cliente, si tiene
                    datosCarrito = Controlador_Pedidos.VerificarCarrito(id_Cliente);

                    if (datosCarrito != null && datosCarrito.Count > 0)
                    {
                        // Hay un carrito existente
                    }
                    else
                    {
                        // No hay carrito, por lo tanto se creara el carrito
                    }


                    //frmCarrito frm = new frmCarrito();
                    //frm.Show();
                    //this.Hide();
                }
            }
            else
            {
                MessageBox.Show("Ingrese una cantidad para continuar.", "Campos vacios", MessageBoxButtons.OK,MessageBoxIcon.Exclamation);
            }

            
        }
    }
}
