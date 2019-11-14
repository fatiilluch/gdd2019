using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Security.Cryptography;
using System.Drawing;
using System.Windows.Forms;


namespace Utilidades
{
    public class Utilidades
    {
        //Data Source= \\SQLSERVER2012;Initial Catalog=GD2C2019; Persist Security Info=True;User ID= gdCupon2019 ;PASSWORD= gd2019
        private static string configuracionConexionSQL = @"Data Source=DESKTOP-HANM39O\SQLSERVER2012;Initial Catalog=GD2C2019;Integrated Security=True";//Con esto me funciona la conexion.
        private static SqlConnection con = new SqlConnection(configuracionConexionSQL);
        private static int cantidadDeIntentos = 3;

        public static int getCantidadDeIntentos() { return cantidadDeIntentos; }
        public static SqlConnection getCon() { return con; }
        public static DataSet ejecutarConsulta(String query)
        {
            con.Open();

            DataSet ds = new DataSet();
            SqlDataAdapter adapter = new SqlDataAdapter(query, con);

            adapter.Fill(ds);
            con.Close();
            return ds;
        }
        public static DataSet ejecutarConsulta(SqlCommand query)
        {
            con.Open();

            DataSet ds = new DataSet();
            SqlDataAdapter adapter = new SqlDataAdapter(query.CommandText, con);

            adapter.Fill(ds);
            con.Close();
            return ds;
        }
        public static int filasAfectadasPorQuery(String query)
        {
            SqlCommand cmd = new SqlCommand(query, con);
            con.Open();
            int filasAfectadas = cmd.ExecuteNonQuery();
            con.Close();
            return filasAfectadas;
        }

        public static void ejecutar(String query)
        {
            SqlCommand cmd = new SqlCommand(query, con);
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
        }
        public static void ejecutar(SqlCommand cmd)
        {
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
        }
        public static void beginTransaction()
        {
            ejecutar("begin transaction");
        }
        public static void commit()
        {
            ejecutar("commit");
        }
        public static void rollback()
        {
            ejecutar("rollback");
        }


            
        public static String obtenerHash(String texto)
        {
            var passBytes = Encoding.ASCII.GetBytes(texto);
            var sha = new SHA256Managed();
            var hash = sha.ComputeHash(passBytes);

            return hash.Aggregate("", (b, next) => next.ToString("x2") + b);
        }
    }
    public class GestorDeErrores
    {
        public static void mostrarErrorSegunTipo(SqlException e)
        {
            switch (e.Number)
            {
                case 2601:
                case 2627:
                    MessageBox.Show("Esa instancia ya existe en la base de datos!", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    break;
            }

        }
    }
}


