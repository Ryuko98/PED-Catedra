using Mambo_s_Pizza.Controlador;
using Mambo_s_Pizza.Modelo;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Mambo_s_Pizza.Vista
{
    public partial class frmPedidos : Form
    {
        mensajes msg = new mensajes();
        Controlador_Pedidos objPedido;
        public frmPedidos()
        {
            InitializeComponent();
        }

        public void RefrescarPantalla()
        {
            dgvDatos.DataSource = Modelo_Pedidos.MostrarPedidos();
        }

        void limpiarCampos()    
        {
            txtID.Clear();
            txtDescipcion.Clear();
            cmbCliente.SelectedIndex = -1;
            cmbRepartidor.SelectedIndex = -1;
            cmbEstado.SelectedIndex = -1;
            txtTotal.Clear();
            dgvDatos.ClearSelection();
        }

        private void frmPedidos_Load(object sender, EventArgs e)
        {
            RefrescarPantalla();
            txtID.Enabled = false;

            cmbCliente.DataSource = Controlador_Pedidos.ObtenerCliente();
            cmbCliente.DisplayMember = "NombreUsuario";  // El nombre que se mostrará
            cmbCliente.ValueMember = "IdCliente";

            cmbRepartidor.DataSource = Controlador_Pedidos.ObtenerRepartidor();
            cmbRepartidor.DisplayMember = "Nombre";  // El nombre que se mostrará
            cmbRepartidor.ValueMember = "IdRepartidor";

            cmbEstado.DataSource = Controlador_Pedidos.ObtenerEstadoPedido();
            cmbEstado.DisplayMember = "Estado";  // El nombre que se mostrará
            cmbEstado.ValueMember = "IdEstadoPedido";

            dgvDatos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void btnInsertar_Click(object sender, EventArgs e)
        {
            // Validación de campos vacíos
            if (string.IsNullOrWhiteSpace(txtDescipcion.Text) ||
                cmbCliente.SelectedValue == null ||
                cmbEstado.SelectedValue == null ||
                dtpEntrega.Value == null)
            {
                msg.camposVacios();
                return;
            }

            try
            {
                string Descripcion;
                int idCliente, idRepartidor, idEstado;
                double precio;
                DateTime horaPedido, horaEntrega;
                //Asignación de valores desde los controles
                Descripcion = txtDescipcion.Text;
                idCliente = Convert.ToInt32(cmbCliente.SelectedValue);
                horaPedido = dtpPedido.Value;
                // HoraEntrega (puede ser nula)
                horaEntrega = dtpEntrega.Value;
                // Repartidor (puede ser nulo si no está asignado)
                idRepartidor = cmbRepartidor.SelectedValue != null ?
                                         Convert.ToInt32(cmbRepartidor.SelectedValue) : 0;

                idEstado = Convert.ToInt32(cmbEstado.SelectedValue);

                // Validación del precio total
                if (!double.TryParse(txtTotal.Text, out double totalPrecio))
                {
                    msg.errorInsercion("El precio total debe ser un valor numérico válido", "Pedido");
                    return;
                }
                precio = totalPrecio;

                objPedido = new Controlador_Pedidos(Descripcion, idCliente, horaPedido, horaEntrega, idRepartidor, idEstado, precio);
                // Llamada al modelo para insertar
                bool resultado = objPedido.InsertarUsuarios();

                if (resultado == true)
                {
                    limpiarCampos();
                    RefrescarPantalla();
                }
                else
                {
                    msg.errorEliminacion("No se pudo agregar el pedido", "Tabla: Menus");
                }
            }
            catch (FormatException)
            {
                msg.errorInsercion("Formato incorrecto en los datos", "Pedido");
            }
            catch (SqlException sqlEx)
            {
                msg.errorInsercion(sqlEx.Message, "Pedido");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error crítico: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            // Validar que haya un pedido seleccionado
            if (!(dgvDatos.SelectedRows.Count == 1 && txtID.Text != ""))
            {
                msg.seleccionarRegistro("actualizar");
                return;
            }

            // Validar campos obligatorios
            if (string.IsNullOrWhiteSpace(txtDescipcion.Text) ||
                cmbCliente.SelectedValue == null ||
                cmbEstado.SelectedValue == null ||
                dtpPedido.Value == null)
            {
                msg.camposVacios();
                return;
            }

            try
            {
                string Descripcion;
                int idCliente, idRepartidor, idEstado;
                double precio;
                DateTime horaPedido, horaEntrega;
                //Asignación de valores desde los controles
                Descripcion = txtDescipcion.Text;
                idCliente = Convert.ToInt32(cmbCliente.SelectedValue);
                horaPedido = dtpPedido.Value;
                // HoraEntrega (puede ser nula)
                horaEntrega = dtpEntrega.Value;
                // Repartidor (puede ser nulo si no está asignado)
                idRepartidor = cmbRepartidor.SelectedValue != null ?
                                         Convert.ToInt32(cmbRepartidor.SelectedValue) : 0;

                idEstado = Convert.ToInt32(cmbEstado.SelectedValue);

                // Validación del precio total
                if (!double.TryParse(txtTotal.Text, out double totalPrecio))
                {
                    msg.errorInsercion("El precio total debe ser un valor numérico válido", "Pedido");
                    return;
                }
                precio = totalPrecio;
                Controlador_Pedidos.IdPedido = Convert.ToInt32(txtID.Text);
                objPedido = new Controlador_Pedidos(Descripcion, idCliente, horaPedido, horaEntrega, idRepartidor, idEstado, precio);
                // Llamada al modelo para insertar
                bool resultado = objPedido.ActualizarUsuarios();

                if (resultado == true)
                {
                    limpiarCampos();
                    RefrescarPantalla();
                }
                else
                {
                    msg.errorEliminacion("No se pudo actualizar el pedido", "Tabla: Menus");
                }
            }
            catch (FormatException)
            {
                msg.errorActualizacion("Formato de datos incorrecto", "Tabla: Pedidos");
            }
            catch (SqlException sqlEx)
            {
                msg.errorActualizacion(sqlEx.Message, "Tabla: Pedidos");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error crítico: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                limpiarCampos();
                RefrescarPantalla();
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            // Validar que haya una fila seleccionada y que el ID no esté vacío
            if (!(dgvDatos.SelectedRows.Count == 1 && txtID.Text != ""))
            {
                msg.seleccionarRegistro("eliminar");
                return;
            }

            // Confirmar con el usuario antes de eliminar
            if (msg.confirmarEliminacion("Tabla: Pedidos") == DialogResult.Yes)
            {
                try
                {
                    // Obtener el ID del pedido seleccionado
                    int id = Convert.ToInt32(dgvDatos.CurrentRow.Cells["IdPedido"].Value);

                    //Llamar al controlador para eliminar
                    bool resultado = Modelo_Pedidos.EliminarPedido(id);

                    if (resultado == true)
                    {
                        limpiarCampos();
                        RefrescarPantalla();
                    }
                    else
                    {
                        msg.errorEliminacion("No se pudo eliminar el pedido", "Tabla: Pedidos");
                    }
                }
                catch (FormatException)
                {
                    msg.errorEliminacion("ID de pedido no válido", "Tabla: Pedidos");
                }
                catch (SqlException sqlEx)
                {
                    // Manejo especial para error de clave foránea
                    if (sqlEx.Number == 547) // SQL Server error code for constraint violation
                    {
                        msg.errorEliminacion("No se puede eliminar el pedido porque tiene registros relacionados", "Tabla: Pedidos");
                    }
                    else
                    {
                        msg.errorEliminacion(sqlEx.Message, "Tabla: Pedidos");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error crítico: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    limpiarCampos();
                    RefrescarPantalla();
                }
            }
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            limpiarCampos();
        }

        private void dgvDatos_Click(object sender, EventArgs e)
        {
            dgvDatos.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            if (dgvDatos.CurrentRow == null || dgvDatos.CurrentRow.IsNewRow) return;

            try
            {
                txtID.Text = ObtenerValorCelda("IdPedido");
                txtDescipcion.Text = ObtenerValorCelda("Descripcion");
                txtTotal.Text = ObtenerValorCelda("TotalPrecio", "0");
                DateTime fechaPedido;

                if (DateTime.TryParse(ObtenerValorCelda("HoraPedido"), out fechaPedido))
                    dtpPedido.Value = fechaPedido;

                if (DateTime.TryParse(ObtenerValorCelda("HoraEntrega"), out DateTime fechaEntrega))
                {
                    dtpEntrega.Value = fechaEntrega;
                    dtpEntrega.Checked = true;
                }

                else
                {
                    dtpEntrega.Checked = false;
                }

                if (dgvDatos.Columns.Contains("Cliente")) 
                {
                    string nombreCliente = ObtenerValorCelda("Cliente");
                    if (!string.IsNullOrEmpty(nombreCliente))
                    {
                        // Buscar el IdCliente usando el nombre
                        int idCliente = ObtenerIdClientePorNombre(nombreCliente);
                        if (idCliente > 0 && cmbCliente.Items.Count > 0)
                        {
                            cmbCliente.SelectedValue = idCliente;
                        }
                    }
                }
                if (dgvDatos.Columns.Contains("IdRepartidor"))
                {
                    int idRepartidor;
                    if (int.TryParse(ObtenerValorCelda("IdRepartidor"), out idRepartidor))
                        cmbRepartidor.SelectedValue = idRepartidor;
                }
                if (dgvDatos.Columns.Contains("IdEstadoPedido"))
                {
                    int idEstado;
                    if (int.TryParse(ObtenerValorCelda("IdEstadoPedido"), out idEstado))
                        cmbEstado.SelectedValue = idEstado;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar datos: {ex.Message}", "Error",
                              MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private string ObtenerValorCelda(string nombreColumna, string valorPorDefecto = "")
        {
            if (dgvDatos.Columns.Contains(nombreColumna) &&
                dgvDatos.CurrentRow.Cells[nombreColumna].Value != null)
            {
                return dgvDatos.CurrentRow.Cells[nombreColumna].Value.ToString();
            }
            return valorPorDefecto;
        }

        private int ObtenerIdClientePorNombre(string nombreCliente)
        {
            try
            {
                using (var con = new SqlConnection("TuCadenaDeConexion"))
                {
                    string query = @"SELECT c.IdCliente 
                           FROM Clientes c
                           INNER JOIN Usuarios u ON c.IdUsuario = u.IdUsuario
                           WHERE u.Nombre + ' ' + u.Apellido = @Nombre";

                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.Parameters.AddWithValue("@Nombre", nombreCliente);
                    con.Open();
                    object result = cmd.ExecuteScalar();
                    return result != null ? Convert.ToInt32(result) : 0;
                }
            }
            catch
            {
                return 0;
            }
        }
    }
}
