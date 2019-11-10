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
using System.Collections;
using FrbaOfertas.Conexion;

namespace FrbaOfertas.AbmCliente
{
    public partial class AltaCliente : Form
    {
        private List<TextBox> camposObligatorios = new List<TextBox>();

        public AltaCliente()
        {
            InitializeComponent();
            camposObligatorios.Add(txtApellido);
            camposObligatorios.Add(txtNombre);
            camposObligatorios.Add(txtDni);
            camposObligatorios.Add(txtEmail);
            camposObligatorios.Add(txtFechaDeNacimiento);
            camposObligatorios.Add(txtLocalidad);
            camposObligatorios.Add(txtCalle);
            camposObligatorios.Add(txtCp);
        }
        private void AltaCliente_Load(object sender, EventArgs e)
        {

        }
        SqlConnection con = Conexion.Conexion.getConexion();
        private void btnCrearCliente_Click(object sender, EventArgs e)
        {
            if (esValido())
            {
                
                SqlCommand cmd = new SqlCommand("INSERT INTO Clientes VALUES (@dni,@nom,@ap,@fecha,@loc,@cp,@tel,@email,@calle,@piso,@depto)", con);
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("@dni",txtDni.Text);
                cmd.Parameters.AddWithValue("@nom", txtNombre.Text);
                cmd.Parameters.AddWithValue("@ap", txtApellido.Text);
                cmd.Parameters.AddWithValue("@fecha", txtFechaDeNacimiento.Text);
                cmd.Parameters.AddWithValue("@loc", txtLocalidad.Text);
                cmd.Parameters.AddWithValue("@cp", txtCp.Text);
                cmd.Parameters.AddWithValue("@tel", txtTelefono.Text);
                cmd.Parameters.AddWithValue("@email", txtEmail.Text);
                cmd.Parameters.AddWithValue("@calle", txtCalle.Text);
                cmd.Parameters.AddWithValue("@piso", txtPiso.Text);
                cmd.Parameters.AddWithValue("@depto", txtDepto.Text);

                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();

                MessageBox.Show("Cliente guardado exitosamente!","Saved",MessageBoxButtons.OK,MessageBoxIcon.Information);
            }
        }

        private bool esValido()
        {
            bool flag=true;
            if (camposObligatorios.Exists(campo => campo.Text == string.Empty))
            {
                flag = false;
                List<TextBox> camposSinLlennar = camposObligatorios.Where(campo => campo.Text == string.Empty).ToList();
                MessageBox.Show("Falta llenar campos: " + camposSinLlennar.Aggregate("",(s,next)=> s+next.Name.TrimStart('t','x','t')+" , ").TrimEnd(','), "Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            return flag;

        }

    }
}
