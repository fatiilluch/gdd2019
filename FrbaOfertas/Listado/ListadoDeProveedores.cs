using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FrbaOfertas.Listado
{
    public partial class ListadoDeProveedores : Form
    {
        private TextBox origen;
        public ListadoDeProveedores(TextBox txt)
        {
            InitializeComponent();
            origen = txt;
        }

        private void btnSeleccionar_Click(object sender, EventArgs e)
        {
            //origen=dataGridView1.sele
            this.Close();

        }
    }
}
