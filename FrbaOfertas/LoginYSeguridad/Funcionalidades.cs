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
using System.Configuration;
using FrbaOfertas.Conexion;

namespace FrbaOfertas.LoginYSeguridad
{
    public partial class Funcionalidades : Form
    {
        private string rolSeleccionado;

        public Funcionalidades(string rolSelec)
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            this.rolSeleccionado = rolSelec;
            this.Llenar_Combobox_Funcionalidades();
            label2.Text = rolSeleccionado;  
            //ver si va lo del if
        }
        SqlConnection con = Conexion.Conexion.getConexion();
        private void Llenar_Combobox_Funcionalidades()
        {
            string query = "select b.DESCRIPCION_FUNC from RE_GDDIENTOS.[Funcionalidad x Rol] a JOIN RE_GDDIENTOS.Funcionalidad b ON a.FUNCIONALIDAD = b.FUNCIONALIDAD where NOMBRE_ROL = '" + this.rolSeleccionado + "'";
            SqlCommand cmd = new SqlCommand(query, con);
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                string a = reader.GetString(0);
                selectorFunc.Items.Add(a);
            }
            reader.Close();
        }

        private void Funcionalidades_Load(object sender, EventArgs e)
        {

        }

        private void btn_atras_Click(object sender, EventArgs e)
        {

        }

        private void selectorFunc_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
