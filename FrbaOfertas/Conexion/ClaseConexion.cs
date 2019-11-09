using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.IO;
using System.Collections;
using System.Configuration;

namespace FrbaOfertas.Conexion
{
    class ClaseConexion
    {
        static string server = ConfigurationManager.AppSettings["server"].ToString();
        static string user = ConfigurationManager.AppSettings["user"].ToString();
        static string password = ConfigurationManager.AppSettings["password"].ToString();

        // declaro una variable de conexion global
        //public static SqlConnection conexion = new SqlConnection("Data Source=DESKTOP-A4VN5NH\\SQLSERVER2012;Initial Catalog = GD2C2019; Integrated Security=True;User ID=gdCupon2019;Password=********;Connect Timeout=15;Encrypt=False;TrustServerCertificate=False");
        public static SqlConnection conexion = getConnection();

        public static void Conectar()
        {
            try
            {
                conexion.Open();
                MessageBox.Show("Se ha conectado OK");
            }
            catch (Exception error)
            {
                MessageBox.Show("No se pudo establecer la conexion a la base de datos" + error.Message);
            }
        }

        public static SqlDataReader ResolverConsulta(String query)
        {
            return new SqlCommand(query, conexion).ExecuteReader();
        }

        public static int ResolverNonQuery(String nonQuery)
        {
            return new SqlCommand(nonQuery, conexion).ExecuteNonQuery();
        }

        public static object ResolverFuncion(string query)
        {
            return new SqlCommand(query, conexion).ExecuteScalar();
        }

        public static void ActualizarGrid(DataGridView dg, String tabla, string consulta)
        {
            // instancio el dataset que va a llenar de datos el sdatadridview
            System.Data.DataSet ds = new System.Data.DataSet();
            // instancio un adaptador de datos entre el dataset y la base de datos
            SqlDataAdapter da = new SqlDataAdapter(consulta, conexion);
            // llenar el dataset con los datos de la tabla NN a través del adapter
            da.Fill(ds, tabla);
            dg.DataSource = ds;
            // para traer todo el contenido de la tabla NN al dataGridView
            dg.DataMember = tabla;
        }

        public static SqlConnection getConnection()
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = "Data Source=" + server + "\\SQLSERVER2012;Initial Catalog=GD2C2019; Persist Security Info=True;User ID=" + user + ";PASSWORD=" + password + ";";
            return con;
        }
    }
}
