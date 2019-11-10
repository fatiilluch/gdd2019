using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;


namespace FrbaOfertas.AbmCliente
{
    public partial class AltaCliente : Form
    {
        public AltaCliente()
        {
            InitializeComponent();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void AltaCliente_Load(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void btnCrearCliente_Click(object sender, EventArgs e)
        {
            if (isValid())
            {
                   
            }
        }

        private bool esValido()
        {
            if(1==0)
            {
                MessageBox.Show("Faltan");
                    return false;
            }
            return true;
        }

    }
}
