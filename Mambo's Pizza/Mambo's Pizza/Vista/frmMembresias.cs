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

        }
    }
}
