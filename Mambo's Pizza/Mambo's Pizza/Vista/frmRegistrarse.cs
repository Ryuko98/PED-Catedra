using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Mambo_s_Pizza.Controlador;

namespace Mambo_s_Pizza.Vista
{
    public partial class frmRegistrarse : Form
    {
        Controlador_Usuarios objRegistro;
        Controlador_Clientes objCliente;
        public frmRegistrarse()
        {
            InitializeComponent();
        }

        private void btnInsertar_Click(object sender, EventArgs e)
        {
            string nombre, apellido, correo, usuario, contraseña, rol, direccion;
            DateTime fechaNacimiento, fechaExpiracion;
            int idMembresia, idUsuario;
            nombre = txtNombre.Text;
            apellido = txtApellido.Text;
            fechaNacimiento = dtpExpiracion.Value;
            fechaExpiracion = DateTime.Now;
            correo = txtCorreo.Text;
            usuario = txtUsuario.Text;
            contraseña = txtContraseña.Text;
            rol = "cliente";
            direccion = txtDireccion.Text;
            idMembresia = Convert.ToInt32(cmbMembresia.SelectedValue);

            objRegistro = new Controlador_Usuarios(nombre,apellido,fechaNacimiento,correo,usuario,contraseña,rol);
            if (txtNombre.Text.Trim() == "" || txtApellido.Text.Trim() == "" || txtCorreo.Text.Trim() == "" || txtUsuario.Text == "" || txtContraseña.Text == "" || txtRepetirContraseña.Text == "")
            {
                MessageBox.Show("LLenar todos los apartados", "Aviso",MessageBoxButtons.OK,MessageBoxIcon.Warning);
            }
            else if (txtContraseña.Text != txtRepetirContraseña.Text)
            {
                MessageBox.Show("Comprobar si las contraseñas son las mismas", "Aviso",MessageBoxButtons.OK,MessageBoxIcon.Warning);
            }
            else
            {
                objRegistro.Registro();
                List<string> datos = new List<string>();
                datos = Controlador_Usuarios.ObtenerIdUsuario();
                Controlador_Usuarios.IdUsuario = Convert.ToInt32(datos[0]);
                if (cmbMembresia.SelectedIndex == 0)
                {
                    fechaExpiracion = DateTime.Now.AddDays(0);
                }
                if (cmbMembresia.SelectedIndex == 1)
                {
                    fechaExpiracion = DateTime.Now.AddMonths(1);
                }
                if (cmbMembresia.SelectedIndex == 2)
                {
                    fechaExpiracion = DateTime.Now.AddMonths(1);
                }
                    objCliente = new Controlador_Clientes(Controlador_Usuarios.IdUsuario, direccion, idMembresia, fechaExpiracion);
                bool respuesta = objCliente.InsertarClientes();
                if (respuesta == true)
                {
                    MessageBox.Show("Te redirijiremos a la ventana de inicio de sesion","",MessageBoxButtons.OK,MessageBoxIcon.Information);
                    frmInicioDeSesion frm = new frmInicioDeSesion();
                    frm.Show();
                    this.Hide();
                }
            }
        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            frmInicioDeSesion frm = new frmInicioDeSesion();
            frm.Show();
            this.Hide();
        }

        private void frmRegistrarse_Load(object sender, EventArgs e)
        {
            cmbMembresia.DataSource = Controlador_Clientes.ObtenerMembresiaRegistro();
            cmbMembresia.DisplayMember = "Membresia";  // El nombre que se mostrará
            cmbMembresia.ValueMember = "Idmembresia";
        }
    }
}
