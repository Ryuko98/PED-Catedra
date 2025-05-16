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
    public partial class frmUsuarios : Form
    {
        mensajes msg = new mensajes();
        public frmUsuarios()
        {
            InitializeComponent();
        }
        public Controlador_Usuarios objUsuario;

        public void RefrescarPantalla()
        {
            dgvDatos.DataSource = Controlador_Usuarios.ObtenerUsuarios();
        }

        void limpiarCampos()
        {
            txtNombre.Clear();
            txtApellido.Clear();
            txtCorreo.Clear();
            txtUsuario.Clear();
            txtContraseña.Clear();
            txtRol.Clear();
        }

        private void frmUsuarios_Load(object sender, EventArgs e)   
        {
            RefrescarPantalla();
            txtID.Enabled = false;

            dgvDatos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void btnInsertar_Click(object sender, EventArgs e)
        {
            // Validación de campos vacíos
            if (txtNombre.Text == "" || txtApellido.Text == "" || txtUsuario.Text == "" ||
                txtContraseña.Text == "" || txtCorreo.Text == "" || txtRol.Text == "")
            {
                msg.camposVacios();
                return;
            }

            try
            {
                string nombre, apellido, correo, usuario, contraseña, rol;
                DateTime fechanacimiento;
                nombre = txtNombre.Text;
                apellido = txtApellido.Text;
                fechanacimiento = dtpExpiracion.Value;
                correo = txtCorreo.Text;
                usuario = txtUsuario.Text;
                contraseña = txtContraseña.Text;
                rol = txtRol.Text;
                objUsuario = new Controlador_Usuarios(nombre,apellido,fechanacimiento,correo,usuario,contraseña,rol);


                // Validación básica del rol
                if (!EsRolValido(rol))
                {
                    msg.errorInsercion("El rol especificado no es válido", "Usuario");
                    return;
                }

                bool resultado = objUsuario.InsertarUsuarios();


                if (resultado == true)
                {
                    msg.exitoInsercion("Usuario agregado correctamente");
                    limpiarCampos();
                    RefrescarPantalla();
                }
            }
            catch (FormatException)
            {
                msg.errorInsercion("Formato incorrecto en los datos", "Usuario");
            }
            catch (SqlException sqlEx)
            {
                msg.errorInsercion(sqlEx.Message, "Usuario");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error crítico: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private bool EsRolValido(string rol)
        {
            // Lista de roles permitidos - puedes personalizarla
            string[] rolesPermitidos = { "Administrador", "Repartidor", "Cliente" };
            return rolesPermitidos.Contains(rol);
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
            if (txtNombre.Text == "" || txtApellido.Text == "" || txtUsuario.Text == "" ||          
                txtContraseña.Text == "" || txtCorreo.Text == "" || txtRol.Text == "")
            {
                msg.camposVacios();
                return;
            }

            try
            {
                string nombre, apellido, correo, usuario, contraseña, rol;
                DateTime fechanacimiento;
                nombre = txtNombre.Text;
                apellido = txtApellido.Text;
                fechanacimiento = dtpExpiracion.Value;
                correo = txtCorreo.Text;
                usuario = txtUsuario.Text;
                contraseña = txtContraseña.Text;
                rol = txtRol.Text;
                Controlador_Usuarios.IdUsuario = Convert.ToInt16(txtID.Text);
                objUsuario = new Controlador_Usuarios(nombre, apellido, fechanacimiento, correo, usuario, contraseña, rol);


                //Llamar al controlador para actualizar

                bool resultado = objUsuario.ActualizarUsuarios();

                if (resultado == true)
                {
                    MessageBox.Show("Usuario Actualizado con exito","Exito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("No se pudo actualizar el usuario", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
            catch (FormatException)
            {
                msg.errorActualizacion("Formato de datos incorrecto", "Tabla: Usuarios");
            }
            catch (SqlException sqlEx)
            {
                msg.errorActualizacion(sqlEx.Message, "Tabla: Usuarios");
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
            if (msg.confirmarEliminacion("Tabla: Usuarios") == DialogResult.Yes)
            {
                try
                {
                    // Obtener el ID del usuario seleccionado
                    Controlador_Usuarios.IdUsuario = Convert.ToInt32(txtID.Text);

                    // Llamar al controlador para eliminar

                    bool resultado = Controlador_Usuarios.EliminarUsuarios();


                    if (resultado == true)
                    {
                        msg.exitoEliminacion("Usuario eliminado correctamente");
                    }
                    else
                    {
                        msg.errorEliminacion("No se pudo eliminar el usuario", "Tabla: Usuarios");
                    }
                }
                catch (FormatException)
                {
                    msg.errorEliminacion("ID de usuario no válido", "Tabla: Usuarios");
                }
                catch (SqlException sqlEx)
                {
                    msg.errorEliminacion(sqlEx.Message, "Tabla: Usuarios");
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
                // Asignar valores a los controles
                txtID.Text = dgvDatos.CurrentRow.Cells["IdUsuario"].Value?.ToString();
                txtNombre.Text = dgvDatos.CurrentRow.Cells["Nombre"].Value?.ToString();
                txtApellido.Text = dgvDatos.CurrentRow.Cells["Apellido"].Value?.ToString();
                txtUsuario.Text = dgvDatos.CurrentRow.Cells["Usuario"].Value?.ToString();
                txtCorreo.Text = dgvDatos.CurrentRow.Cells["Correo"].Value?.ToString();
                txtRol.Text = dgvDatos.CurrentRow.Cells["Rol"].Value?.ToString();
                txtContraseña.Text = dgvDatos.CurrentRow.Cells["Contraseña"].Value?.ToString();

                // Manejo seguro de fecha de nacimiento
                if (DateTime.TryParse(dgvDatos.CurrentRow.Cells["FechaNacimiento"].Value?.ToString(), out DateTime fechaNacimiento))
                {
                    dtpExpiracion.Value = fechaNacimiento;
                }
              
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar datos del usuario: {ex.Message}", "Error",
                              MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            limpiarCampos();
        }
    }
}
