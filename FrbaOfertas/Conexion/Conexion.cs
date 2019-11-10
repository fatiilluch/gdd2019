using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.IO;
using System.Security.Cryptography;
using System.Collections;
using System.Configuration;
using System.Data.SqlTypes;
using System.Data;
using FrbaOfertas;

namespace FrbaOfertas.Conexion
{
    public class Conexion
    {
        SqlCommand command;

        private static string configuracionConexionSQL = @"Data Source= \\SQLSERVER2012;Initial Catalog=GD2C2019; Persist Security Info=True;User ID= gdCupon2019 ;PASSWORD= gd2019";

        /*static string server = ConfigurationManager.AppSettings["server"].ToString();
        static string user = ConfigurationManager.AppSettings["user"].ToString();
        static string password = ConfigurationManager.AppSettings["password"].ToString();
        */
        // declaro una variable de conexion global
        //public static SqlConnection conexion = new SqlConnection("Data Source=DESKTOP-A4VN5NH\\SQLSERVER2012;Initial Catalog = GD2C2019; Integrated Security=True;User ID=gdCupon2019;Password=********;Connect Timeout=15;Encrypt=False;TrustServerCertificate=False");
        private static SqlConnection conexion = new SqlConnection(configuracionConexionSQL);

        public string getConfig()
        {
            return configuracionConexionSQL;
        }
        public static SqlConnection getConexion()
        {
            return conexion;
        }

        public static void Conectar()
        {
            try
            {
                conexion.Open();
            }
            catch (Exception error)
            {
                MessageBox.Show("No se pudo establecer la conexion a la base de datos" + error.Message);
            }
        }

        public static void Desconectar()
        {
            conexion.Close();
        }

        public static void ejecutarConsulta(string consulta)
        {
            SqlCommand query = new SqlCommand(consulta, conexion);
            Conectar();
            query.ExecuteNonQuery();
            Desconectar();
        }

        public int ejecutarConsultaSinResultado(SqlCommand consulta)
        {
            Conectar();
            int resultado = consulta.ExecuteNonQuery();
            Desconectar();
            return resultado;
        }

        public int ejecutarConsultaDevuelveInt(SqlCommand consulta)
        {
            Conectar();
            int resultado = consulta.ExecuteNonQuery();
            Desconectar();
            return resultado;
        }

        public int obtenerIntDeConsulta(string consulta)
        {
            SqlCommand query = new SqlCommand(consulta, conexion);
            int entero = 0;
            Conectar();
            entero = query.ExecuteNonQuery();
            Desconectar();
            return entero;
        }

        public DataSet obtenerDataSet(SqlCommand consulta)
        {
            DataSet dataSet = new DataSet();
            SqlDataAdapter dataAdapter = new SqlDataAdapter(consulta);
            dataAdapter.Fill(dataSet);
            return dataSet;
        }

        public DataTable obtenerDataTable(SqlCommand consulta)
        {
            DataSet dataSet = obtenerDataSet(consulta);
            DataTable tabla = dataSet.Tables[0];
            return tabla;
        }

        public List<string> obtenerListaDeDatos(SqlCommand consulta)
        {
            DataTable tabla = obtenerDataTable(consulta);
            List<string> columna = new List<string>();
            if (tabla.Rows.Count > 0)
                foreach (DataRow fila in tabla.Rows)
                    columna.Add(fila[0].ToString());
            return columna;
        }


        public void crearSP(string nombreConsulta)
        {

            SqlCommand sp = new SqlCommand(nombreConsulta, conexion);
            sp.CommandType = CommandType.StoredProcedure;
        }


        public void setearParametroPorValor(string nombre, object valor)
        {
            command.Parameters.AddWithValue(nombre, valor);
        }

        public void setearParametroPorReferencia(string nombre, SqlDbType tipoDato)
        {
            command.Parameters.Add(new SqlParameter(nombre, tipoDato));
            command.Parameters[nombre].Direction = ParameterDirection.Output;
        }

        public int ejecutarSP()
        {
            try
            {
                command.Parameters.Add("@ReturnVal", SqlDbType.Int);
                command.Parameters["@ReturnVal"].Direction = ParameterDirection.ReturnValue;
                command.ExecuteNonQuery();
                return Convert.ToInt32(command.Parameters["@ReturnVal"].Value);

            }
            catch (Exception exception)
            {
                MessageBox.Show("No se pudo establecer la conexion a la base de datos" + exception.Message);
                return -1;
            }
        }
    }
}