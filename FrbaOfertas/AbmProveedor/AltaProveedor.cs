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
        private Usuario us;
        public  AltaProveedor(Usuario user,Form v)
        {
            InitializeComponent();
            inicializarCamposObligatorios();
            ventanaAnterior = v;
            us = user;
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
                SqlCommand cmd1 = new SqlCommand("Insert into Usuarios (nombre_usuario,password) values (@name,@pass)", Utilidades.Utilidades.getCon());
                cmd1.Parameters.AddWithValue("@name", us.getNombreUsuario());
                String hash = Utilidades.Utilidades.obtenerHash(us.getPass());
                cmd1.Parameters.AddWithValue("@pass", hash);

                Utilidades.Utilidades.ejecutar(cmd1);

                SqlCommand cmd2 = new SqlCommand("INSERT INTO Proveedores VALUES (@rs,@email,@telefono,@ciudad,@cuit,@rubro_id,@prov_nom,@calle,@piso,@depto,@nombre_usuario)", Utilidades.Utilidades.getCon());

                cmd2.Parameters.AddWithValue("@rs", txtRs.Text);
                cmd2.Parameters.AddWithValue("@email", txtEmail.Text);
                cmd2.Parameters.AddWithValue("@telefono", txtTelefono.Text);
                cmd2.Parameters.AddWithValue("@ciudad", txtLocalidad.Text);
                cmd2.Parameters.AddWithValue("@cuit", txtCuit.Text);
                cmd2.Parameters.AddWithValue("@rubro_id", txtRubro.Text);
                cmd2.Parameters.AddWithValue("@prov_nom", txtContacto.Text);
                cmd2.Parameters.AddWithValue("@calle", txtCalle.Text);
                cmd2.Parameters.AddWithValue("@piso", txtCalle.Text);
                cmd2.Parameters.AddWithValue("@depto", txtPiso.Text);
                cmd2.Parameters.AddWithValue("@nombre_usuario", us.getNombreUsuario());

                Utilidades.Utilidades.ejecutar(cmd2);
                MessageBox.Show("Proveedor guardado exitosamente!", "Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
