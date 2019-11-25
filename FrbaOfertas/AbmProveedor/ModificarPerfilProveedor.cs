using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FrbaOfertas.Entidades;
using System.Data.SqlClient;
using Utilidades;
namespace FrbaOfertas.AbmProveedor
{
    public partial class ModificarPerfilProveedor : AltaProveedor
    {
        Usuario us = new Usuario();
        public ModificarPerfilProveedor()
        {
            InitializeComponent();
        }
        public ModificarPerfilProveedor(Proveedor proveedor,Form v)
        {
            InitializeComponent();
            ventanaAnterior = v;
            cargarCampos(proveedor);
            inicializarCamposObligatorios();
            us.setNombreUsuario(proveedor.Nombre_usuario);
        }
        protected override void inicializarCamposObligatorios()
        {
            camposObligatorios.Add(txtCiudad);
            camposObligatorios.Add(txtContacto);
            camposObligatorios.Add(txtCp);
            camposObligatorios.Add(txtCuit);
            camposObligatorios.Add(txtDireccion);
            camposObligatorios.Add(txtEmail);
            camposObligatorios.Add(txtRs);
            camposObligatorios.Add(txtRubro);
            camposObligatorios.Add(txtTelefono);
        }
        private void cargarCampos(Proveedor proveedor)
        {
            txtRs.Text = proveedor.Rs;
            txtCuit.Text = proveedor.Cuit;
            txtDireccion.Text = proveedor.Direccion;
            txtCp.Text = proveedor.Cp;
            txtEmail.Text = proveedor.Email;
            txtTelefono.Text = proveedor.Telefono;
            txtCiudad.Text = proveedor.Ciudad;
            txtPiso.Text = proveedor.Piso.ToString();
            txtDepto.Text = proveedor.Dpto.ToString();
            txtContacto.Text = proveedor.Contacto;
        }

        private new void btnCrear_Click(object sender, EventArgs e)
        {
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            try
            {
                Utilidades.GestorDeErrores.verificarCamposObligatoriosCompletos(camposObligatorios);
                String query = String.Format("update Proveedores set cuit=@cuit,nombre_contacto=@contacto,ciudad=@ciudad,codigo_postal=@codigo_postal,telefono=@telefono,email=@email,direccion=@direccion,piso=@piso,dpto=@depto where nombre_usuario='{0}'",us.getNombreUsuario());
                SqlCommand cmd = new SqlCommand(query);
                cargarCmd(cmd);
                Utilidades.Utilidades.ejecutar(cmd);
                MessageBox.Show("Cliente actualizado con éxito!", "Ok", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ventanaAnterior.Show();
                this.Close();
            }
            catch (CamposObligatoriosIncompletosException error)
            {
                error.mensaje();
            }
        }
    }
}
