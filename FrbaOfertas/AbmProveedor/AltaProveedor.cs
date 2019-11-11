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
using FrbaOfertas.Conexion;
using Utilidades;
namespace FrbaOfertas.AbmProveedor
{
    public partial class AltaProveedor : Form
    {
        SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-HANM39O\SQLSERVER2012;Initial Catalog=GD2C2019;Integrated Security=True");

        public AltaProveedor()
        {
            InitializeComponent();
        }

        private void btnCrearProveedor_Click(object sender, EventArgs e)
        {
        }
    }
}
