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
        //private static string configuracionConexionSQL = String.Format(@"Data Source={0}\SQLSERVER2012;Integrated Security=False;User ID=gdCupon2019;Password=gd2019;Connect Timeout=15;Encrypt=False;TrustServerCertificate=False", System.Security.Principal.WindowsIdentity.GetCurrent().Name);
        private static string configuracionConexionSQL = @"Data Source=localhost\SQLSERVER2012;Integrated Security=False;User ID=gdCupon2019;Password=gd2019;Connect Timeout=15;Encrypt=False;TrustServerCertificate=False";

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

        public static int ejecutarProcedure(SqlCommand cmd)
        {
            cmd.Connection = getCon();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@returned", SqlDbType.SmallInt).Direction = ParameterDirection.ReturnValue;

            con.Open();
            cmd.ExecuteNonQuery();
            int i = (int)cmd.Parameters["@returned"].Value;
            con.Close();
            return i;
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
        public static void verificarClientesDuplicados(String dni)
        {
            SqlCommand cmd = new SqlCommand("cliente_existente");
            cmd.Parameters.Add("@dni", SqlDbType.NVarChar, 18).Value = dni;

            int i = Utilidades.ejecutarProcedure(cmd);
            if (i < 0) { throw new ClienteDuplicadoException(); }
        }
        public static void verificarUsuarioPorRolExistente(int rol_id, String username)
        {
            SqlCommand cmd = new SqlCommand("usuario_con_rol_existente");
            cmd.Parameters.Add("@rol_id", SqlDbType.SmallInt).Value = rol_id;
            cmd.Parameters.Add("@username", SqlDbType.NVarChar).Value = username;

            int i = Utilidades.ejecutarProcedure(cmd);
            if (i < 0) { throw new ClienteDuplicadoException(); }
        }

    }
    public class ClienteDuplicadoException : Exception
    {
        public ClienteDuplicadoException() { }
        public void mensaje()
        {
            MessageBox.Show("Ya existe un cliente con ese DNI!","Failed",MessageBoxButtons.OK,MessageBoxIcon.Error);
        }

    }
    public class UsuarioConRolExistenteException : Exception
    {
        public UsuarioConRolExistenteException() { }
        public void mensaje()
        {
            MessageBox.Show("Ya existe un usuario con ese rol!", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

    }
}


