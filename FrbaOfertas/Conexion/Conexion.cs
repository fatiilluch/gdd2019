using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace FrbaOfertas.Conexion
{
    /*class Conexion
    {
        string cadena = "Data Source=DESKTOP-A4VN5NH\\SQLSERVER2012;Initial Catalog=GD2C2019;Integrated Security=True";
       
        SqlConnection conn; 

        public void abrir()
        {
            try
            {
                conn = new SqlConnection(cadena);
                conn.Open();
                Console.WriteLine("Conexion exitosa");
            }
            catch (Exception e)
            {
                Console.WriteLine("No se pudo conectar a la base de datos" + e.Message);
            }
        }
        
        public void cerrar()
        {
            conn.Close();
        }

        public void EjecutarSQL(String consulta)
        {
            SqlCommand com = new SqlCommand(consulta, conn);
            int filasAfectadas = com.ExecuteNonQuery();

            if (filasAfectadas > 0)
            {
                MessageBox.Show("Operación realizada correctamente", "La Base de Datos ha sido modificada", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("No se ha conectado a la base de datos", "Error en el sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void actualizar(DataGridView dg, String consulta)
        {
  
            this.abrir();
            System.Data.DataSet ds = new System.Data.DataSet();

            SqlDataAdapter da = new SqlDataAdapter(consulta, conn);


           // da.Fill(ds, <nombreDeLaTabla>);

            dg.DataSource = ds;
            dg.DataMember = "NOmbredelatabla";

            this.cerrar();
        
        }

    }
*/
}
