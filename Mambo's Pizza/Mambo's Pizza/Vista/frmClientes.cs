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

        List<KeyValuePair<int, string>> listaUsuarios = Controlador_Clientes.CargarUsuariosClientes();
        List<KeyValuePair<int, string>> listaMembresias = Controlador_Clientes.CargarMembresiaCliente();
        public frmClientes()
        {
            InitializeComponent();
        }
        public Controlador_Clientes objClientes;

        public void RefrescarPantalla()
        {
            dgvDatos.DataSource = Controlador_Clientes.ObtenerClientes();
        }

        private void Limpiar()
        {
            txtID.Clear();
            cmbUsuario.SelectedIndex = -1;
            cmbMembresia.SelectedIndex = -1;
            txtDireccion.Clear();
            dtpExpiracion.Text = "";
            dgvDatos.ClearSelection();
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
            // Validación de campos vacíos
            if (txtDireccion.Text == "" || cmbUsuario.SelectedIndex == -1 || cmbMembresia.SelectedIndex == -1 ||
                dtpExpiracion.Text == "")
            {
                msg.camposVacios();
                return;
            }

            try
            {
                int idUsuario, idMembresia;
                string direccion;
                DateTime fechaExp;
                idUsuario = (int)cmbUsuario.SelectedValue;
                idMembresia = (int)cmbMembresia.SelectedValue;
                direccion = txtDireccion.Text;
                fechaExp = dtpExpiracion.Value;

                objClientes = new Controlador_Clientes(idUsuario, direccion, idMembresia, fechaExp);
                bool resultado = objClientes.InsertarClientes();

                if (resultado == true)
                {
                    Limpiar();
                    RefrescarPantalla();
                }
                else
                {
                    msg.errorEliminacion("No se pudo agregar", "Tabla: Clientes");
                }
            }
            catch (FormatException)
            {
                msg.errorInsercion("Formato incorrecto en los datos", "Clientes");
            }
            catch (SqlException sqlEx)
            {
                msg.errorInsercion(sqlEx.Message, "Clientes");
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
            // Validación de campos vacíos
            if (txtDireccion.Text == "" || cmbUsuario.SelectedIndex == -1 || cmbMembresia.SelectedIndex == -1 ||
                dtpExpiracion.Text == "")
            {
                msg.camposVacios();
                return;
            }

            try
            {
                int idUsuario, idMembresia;
                string direccion;
                DateTime fechaExp;
                idUsuario = (int)cmbUsuario.SelectedValue;
                idMembresia = (int)cmbMembresia.SelectedValue;
                direccion = txtDireccion.Text;
                fechaExp = dtpExpiracion.Value;

                Controlador_Clientes.IdCliente = Convert.ToInt16(txtID.Text);
                objClientes = new Controlador_Clientes(idUsuario, direccion, idMembresia, fechaExp);

                //Llamar al controlador para actualizar

                bool resultado = objClientes.ActualizarClientes();

                if (resultado == true)
                {
                    Limpiar();
                    RefrescarPantalla();
                }
                else
                {
                    msg.errorEliminacion("No se pudo actualizar", "Tabla: Clientes");
                }
            }
            catch (FormatException)
            {
                msg.errorActualizacion("Formato de datos incorrecto", "Tabla: Clientes");
            }
            catch (SqlException sqlEx)
            {
                msg.errorActualizacion(sqlEx.Message, "Tabla: Clientes");
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
            if (msg.confirmarEliminacion("Tabla: Clientes") == DialogResult.Yes)
            {
                try
                {
                    // Obtener el ID del usuario seleccionado
                    Controlador_Clientes.IdCliente = Convert.ToInt32(txtID.Text);

                    // Llamar al controlador para eliminar

                    bool resultado = Controlador_Clientes.EliminarClientes();


                    if (resultado == true)
                    {
                        Limpiar();
                        RefrescarPantalla();
                    }
                    else
                    {
                        msg.errorEliminacion("No se pudo eliminar el cliente", "Tabla: Clientes");
                    }

                }
                catch (FormatException)
                {
                    msg.errorEliminacion("ID de usuario no válido", "Tabla: Clientes");
                }
                catch (SqlException sqlEx)
                {
                    msg.errorEliminacion(sqlEx.Message, "Tabla: Clientes");
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
