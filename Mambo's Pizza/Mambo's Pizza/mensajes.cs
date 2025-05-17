using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Mambo_s_Pizza
{
    class mensajes
    {

        // errores y advertencias
        public void camposVacios()
        {
            MessageBox.Show("Falta información. No puede ingresar campos vacíos", "Campos vacíos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        public void formularioNoCarga()
        {
            MessageBox.Show("No se pudo cargar el formulario seleccionado, vuelva a intentar o solicite asistencia", "Formulario", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        // mantenimientos fallidos
        public void errorInsercion(string ex, string tabla)
        {
            MessageBox.Show("Error al momento de crear un registro. " + ex, tabla + "Error de inserción", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        public void errorInicioSesion(string accion)
        {
            MessageBox.Show("Credenciales incorrectas " + accion, "Error de inicio de sesion", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        public void errorActualizacion(string ex, string tabla)
        {
            MessageBox.Show("Error al momento de actualizar el registro. " + ex, tabla + "Error de actualización", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        public void errorEliminacion(string ex, string tabla)
        {
            MessageBox.Show("Error al momento de eliminar el registro. " + ex, tabla + "Error de eliminación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        public void seleccionarRegistro(string accion)
        {
            MessageBox.Show("Debe seleccionar un registro para " + accion, "Falta información", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        public void fechaInvalida(string tabla)
        {
            MessageBox.Show("Debe ingresar una fecha válida", tabla + "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }


        public DialogResult confirmarEliminacion(string tabla)
        {
            if (MessageBox.Show("¿Quiere eliminar el registro seleccionado?", tabla + "Eliminar un registro", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
            {
                return DialogResult.Yes;
            }
            else
            {
                return DialogResult.No;
            }
        }

        // mantenimientos exitosos
        public void exitoInsercion(string tabla)
        {
            MessageBox.Show("El registro se ha creado correctamente", tabla + "Éxito en incersión", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        public void exitoActualizacion(string tabla)
        {
            MessageBox.Show("El registro seleccionado se ha actualizado exitosamente", tabla + "Éxito en actualización", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        public void exitoEliminacion(string tabla)
        {
            MessageBox.Show("El registro seleccionado se ha eliminado correctamente", tabla + "Éxito en eliminación", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        public void exitoInicioSesion()
        {
            MessageBox.Show("Credenciales correctas", "Exito de inicio de sesión", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
