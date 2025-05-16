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
    public partial class frmClientes : Form
    {
        mensajes msg = new mensajes();
        public Controlador_Clientes objClientes;

        public frmClientes()
        {
            InitializeComponent();
        }

        public void RefrescarPantalla()
        {
            dgvDatos.DataSource = Controlador_Clientes.ObtenerClientes();
        }

        private void Limpiar()
        {
            cmbUsuario.SelectedIndex = -1;
            cmbMembresia.SelectedIndex = -1;
            txtDireccion.Clear();
        }

        private void frmClientes_Load(object sender, EventArgs e)
        {
            RefrescarPantalla();
            txtID.Enabled = false;

            dgvDatos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void btnInsertar_Click(object sender, EventArgs e)
        {

        }

    }
}
