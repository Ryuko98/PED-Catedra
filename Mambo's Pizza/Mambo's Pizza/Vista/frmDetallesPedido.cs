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
    public partial class frmDetallesPedido : Form
    {
        mensajes msg = new mensajes();
        Controlador_EstadosPedidos objRepartidor;
        public frmDetallesPedido()
        {
            InitializeComponent();
        }

        public void RefrescarPantalla()
        {
            dgvDatos.DataSource = Modelo_DetallesPedidos.MostrarDetallesPedidos();
        }
        void limpiarCampos()
        {
            txtCantidad.Clear();
            txtPrecioUnitario.Clear();
            dgvDatos.ClearSelection();
        }

        private void frmDetallesPedido_Load(object sender, EventArgs e)
        {
            RefrescarPantalla();
            txtID.Enabled = false;

            // 1. Configurar ComboBoxes
            cmbPedido.DisplayMember = "Descripcion";
            cmbPedido.ValueMember = "IdPedido";
            cmbPedido.DataSource = Modelo_DetallesPedidos.MostrarPedidos();

            cmbMenu.DisplayMember = "NombreMenu";
            cmbMenu.ValueMember = "IdMenu";
            cmbMenu.DataSource = Modelo_DetallesPedidos.MostrarMenus();

            // 2. Configurar DataGridView
            dgvDatos.AutoGenerateColumns = false;
            dgvDatos.DataSource = Modelo_DetallesPedidos.MostrarDetallesPedidos();

            // 3. Configurar columnas manualmente (si AutoGenerateColumns es false)
            dgvDatos.Columns.Add(new DataGridViewTextBoxColumn()
            {
                Name = "colIdDetalle",
                DataPropertyName = "ID_Detalle",
                HeaderText = "ID Detalle"
            });


            dgvDatos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void btnInsertar_Click(object sender, EventArgs e)
        {
            // Validación de campos vacíos
            if (cmbPedido.SelectedItem == null || cmbMenu.SelectedItem == null ||
                string.IsNullOrWhiteSpace(txtCantidad.Text) || string.IsNullOrWhiteSpace(txtPrecioUnitario.Text))
            {
                msg.camposVacios();
                return;
            }

            try
            {
                // Obtener valores de los controles
                int idPedido = (int)cmbPedido.SelectedValue;
                int idMenu = (int)cmbMenu.SelectedValue;

                // Validar y convertir cantidad
                if (!int.TryParse(txtCantidad.Text, out int cantidad) || cantidad <= 0)
                {
                    msg.errorInsercion("La cantidad debe ser un número entero positivo", "Detalle Pedido");
                    return;
                }

                // Validar y convertir precio
                if (!decimal.TryParse(txtPrecioUnitario.Text, out decimal precioUnitario) || precioUnitario <= 0)
                {
                    msg.errorInsercion("El precio debe ser un valor numérico positivo", "Detalle Pedido");
                    return;
                }

                // Insertar en la base de datos
                var objDetalle = new Controlador_DetallesPedidos(idPedido, idMenu, cantidad, precioUnitario);
                bool respuesta = objDetalle.InsertarDetallePedido();

                if (respuesta)
                {
                    limpiarCampos();
                    RefrescarPantalla();
                    msg.exitoInsercion("Detalle de pedido");
                }
                else
                {
                    msg.errorInsercion("No se pudo agregar el detalle", "Tabla: DetallesPedidos");
                }
            }
            catch (FormatException)
            {
                msg.errorInsercion("Formato incorrecto en los datos numéricos", "Detalle Pedido");
            }
            catch (SqlException sqlEx)
            {
                // Manejo especial para error de FK
                if (sqlEx.Number == 547)
                {
                    msg.errorInsercion("El pedido o menú seleccionado no existe", "Detalle Pedido");
                }
                else
                {
                    msg.errorInsercion(sqlEx.Message, "Detalle Pedido");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error crítico: " + ex.Message, "Error",
                               MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            // Validar que haya un detalle seleccionado
            if (!(dgvDatos.SelectedRows.Count == 1 && txtID.Text != ""))
            {
                msg.seleccionarRegistro("actualizar");
                return;
            }

            // Validar campos obligatorios
            if (cmbPedido.SelectedItem == null || cmbMenu.SelectedItem == null ||
                string.IsNullOrWhiteSpace(txtCantidad.Text) || string.IsNullOrWhiteSpace(txtPrecioUnitario.Text))
            {
                msg.camposVacios();
                return;
            }

            try
            {
                // Obtener valores de los controles
                int idDetalle = int.Parse(txtPrecioUnitario.Text);
                int idPedido = (int)cmbPedido.SelectedValue;
                int idMenu = (int)cmbMenu.SelectedValue;

                // Validar y convertir cantidad
                if (!int.TryParse(txtCantidad.Text, out int cantidad) || cantidad <= 0)
                {
                    msg.errorActualizacion("La cantidad debe ser un entero positivo", "Detalle Pedido");
                    return;
                }

                // Validar y convertir precio
                if (!decimal.TryParse(txtPrecioUnitario.Text, out decimal precioUnitario) || precioUnitario <= 0)
                {
                    msg.errorActualizacion("El precio debe ser un valor positivo", "Detalle Pedido");
                    return;
                }

                // Actualizar en la base de datos
                var objDetalle = new Controlador_DetallesPedidos(idDetalle, idPedido, idMenu, cantidad, precioUnitario);
                bool resultado = objDetalle.ActualizarDetallePedido();

                if (resultado)
                {
                    msg.exitoActualizacion("Detalle de pedido");
                }
                else
                {
                    msg.errorActualizacion("No se pudo actualizar", "Tabla: DetallesPedidos");
                }
            }
            catch (FormatException)
            {
                msg.errorActualizacion("Formato numérico incorrecto", "Tabla: DetallesPedidos");
            }
            catch (SqlException sqlEx)
            {
                // Manejo especial para errores de FK o duplicados
                if (sqlEx.Number == 547) // FK constraint
                {
                    msg.errorActualizacion("El pedido o menú no existe", "Tabla: DetallesPedidos");
                }
                else if (sqlEx.Number == 2627) // Unique constraint
                {
                    msg.errorActualizacion("Registro duplicado", "Tabla: DetallesPedidos");
                }
                else
                {
                    msg.errorActualizacion(sqlEx.Message, "Tabla: DetallesPedidos");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error crítico: " + ex.Message, "Error",
                               MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            if (msg.confirmarEliminacion("detalle de pedido") == DialogResult.Yes)
            {
                try
                {
                    // Obtener el ID del detalle seleccionado
                    int idDetalle = Convert.ToInt32(txtID.Text);

                    // Llamar al controlador para eliminar
                    bool resultado = Controlador_DetallesPedidos.EliminarDetallePedido(idDetalle);

                    if (resultado)
                    {
                        msg.exitoEliminacion("Detalle de pedido");
                    }
                    else
                    {
                        msg.errorEliminacion("No se pudo eliminar", "Tabla: DetallesPedidos");
                    }
                }
                catch (FormatException)
                {
                    msg.errorEliminacion("ID de detalle no válido", "Tabla: DetallesPedidos");
                }
                catch (SqlException sqlEx)
                {
                    // Manejo especial para error de integridad referencial
                    if (sqlEx.Number == 547) // FK constraint violation
                    {
                        msg.errorEliminacion("Existen registros relacionados a este detalle", "Tabla: DetallesPedidos");
                    }
                    else
                    {
                        msg.errorEliminacion(sqlEx.Message, "Tabla: DetallesPedidos");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error crítico: " + ex.Message, "Error",
                                   MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    limpiarCampos();
                    RefrescarPantalla();
                }
            }
        }

        private void dgvDatos_Click(object sender, EventArgs e)
        {
            dgvDatos.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            if (dgvDatos.CurrentRow == null || dgvDatos.CurrentRow.IsNewRow) return;

            try
            {
                // Usar los nombres EXACTOS de las columnas
                txtID.Text = dgvDatos.CurrentRow.Cells["ID_Detalle"].Value?.ToString();

                // Obtener valores para ComboBoxes
                string descPedido = dgvDatos.CurrentRow.Cells["Descripcion_Pedido"].Value?.ToString();
                string nombreMenu = dgvDatos.CurrentRow.Cells["Nombre_Menu"].Value?.ToString();

                // Seleccionar en ComboBoxes por texto (no por valor)
                cmbPedido.Text = descPedido;
                cmbMenu.Text = nombreMenu;

                // Resto de campos
                txtCantidad.Text = dgvDatos.CurrentRow.Cells["Cantidad"].Value?.ToString();
                txtPrecioUnitario.Text = dgvDatos.CurrentRow.Cells["PrecioUnitario"].Value?.ToString();

                // Calcular subtotal
                if (decimal.TryParse(txtPrecioUnitario.Text, out decimal precio) &&
                    int.TryParse(txtCantidad.Text, out int cantidad))
                {
                    txtPrecioUnitario.Text = (precio * cantidad).ToString("N2");
                }
            }
            catch (Exception ex)
            {
                // Mensaje más informativo
                string errorDetails = $"Error al cargar datos:\n\n{ex.Message}\n\n" +
                                     "Columnas disponibles:\n";

                foreach (DataGridViewColumn col in dgvDatos.Columns)
                {
                    errorDetails += $"- {col.Name} ({col.DataPropertyName})\n";
                }

                MessageBox.Show(errorDetails, "Error de carga",
                               MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            limpiarCampos();
        }
    }
}
