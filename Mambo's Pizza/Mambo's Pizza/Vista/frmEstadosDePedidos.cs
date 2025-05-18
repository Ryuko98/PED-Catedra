using Mambo_s_Pizza.Controlador;
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
    public partial class frmEstadosDePedidos : Form
    {
        mensajes msg = new mensajes();
        Controlador_EstadosPedidos objRepartidor;
        public frmEstadosDePedidos()
        {
            InitializeComponent();
        }

        public void RefrescarPantalla()
        {
            dgvDatos.DataSource = Controlador_EstadosPedidos.ObtenerEstadosPedidos();
        }

        void limpiarCampos()
        {
            txtEstado.Clear();
            dgvDatos.ClearSelection();
        }

        private void frmEstadosDePedidos_Load(object sender, EventArgs e)
        {
            RefrescarPantalla();
            txtID.Enabled = false;

            dgvDatos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void btnInsertar_Click(object sender, EventArgs e)
        {
            // Validación de campo vacío
            if (txtEstado.Text == "")
            {
                msg.camposVacios();
                return;
            }

            try
            {
                // Obtener valor desde el control
                string estado = txtEstado.Text;

                // Insertar en la base de datos
                var objEstado = new Controlador_EstadosPedidos(estado);
                bool respuesta = objEstado.InsertarEstadoPedido();

                if (respuesta)
                {
                    limpiarCampos();
                    RefrescarPantalla();
                    msg.exitoInsercion("Estado de pedido");
                }
                else
                {
                    msg.errorInsercion("No se pudo agregar el estado", "Tabla: EstadosPedidos");
                }
            }
            catch (SqlException sqlEx)
            {
                msg.errorInsercion(sqlEx.Message, "Estado de pedido");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error crítico: " + ex.Message, "Error",
                               MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            // Validar que haya un estado seleccionado
            if (!(dgvDatos.SelectedRows.Count == 1 && txtID.Text != ""))
            {
                msg.seleccionarRegistro("actualizar");
                return;
            }

            // Validar campo obligatorio
            if (txtEstado.Text == "")
            {
                msg.camposVacios();
                return;
            }

            try
            {
                // Obtener valores desde los controles
                int idEstado = int.Parse(txtID.Text);
                string estado = txtEstado.Text;

                // Llamar al controlador para actualizar
                var objEstado = new Controlador_EstadosPedidos(idEstado, estado);
                bool resultado = objEstado.ActualizarEstadoPedido();

                if (resultado)
                {
                    msg.exitoActualizacion("Estado de pedido");
                }
                else
                {
                    msg.errorActualizacion("No se pudo actualizar el estado", "Tabla: EstadosPedidos");
                }
            }
            catch (FormatException)
            {
                msg.errorActualizacion("El ID debe ser un número válido", "Tabla: EstadosPedidos");
            }
            catch (SqlException sqlEx)
            {
                // Manejo especial para error de estado duplicado
                if (sqlEx.Number == 2627) // Violación de restricción UNIQUE
                {
                    msg.errorActualizacion("Este estado ya existe", "Tabla: EstadosPedidos");
                }
                else
                {
                    msg.errorActualizacion(sqlEx.Message, "Tabla: EstadosPedidos");
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
            if (msg.confirmarEliminacion("Estado de pedido") == DialogResult.Yes)
            {
                try
                {
                    // Obtener el ID del estado seleccionado
                    int idEstado = Convert.ToInt32(txtID.Text);

                    // Llamar al método estático para eliminar
                    bool resultado = Controlador_EstadosPedidos.EliminarEstadoPedido(idEstado);

                    if (resultado)
                    {
                        msg.exitoEliminacion("Estado de pedido");
                    }
                    else
                    {
                        msg.errorEliminacion("No se pudo eliminar el estado", "Tabla: EstadosPedidos");
                    }
                }
                catch (FormatException)
                {
                    msg.errorEliminacion("ID de estado no válido", "Tabla: EstadosPedidos");
                }
                catch (SqlException sqlEx)
                {
                    // Manejar error específico de FK constraint (si otros registros dependen de este estado)
                    if (sqlEx.Number == 547) // FK constraint violation
                    {
                        msg.errorEliminacion("No se puede eliminar - existen pedidos con este estado", "Tabla: EstadosPedidos");
                    }
                    else
                    {
                        msg.errorEliminacion(sqlEx.Message, "Tabla: EstadosPedidos");
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
                // Asignar valores directamente a los controles
                txtID.Text = dgvDatos.CurrentRow.Cells["IdEstadoPedido"].Value?.ToString();
                txtEstado.Text = dgvDatos.CurrentRow.Cells["Estado"].Value?.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar datos del estado: {ex.Message}", "Error",
                              MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
