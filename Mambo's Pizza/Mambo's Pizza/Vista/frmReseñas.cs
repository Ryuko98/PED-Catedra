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
    public partial class frmReseñas : Form
    {
        mensajes msg = new mensajes();
        public frmReseñas()
        {
            InitializeComponent();
        }
        public Controlador_Reseñas objReseñas;

        public void RefrescarPantalla()
        {
            dgvDatos.DataSource = Controlador_Reseñas.ObtenerReseñas();
        }
        private void Limpiar()
        {
            txtID.Clear();
            cmbRepartidor.SelectedIndex = -1;
            cmbPedido.SelectedIndex = -1;
            txtCalificacion.Clear();
            txtComentario.Clear();
            txtFechaReview.Clear();
            dgvDatos.ClearSelection();
        }

        private void frmReseñas_Load(object sender, EventArgs e)
        {
            RefrescarPantalla();
            txtID.Enabled = false;

            dgvDatos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
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
            if (msg.confirmarEliminacion("Tabla: Reseñas") == DialogResult.Yes)
            {
                try
                {
                    // Obtener el ID del usuario seleccionado
                    Controlador_Reseñas.IdReview = Convert.ToInt32(txtID.Text);

                    // Llamar al controlador para eliminar

                    bool resultado = Controlador_Reseñas.EliminarReseñas();


                    if (resultado == true)
                    {
                        Limpiar();
                        RefrescarPantalla();
                    }
                    else
                    {
                        msg.errorEliminacion("No se pudo eliminar la reseña", "Tabla: Reseñas");
                    }

                }
                catch (FormatException)
                {
                    msg.errorEliminacion("ID de reseña no válido", "Tabla: Reseñas");
                }
                catch (SqlException sqlEx)
                {
                    msg.errorEliminacion(sqlEx.Message, "Tabla: Reseñas");
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

        private void dgvDatos_Click(object sender, EventArgs e)
        {
            dgvDatos.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            if (dgvDatos.CurrentRow == null || dgvDatos.CurrentRow.IsNewRow) return;

            try
            {
                // Asignar valores a los controles
                txtID.Text = dgvDatos.CurrentRow.Cells["IdReview"].Value?.ToString();
                cmbRepartidor.Text = dgvDatos.CurrentRow.Cells["IdRepartidor"].Value?.ToString();
                cmbPedido.Text = dgvDatos.CurrentRow.Cells["IdPedido"].Value?.ToString();
                txtCalificacion.Text = dgvDatos.CurrentRow.Cells["Calificacion"].Value?.ToString();
                txtComentario.Text = dgvDatos.CurrentRow.Cells["Comentario"].Value?.ToString();
                txtFechaReview.Text = dgvDatos.CurrentRow.Cells["FechaReview"].Value?.ToString();

            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar datos del usuario: {ex.Message}", "Error",
                              MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            Limpiar();
        }

        private void btnInsertar_Click(object sender, EventArgs e)
        {

        }
    }
}
