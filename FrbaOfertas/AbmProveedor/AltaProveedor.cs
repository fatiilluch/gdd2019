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
using FrbaOfertas.Registro_de_usuario;
namespace FrbaOfertas.AbmProveedor
{
    public partial class AltaProveedor : AltaForm
    {
        private Usuario infoUsuario;
        public  AltaProveedor(Usuario user,Form v)
        {
            InitializeComponent();
            inicializarCamposObligatorios();
            ventanaAnterior = v;
            infoUsuario = user;
        }
        
        protected override void inicializarCamposObligatorios()
        {
            camposObligatorios.Add(txtRs);
            camposObligatorios.Add(txtCuit);
            camposObligatorios.Add(txtRubro);
            camposObligatorios.Add(txtEmail);
            camposObligatorios.Add(txtTelefono);
            camposObligatorios.Add(txtLocalidad);
            camposObligatorios.Add(txtCalle);
            camposObligatorios.Add(txtCp);
            camposObligatorios.Add(txtContacto);
        }
        private void btnCrear_Click(object sender, EventArgs e)
        {
            if (camposObligatoriosCompletados())
            {

                SqlCommand cmd = new SqlCommand("INSERT INTO Proveedores VALUES (@rs,@email,@telefono,@ciudad,@cuit,@rubro_id,@prov_nom,@calle,@piso,@depto,@nombre_usuario)", Utilidades.Utilidades.getCon());
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("@rs", txtRs.Text);
                cmd.Parameters.AddWithValue("@email", txtEmail.Text);
                cmd.Parameters.AddWithValue("@telefono", txtTelefono.Text);
                cmd.Parameters.AddWithValue("@ciudad", txtLocalidad.Text);
                cmd.Parameters.AddWithValue("@cuit", txtCuit.Text);
                cmd.Parameters.AddWithValue("@rubro_id", txtRubro.Text);
                cmd.Parameters.AddWithValue("@prov_nom", txtContacto.Text);
                cmd.Parameters.AddWithValue("@calle", txtCalle.Text);
                cmd.Parameters.AddWithValue("@piso", txtCalle.Text);
                cmd.Parameters.AddWithValue("@depto", txtPiso.Text);
                cmd.Parameters.AddWithValue("@nombre_usuario", txtDepto.Text);//me lo traigo del formulario anterior

                Utilidades.Utilidades.ejecutar(cmd);
                MessageBox.Show("Proveedor guardado exitosamente!", "Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
