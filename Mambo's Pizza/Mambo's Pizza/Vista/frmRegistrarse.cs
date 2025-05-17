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
        public frmRegistrarse()
        {
            InitializeComponent();
        }

        private void btnInsertar_Click(object sender, EventArgs e)
        {
            string nombre, apellido, correo, usuario, contraseña, rol;
            DateTime fechaNacimiento;

            nombre = txtNombre.Text;
            apellido = txtApellido.Text;
            fechaNacimiento = dtpExpiracion.Value;
            correo = txtCorreo.Text;
            usuario = txtUsuario.Text;
            contraseña = txtContraseña.Text;
            rol = "cliente";

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
                bool respuesta = objRegistro.Registro();
                if (respuesta == true)
                {
                    MessageBox.Show("Usuario creado con exito","Exito",MessageBoxButtons.OK,MessageBoxIcon.Information);
                    MessageBox.Show("Te redirijiremos a la ventana de inicio de sesion","",MessageBoxButtons.OK,MessageBoxIcon.Information);
                    //frmInicioDeSesion frm = new frmInicioDeSesion();
                    //frm.Show();
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
    }
}
