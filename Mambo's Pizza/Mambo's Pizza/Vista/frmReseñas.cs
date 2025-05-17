using Mambo_s_Pizza.Controlador;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
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
        }

        private void frmReseñas_Load(object sender, EventArgs e)
        {
            RefrescarPantalla();
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
    }
}
