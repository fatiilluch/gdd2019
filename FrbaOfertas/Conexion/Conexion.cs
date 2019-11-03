using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace FrbaOfertas.Conexion
{
    class conexion
    {
        string cadena = "Data Source=DESKTOP-A4VN5NH\\SQLSERVER2012;Initial Catalog=GD2C2019;Integrated Security=False;User ID=gdCupon2019;Password=********;Connect Timeout=15;Encrypt=False;TrustServerCertificate=False";
        public SqlConnection conectarBd = new SqlConnection();

        public conexion()
        {
            conectarBd.ConnectionString = cadena;
        }

        public void abrir()
        {
            try
            {
                conectarBd.Open();
                Console.WriteLine("Conexion existosa");
            }
            catch (Exception e)
            {
                Console.WriteLine("No se pudo conectar a la base de datos" + e.Message);
            }
        }
        
        public void cerrar()
        {
            conectarBd.Close();
        }
    }
}
