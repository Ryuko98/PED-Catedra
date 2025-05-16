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

        public void RefrescarPantalla()
        {
            dgvDatos.DataSource = Modelo_Usuarios.MostrarUsuarios();
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
                Controlador_Usuarios nuevoUsuario = new Controlador_Usuarios();
                nuevoUsuario.Nombre = txtNombre.Text;
                nuevoUsuario.Apellido = txtApellido.Text;
                nuevoUsuario.FechaNacimiento = dtpExpiracion.Value;
                nuevoUsuario.Correo = txtCorreo.Text;
                nuevoUsuario.Usuario = txtUsuario.Text;
                nuevoUsuario.Contraseña = txtContraseña.Text;
                nuevoUsuario.Rol = txtRol.Text;  // Usando el TextBox para el rol

                // Validación básica del rol
                if (!EsRolValido(nuevoUsuario.Rol))
                {
                    msg.errorInsercion("El rol especificado no es válido", "Usuario");
                    return;
                }

<<<<<<< Updated upstream
                int resultado = Modelo_Usuarios.AgregarUsuarios(nuevoUsuario);
=======
                //int resultado = Controlador_Usuarios.InsertarUsuarios(nuevoUsuario);
>>>>>>> Stashed changes

                //if (resultado > 0)
                //{
                //    msg.exitoInsercion("Usuario agregado correctamente");
                //    limpiarCampos();
                //    RefrescarPantalla();
                //}
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
                Controlador_Usuarios usuarioActualizado = new Controlador_Usuarios();
<<<<<<< Updated upstream
                usuarioActualizado.IdUsuario = Convert.ToInt32(txtID.Text);
=======
>>>>>>> Stashed changes
                usuarioActualizado.Nombre = txtNombre.Text;
                usuarioActualizado.Apellido = txtApellido.Text;
                usuarioActualizado.FechaNacimiento = dtpExpiracion.Value;
                usuarioActualizado.Correo = txtCorreo.Text;
                usuarioActualizado.Usuario = txtUsuario.Text;
                usuarioActualizado.Contraseña = txtContraseña.Text;
                usuarioActualizado.Rol = txtRol.Text;
                usuarioActualizado.IdUsuario = Convert.ToInt32(txtID.Text);


                // Llamar al controlador para actualizar
<<<<<<< Updated upstream
                int resultado = Modelo_Usuarios.ActualizarUsuario(usuarioActualizado);
=======
                //int resultado = Controlador_Usuarios.ActualizarUsuarios(usuarioActualizado);
>>>>>>> Stashed changes

                //if (resultado > 0)
                //{
                //    msg.exitoActualizacion("Usuario actualizado correctamente");
                //}
                //else
                //{
                //    msg.errorActualizacion("No se pudo actualizar el usuario", "Tabla: Usuarios");
                //}
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
                    int id = Convert.ToInt32(dgvDatos.CurrentRow.Cells["IdUsuario"].Value);

                    // Llamar al controlador para eliminar
<<<<<<< Updated upstream
                    int resultado = Modelo_Usuarios.EliminarUsuario(id);
=======
                    int resultado = Controlador_Usuarios.EliminarUsuarios(id);
>>>>>>> Stashed changes

                    if (resultado > 0)
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
