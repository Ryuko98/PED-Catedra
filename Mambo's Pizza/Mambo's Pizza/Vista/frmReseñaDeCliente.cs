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
    public partial class frmReseñaDeCliente : Form
    {
        mensajes msg = new mensajes();
        int id_Repartidor = 0;
        int id_Pedido = 0;
        Controlador_Reseñas objReseña;
        public frmReseñaDeCliente()
        {
            InitializeComponent();
            id_Repartidor = Controlador_Pedidos.IdRepartidor;
            id_Pedido = Controlador_Pedidos.IdPedido;
        }

        private void btnEnviar_Click(object sender, EventArgs e)
        {
            int calificacion = Convert.ToInt32(txtCalificacion.Text);
            if (string.IsNullOrWhiteSpace(txtComentario.Text) ||
                string.IsNullOrWhiteSpace(txtCalificacion.Text))
            {
                MessageBox.Show("Llenar todos los campos");
                return;
            }
            if (calificacion < 1 || calificacion > 5)
            {
                MessageBox.Show("Ingresa una calificacion dentro del rango estimado");
                return;
            }

            try
            {
                int idRepartidor, idPedido, Calificacion;
                string Comentario;
                DateTime FechaReview;
                //Asignación de valores desde los controles
                idRepartidor = id_Repartidor;
                idPedido = id_Pedido;
                Calificacion = Convert.ToInt32(txtCalificacion.Text);
                // HoraEntrega (puede ser nula)
                Comentario = txtComentario.Text;
                FechaReview = DateTime.Now;
                objReseña = new Controlador_Reseñas(idRepartidor, idPedido, Calificacion, Comentario, FechaReview);
                // Llamada al modelo para insertar
                bool resultado = objReseña.InsertarReseña();

                if (resultado == true)
                {
                    Controlador_Pedidos objPedido = new Controlador_Pedidos();
                    bool resultado2 = objPedido.ActualizarEstadoCalificado();
                    if (resultado2 == true)
                    {
                        MessageBox.Show("Reseña Agregada exitosamente","Exito",MessageBoxButtons.OK,MessageBoxIcon.Information);

                        frmVistaClientes frm = new frmVistaClientes();
                        frm.Show();
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("Error al registrar la reseña","Aviso",MessageBoxButtons.OK,MessageBoxIcon.Warning);
                    }
                }
                else
                {
                    MessageBox.Show("hubo un error al crear la reseña");
                }
            }
            catch (FormatException)
            {
                msg.errorInsercion("Formato incorrecto en los datos", "Pedido");
            }
            catch (SqlException sqlEx)
            {
                msg.errorInsercion(sqlEx.Message, "Pedido");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error crítico: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
