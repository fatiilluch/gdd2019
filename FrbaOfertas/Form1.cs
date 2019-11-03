using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient; //es para hacer la conexion

namespace FrbaOfertas
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnConectar_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection con = new SqlConnection("Data Source=DESKTOP-A4VN5NH\\SQLSERVER2012;Integrated Security=True;");
                con.Open();
                MessageBox.Show("Se ha conectado");
            }
            catch (Exception error)
            {
                MessageBox.Show("Ha ocurrido un error" + error);
            }
        }
    }
}
