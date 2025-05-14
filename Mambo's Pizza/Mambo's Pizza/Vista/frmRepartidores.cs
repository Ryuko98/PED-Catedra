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
    public partial class frmRepartidores : Form
    {
        mensajes msg = new mensajes();
        public frmRepartidores()
        {
            InitializeComponent();
        }

        public void RefrescarPantalla()
        {
            dgvDatos.DataSource = Controlador_Repartidores.MostrarRepartidores();
        }

        void limpiarCampos()
        {
            txtDUI.Clear();
            txtCalificacionPromedio.Clear();
            txtTotalReseñas.Clear();
            cmbUsuario.SelectedIndex = -1;
            txtDisponibilidad.Clear();
        }

        private void frmRepartidores_Load(object sender, EventArgs e)
        {
            RefrescarPantalla();
            txtID.Enabled = false;

            dgvDatos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void btnInsertar_Click(object sender, EventArgs e)
        {

        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {

        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {

        }
    }
}
