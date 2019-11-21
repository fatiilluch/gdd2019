using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FrbaOfertas.AbmProveedor
{
    public partial class MenuAbmProveedor : Form
    {
        private Form origen;
        public MenuAbmProveedor(Form ventana)
        {
            InitializeComponent();
            origen = ventana;
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {

        }

        private void btnModificar_Click(object sender, EventArgs e)
        {

        }

        private void btnCargar_Click(object sender, EventArgs e)
        {

        }

        private void MenuAbmProveedor_FormClosed(object sender, FormClosedEventArgs e)
        {
            origen.Show();
        }
    }
}
