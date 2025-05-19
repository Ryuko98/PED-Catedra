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

namespace Mambo_s_Pizza.Vista
{
    public partial class frmRealizarPedido : Form
    {
        private int idMenu, idPedido, cantidad;
        private string nombreMenu, Descripcion;
        private double precio;
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
            nombreMenu = datos[1];
            precio = float.Parse(datos[2]);
            Descripcion = datos[3];

            lblMenu.Text =  "Menu: " + nombreMenu;
            lblPrecio.Text =  "Precio: $" + precio;
            lblDescripcion.Text =  "Descripcion: " + Descripcion;
        }

        private void btnAñadir_Click(object sender, EventArgs e)
        {
             if (string.IsNullOrWhiteSpace(txtCantidad.Text) != true)
            {
                cantidad = int.Parse(txtCantidad.Text);
                decimal subtotal = (decimal)Math.Round(cantidad * precio, 2);
                if (MessageBox.Show("¿Desea agregar " + cantidad + " " + nombreMenu +
                    " al carrito por un total de $"
                    + subtotal + "?",
                    "Detalles del pedido", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    // Se agrega el menu al carro
                    // Verificar si existe carrito
                    int id_Cliente = Modelo_Clientes.EncontrarIdCliente(Controlador_InicioSesion.IdUsuario); //Capturamos el id del cliente
                    List<string> datosCarrito = new List<string>();
                    // Capturamos el carrito del cliente, si tiene
                    datosCarrito = Controlador_Pedidos.VerificarCarrito(id_Cliente);

                    if (datosCarrito != null && datosCarrito.Count > 0)
                    {
                        // Hay un carrito existente
                        idPedido = int.Parse(datosCarrito[0]);
                        Controlador_Pedidos.IdPedido = idPedido;
                        //MessageBox.Show("Existe un carrito para: " + Convert.ToString(id_Cliente));
                        if (Controlador_DetallesPedidos.AgregarDetallePedido(idPedido, idMenu, cantidad, subtotal))
                        {
                            MessageBox.Show("Se ha agregado correctamente el menu al carrito", "Carrito actualizado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            this.Close();
                        }

                    }
                    else
                    {
                        //MessageBox.Show("Se procedera a crear un carrito nuevo para: " + Convert.ToString(id_Cliente));
                        // No hay carrito, por lo tanto se creara el carrito
                        int id_Carrito = Modelo_Pedidos.CrearCarrito(id_Cliente);
                        //MessageBox.Show("Se creo el carrito exitosamente con id: " + Convert.ToString(id_Carrito));
                        if (Controlador_DetallesPedidos.AgregarDetallePedido(id_Carrito, idMenu, cantidad, subtotal))
                        {
                            Controlador_Pedidos.IdPedido = id_Carrito;
                            MessageBox.Show("Se ha agregado correctamente el menu al carrito", "Carrito actualizado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            this.Close();
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("Ingrese una cantidad para continuar.", "Campos vacios", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }


        }
    }
}
