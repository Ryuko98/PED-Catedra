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
    public partial class frmMembresias : Form
    {
        mensajes msg = new mensajes();
        public frmMembresias()
        {
            InitializeComponent();
        }
        public Controlador_Membresias objMembresias;

        private void Limpiar()
        {
            txtID.Clear();
            txtDescripcion.Clear();
            txtMembresia.Clear();
        }

        private void RefrescarPantalla()
        {
            dgvDatos.DataSource = Controlador_Membresias.ObtenerMembresias();
        }

        private void frmMembresias_Load(object sender, EventArgs e)
        {
            RefrescarPantalla();
            Limpiar();

            txtID.Enabled = false;

            dgvDatos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void dgvDatos_Click(object sender, EventArgs e)
        {
            dgvDatos.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            if (dgvDatos.CurrentRow == null || dgvDatos.CurrentRow.IsNewRow) return;

            try
            {
                // Asignar valores a los controles
                txtID.Text = dgvDatos.CurrentRow.Cells["IdMembresia"].Value?.ToString();
                txtMembresia.Text = dgvDatos.CurrentRow.Cells["Membresia"].Value?.ToString();
                txtDescripcion.Text = dgvDatos.CurrentRow.Cells["Descripcion"].Value?.ToString();

            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar datos de la membresia: {ex.Message}", "Error",
                              MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnInsertar_Click(object sender, EventArgs e)
        {
            // Validación de campos vacíos
            if (txtMembresia.Text == "" || txtDescripcion.Text == "")
            {
                msg.camposVacios();
                return;
            }

            try
            {
                string membresia, descripcion;
                membresia = txtMembresia.Text;
                descripcion = txtDescripcion.Text;

                objMembresias = new Controlador_Membresias(membresia, descripcion);
                bool resultado = objMembresias.InsertarMembresias();

                if (resultado == true)
                {
                    Limpiar();
                    RefrescarPantalla();
                }
                else
                {
                    msg.errorEliminacion("No se pudo agregar", "Tabla: Membresias");
                }

            }
            catch (FormatException)
            {
                msg.errorInsercion("Formato incorrecto en los datos", "Membresias");
            }
            catch (SqlException sqlEx)
            {
                msg.errorInsercion(sqlEx.Message, "Membresias");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error crítico: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            // Validar que haya un usuario seleccionado
            if (!(dgvDatos.SelectedRows.Count == 1 && txtID.Text != ""))
            {
                msg.seleccionarRegistro("actualizar");
                return;
            }

            // Validar campos vacíos
            if (txtMembresia.Text == "" || txtDescripcion.Text == "")
            {
                msg.camposVacios();
                return;
            }

            try
            {
                string membresia, descripcion;
                membresia = txtMembresia.Text;
                descripcion = txtDescripcion.Text;
                Controlador_Membresias.IdMembresia = Convert.ToInt16(txtID.Text);
                objMembresias = new Controlador_Membresias(membresia, descripcion);


                //Llamar al controlador para actualizar

                bool resultado = objMembresias.ActualizarMembresias();

                if (resultado == true)
                {
                    Limpiar();
                    RefrescarPantalla();
                }
                else
                {
                    msg.errorEliminacion("No se pudo actualizar", "Tabla: Membresias");
                }
            }
            catch (FormatException)
            {
                msg.errorActualizacion("Formato de datos incorrecto", "Tabla: Membresias");
            }
            catch (SqlException sqlEx)
            {
                msg.errorActualizacion(sqlEx.Message, "Tabla: Membresias");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error crítico: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                Limpiar();
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
            if (msg.confirmarEliminacion("Tabla: Membresias") == DialogResult.Yes)
            {
                try
                {
                    // Obtener el ID del usuario seleccionado
                    Controlador_Membresias.IdMembresia = Convert.ToInt32(txtID.Text);

                    // Llamar al controlador para eliminar

                    bool resultado = Controlador_Membresias.EliminarMembresias();

                    if (resultado == true)
                    {
                        Limpiar();
                        RefrescarPantalla();
                    }
                    else
                    {
                        msg.errorEliminacion("No se pudo eliminar la membresia", "Tabla: Membresias");
                    }

                }
                catch (FormatException)
                {
                    msg.errorEliminacion("ID de membresia no válido", "Tabla: Membresias");
                }
                catch (SqlException sqlEx)
                {
                    msg.errorEliminacion(sqlEx.Message, "Tabla: Membresias");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error crítico: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    Limpiar();
                    RefrescarPantalla();
                }
            }
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            Limpiar();
        }
    }
}
