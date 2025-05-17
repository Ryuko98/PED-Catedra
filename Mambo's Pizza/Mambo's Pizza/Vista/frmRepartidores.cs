using Mambo_s_Pizza.Controlador;
using Mambo_s_Pizza.Modelo;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Mambo_s_Pizza.Vista
{
    public partial class frmRepartidores : Form
    {
        mensajes msg = new mensajes();
        Controlador_Repartidores objRepartidor;
        public frmRepartidores()
        {
            InitializeComponent();
        }

        public void RefrescarPantalla()
        {
            dgvDatos.DataSource = Controlador_Repartidores.ObtenerRepartidores();
        }

        void limpiarCampos()
        {
            txtDUI.Clear();
            txtCalificacionPromedio.Clear();
            txtTotalReseñas.Clear();
            cmbUsuario.SelectedIndex = -1;
            txtDisponibilidad.Clear();
            dgvDatos.ClearSelection();
        }

        private void frmRepartidores_Load(object sender, EventArgs e)
        {
            RefrescarPantalla();
            txtID.Enabled = false;

            cmbUsuario.DataSource = Controlador_Repartidores.ObtenerUsuarios();
            cmbUsuario.DisplayMember = "Nombre";  // El nombre que se mostrará
            cmbUsuario.ValueMember = "IdUsuario";

            dgvDatos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void btnInsertar_Click(object sender, EventArgs e)
        {
            // Validación de campos vacíos
            if (txtDUI.Text == "" || cmbUsuario.SelectedItem == null || dtpRegistro.Value == null)
            {
                msg.camposVacios();
                return;
            }

            try
            {
                string dui, disponibilidad;
                int idUsuario, totalcalificaion;
                float calificacionPromedio;
                DateTime fechaRegistro;
                // Asignar valores desde los controles
                dui = txtDUI.Text;

                // Convertir calificaciones a números
                if (!float.TryParse(txtCalificacionPromedio.Text, out float calificacion))
                {
                    msg.errorInsercion("La calificación debe ser un número válido", "Repartidor");
                    return;
                }
                calificacionPromedio = calificacion;

                if (!int.TryParse(txtTotalReseñas.Text, out int totalReseñas))
                {
                    msg.errorInsercion("El total de reseñas debe ser un número entero", "Repartidor");
                    return;
                }
                totalcalificaion = totalReseñas;

                fechaRegistro = dtpRegistro.Value;
                idUsuario = (int)cmbUsuario.SelectedValue; // Asume que el combo tiene ValueMember=IdUsuario
                disponibilidad = txtDisponibilidad.Text;

                // Insertar en la base de datos
                objRepartidor = new Controlador_Repartidores(dui, calificacionPromedio, totalcalificaion,fechaRegistro, idUsuario, disponibilidad);
                bool respuesta = objRepartidor.InsertarRepartidor();
                if (respuesta == true)
                {
                    limpiarCampos();
                    RefrescarPantalla();
                }
                else
                {
                    msg.errorEliminacion("No se pudo agregar", "Tabla: Menus");
                }
            }
            catch (FormatException)
            {
                msg.errorInsercion("Formato incorrecto en los datos numéricos", "Repartidor");
            }
            catch (SqlException sqlEx)
            {
                msg.errorInsercion(sqlEx.Message, "Repartidor");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error crítico: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            // Método
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            // Validar que haya un repartidor seleccionado
            if (!(dgvDatos.SelectedRows.Count == 1 && txtID.Text != ""))
            {
                msg.seleccionarRegistro("actualizar");
                return;
            }

            // Validar campos obligatorios
            if (txtDUI.Text == "" || cmbUsuario.SelectedItem == null)
            {
                msg.camposVacios();
                return;
            }

            try
            {
                string dui, disponibilidad;
                int idUsuario, totalcalificaion;
                float calificacionPromedio;
                DateTime fechaRegistro;

                Controlador_Repartidores.IdRepartidor = int.Parse(txtID.Text);
                // Asignar valores desde los controles
                dui = txtDUI.Text;

                // Convertir calificaciones a números
                if (!float.TryParse(txtCalificacionPromedio.Text, out float calificacion))
                {
                    msg.errorInsercion("La calificación debe ser un número válido", "Repartidor");
                    return;
                }
                calificacionPromedio = calificacion;

                if (!int.TryParse(txtTotalReseñas.Text, out int totalReseñas))
                {
                    msg.errorInsercion("El total de reseñas debe ser un número entero", "Repartidor");
                    return;
                }
                totalcalificaion = totalReseñas;

                fechaRegistro = dtpRegistro.Value;
                idUsuario = (int)cmbUsuario.SelectedValue; // Asume que el combo tiene ValueMember=IdUsuario
                disponibilidad = txtDisponibilidad.Text;

                // Llamar al modelo para actualizar
                objRepartidor = new Controlador_Repartidores(dui, calificacionPromedio, totalcalificaion, fechaRegistro, idUsuario, disponibilidad);
                bool resultado = objRepartidor.ActualizarRepartidor();
                if (resultado == true)
                {
                    limpiarCampos();
                    RefrescarPantalla();
                }
                else
                {
                    msg.errorEliminacion("No se pudo actualizar", "Tabla: Menus");
                }
            }
            catch (FormatException)
            {
                msg.errorActualizacion("Formato de datos incorrecto", "Tabla: Repartidores");
            }
            catch (SqlException sqlEx)
            {
                // Manejo especial para error de DUI duplicado
                if (sqlEx.Number == 2627) // Violación de restricción UNIQUE
                {
                    msg.errorActualizacion("El DUI ingresado ya existe", "Tabla: Repartidores");
                }
                else
                {
                    msg.errorActualizacion(sqlEx.Message, "Tabla: Repartidores");
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

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            // Validar que haya una fila seleccionada y que el ID no esté vacío
            if (!(dgvDatos.SelectedRows.Count == 1 && txtID.Text != ""))
            {
                msg.seleccionarRegistro("eliminar");
                return;
            }

            // Confirmar con el usuario antes de eliminar
            if (msg.confirmarEliminacion("Tabla: Repartidores") == DialogResult.Yes)
            {
                try
                {
                    // Obtener el ID del repartidor seleccionado
                    Controlador_Repartidores.IdRepartidor = Convert.ToInt32(txtID.Text);

                    // Llamar al controlador para eliminar
                    bool resultado = Controlador_Repartidores.EliminarRepartidor();

                    if (resultado == true)
                    {
                        limpiarCampos();
                        RefrescarPantalla();
                    }
                    else
                    {
                        msg.errorEliminacion("No se pudo eliminar", "Tabla: Menus");
                    }

                }
                catch (FormatException)
                {
                    msg.errorEliminacion("ID de repartidor no válido", "Tabla: Repartidores");
                }
                catch (SqlException sqlEx)
                {
                    msg.errorEliminacion(sqlEx.Message, "Tabla: Repartidores");
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

        private void dgvDatos_Click(object sender, EventArgs e)
        {
            dgvDatos.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            if (dgvDatos.CurrentRow == null || dgvDatos.CurrentRow.IsNewRow) return;

            try
            {
                // Asignar valores a los controles con conversión segura
                txtID.Text = SafeToString(dgvDatos.CurrentRow.Cells["IdRepartidor"].Value);
                txtDUI.Text = SafeToString(dgvDatos.CurrentRow.Cells["DUI"].Value);

                // Manejo especial para campos numéricos
                txtCalificacionPromedio.Text = SafeToFloatString(dgvDatos.CurrentRow.Cells["CalificacionPromedio"].Value, "0.00");
                txtTotalReseñas.Text = SafeToIntString(dgvDatos.CurrentRow.Cells["TotalCalificaciones"].Value);

                txtDisponibilidad.Text = SafeToString(dgvDatos.CurrentRow.Cells["Disponibilidad"].Value);

                // Manejo del ComboBox para el usuario
                cmbUsuario.SelectedValue = SafeToInt(dgvDatos.CurrentRow.Cells["IdUsuario"].Value) ?? -1;

                // Manejo de fecha
                dtpRegistro.Value = SafeToDateTime(dgvDatos.CurrentRow.Cells["FechaRegistro"].Value) ?? DateTime.Now;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar datos del repartidor: {ex.Message}\n\nDetalles técnicos:\n{ex.StackTrace}",
                              "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private string SafeToString(object value)
        {
            return value?.ToString() ?? string.Empty;
        }

        private string SafeToFloatString(object value, string format = null)
        {
            if (value == null || value == DBNull.Value) return string.Empty;

            if (float.TryParse(value.ToString(), NumberStyles.Any, CultureInfo.InvariantCulture, out float result))
            {
                return format != null ? result.ToString(format) : result.ToString();
            }
            return string.Empty;
        }

        private string SafeToIntString(object value)
        {
            if (value == null || value == DBNull.Value) return string.Empty;

            if (int.TryParse(value.ToString(), out int result))
            {
                return result.ToString();
            }
            return string.Empty;
        }

        private int? SafeToInt(object value)
        {
            if (value == null || value == DBNull.Value) return null;

            if (int.TryParse(value.ToString(), out int result))
            {
                return result;
            }
            return null;
        }

        private DateTime? SafeToDateTime(object value)
        {
            if (value == null || value == DBNull.Value) return null;

            if (DateTime.TryParse(value.ToString(), out DateTime result))
            {
                return result;
            }
            return null;
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            limpiarCampos();
        }
    }
}
