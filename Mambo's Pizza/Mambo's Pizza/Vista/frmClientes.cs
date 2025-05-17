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

        List<KeyValuePair<int, string>> listaUsuarios = Controlador_Clientes.CargarUsuariosClientes();
        List<KeyValuePair<int, string>> listaMembresias = Controlador_Clientes.CargarMembresiaCliente();


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
            dtpExpiracion.Text = "";
        }

        private void frmClientes_Load(object sender, EventArgs e)
        {
            RefrescarPantalla();
            txtID.Enabled = false;

            dgvDatos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            // Configurar el ComboBox de usuarios
            cmbUsuario.DataSource = listaUsuarios;
            cmbUsuario.DisplayMember = "Value";  // Muestra el nombre completo
            cmbUsuario.ValueMember = "Key";      // Valor oculto (IdUsuario)

            // Configurar el ComboBox de membresias
            cmbMembresia.DataSource = listaMembresias;
            cmbMembresia.DisplayMember = "Value";  // Muestra el nombre completo
            cmbMembresia.ValueMember = "Key";      // Valor oculto (IdMembresia)
        }

        private void btnInsertar_Click(object sender, EventArgs e)
        {

        }

        private void dgvDatos_Click(object sender, EventArgs e)
        {
            dgvDatos.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            if (dgvDatos.CurrentRow == null || dgvDatos.CurrentRow.IsNewRow) return;

            try
            {
                // Asignar valores a los controles
                txtID.Text = dgvDatos.CurrentRow.Cells["IdCliente"].Value?.ToString();
                // obtener membresia
                cmbMembresia.Text = ObtenerMembresia()?.ToString();
                cmbUsuario.Text = ObtenerUsuario()?.ToString();

                txtDireccion.Text = dgvDatos.CurrentRow.Cells["Direccion"].Value?.ToString();
                dtpExpiracion.Text = dgvDatos.CurrentRow.Cells["FechaExpiracion"].Value?.ToString();

            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar datos del usuario: {ex.Message}", "Error",
                              MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private string ObtenerMembresia()
        {
            try
            {
                Controlador_Clientes.IdCliente = Convert.ToInt16(txtID.Text);
                string Membresia = Controlador_Clientes.ObtenerMembresia();
                return Membresia;
            }
            catch { return null; }
        }

        private string ObtenerUsuario()
        {
            try
            {
                Controlador_Clientes.IdCliente = Convert.ToInt16(txtID.Text);
                string UsuarioCompleto = Controlador_Clientes.ObtenerUsuario();
                return UsuarioCompleto;
            }
            catch { return null; }
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            Limpiar();
        }
    }
}
