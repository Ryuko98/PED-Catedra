using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace proto
{
    public partial class frmProto : Form
    {
        Cola cola = new Cola();

        public frmProto()
        {
            InitializeComponent();
            cola.Mostrar(lbCola);
        }

        private void btnInsertar_Click(object sender, EventArgs e)
        {
            cola.Insertar(int.Parse(txtDato.Text));
            cola.Mostrar(lbCola);
        }

        private void btnDesencolar_Click(object sender, EventArgs e)
        {
            cola.DesencolarMax();
            cola.Mostrar(lbCola);
        }
    }
}
