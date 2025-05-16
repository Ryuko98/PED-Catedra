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
    public partial class frmMenu : Form
    {
        mensajes msg = new mensajes();
        public frmMenu()
        {
            InitializeComponent();
        }
        public Controlador_Menus objMenus;

        public void RefrescarPantalla()
        {
            dgvDatos.DataSource = Controlador_Menus.ObtenerMenus();
        }

        private void Limpiar()
        {
            txtID.Clear();
            txtNombre.Clear();
            txtDescripcion.Clear();
            txtPrecioUnitario.Clear();
        }

        private void frmMenu_Load(object sender, EventArgs e)
        {
            RefrescarPantalla();
            txtID.Enabled = false;

            dgvDatos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void btnInsertar_Click(object sender, EventArgs e)
        {
            //validar
            if (txtNombre.Text == "" || txtDescripcion.Text == "" || txtPrecioUnitario.Text == "")
            {
                msg.camposVacios();
                return;
            }

            try
            {
                string nombre, descripcion;
                float precio;

                nombre = txtNombre.Text;
                precio = float.Parse(txtPrecioUnitario.Text);
                descripcion = txtDescripcion.Text;

                objMenus = new Controlador_Menus(nombre, precio, descripcion);

                if (NombreValido(nombre))
                {
                    msg.errorInsercion("El nombre ingresado ya existe en el menú", "Menus");
                    return;
                }

                bool result = objMenus.InsertarMenus();

                if (result)
                {
                    Limpiar();
                    RefrescarPantalla();
                }
                else
                {
                    msg.errorEliminacion("No se pudo agregar", "Tabla: Menus");
                }
            }
            catch (FormatException)
            {
                msg.errorInsercion("Formato incorrecto en los datos", "Menus");
            }
            catch (SqlException sqlEx)
            {
                msg.errorInsercion(sqlEx.Message, "Menus");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error crítico: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private bool NombreValido(string nombreMenu)
        {
            foreach (DataGridViewRow fila in dgvDatos.Rows)
            {
                if (!fila.IsNewRow)
                {
                    string nombre = fila.Cells["Nombre de Menu"].Value?.ToString();
                    if (nombre == nombreMenu)
                    {
                        return true;
                    }
                }
            }
            return false;
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
            if (txtNombre.Text == "" || txtPrecioUnitario.Text == "" || txtDescripcion.Text == "")
            {
                msg.camposVacios();
                return;
            }

            try
            {
                string nombre, descripcion;
                float precio;
                nombre = txtNombre.Text;
                descripcion = txtDescripcion.Text;
                precio = float.Parse(txtPrecioUnitario.Text);
                Controlador_Menus.IdMenu = Convert.ToInt16(txtID.Text);
                objMenus = new Controlador_Menus(nombre, precio, descripcion);


                //Llamar al controlador para actualizar

                bool resultado = objMenus.ActualizarMenus();

                if (resultado == true)
                {
                    Limpiar();
                    RefrescarPantalla();
                }
                else
                {
                    msg.errorEliminacion("No se actualizar", "Tabla: Menus");
                }
            }
            catch (FormatException)
            {
                msg.errorActualizacion("Formato de datos incorrecto", "Tabla: Menus");
            }
            catch (SqlException sqlEx)
            {
                msg.errorActualizacion(sqlEx.Message, "Tabla: Menus");
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
            if (msg.confirmarEliminacion("Tabla: Menus") == DialogResult.Yes)
            {
                try
                {
                    // Obtener el ID del usuario seleccionado
                    Controlador_Menus.IdMenu = Convert.ToInt16(txtID.Text);

                    // Llamar al controlador para eliminar

                    bool resultado = Controlador_Menus.EliminarMenus();


                    if (resultado == true)
                    {
                        Limpiar();
                        RefrescarPantalla();
                    }
                    else
                    {
                        msg.errorEliminacion("No se pudo eliminar la opcion", "Tabla: Menus");
                    }
                }
                catch (FormatException)
                {
                    msg.errorEliminacion("ID de opcion no válida", "Tabla: Menus");
                }
                catch (SqlException sqlEx)
                {
                    msg.errorEliminacion(sqlEx.Message, "Tabla: Menus");
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
                txtID.Text = dgvDatos.CurrentRow.Cells["IdMenu"].Value?.ToString();
                txtNombre.Text = dgvDatos.CurrentRow.Cells["Nombre de Menu"].Value?.ToString();
                txtPrecioUnitario.Text = dgvDatos.CurrentRow.Cells["Precio"].Value?.ToString();
                txtDescripcion.Text = dgvDatos.CurrentRow.Cells["Descripción"].Value?.ToString();

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
