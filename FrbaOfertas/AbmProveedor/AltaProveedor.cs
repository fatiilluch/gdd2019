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
using Utilidades;
using FrbaOfertas.Entidades;

namespace FrbaOfertas.AbmProveedor
{
    public partial class AltaProveedor : AltaForm
    {
        private Usuario us = new Usuario();
        public  AltaProveedor(Usuario user,Form v)
        {
            InitializeComponent();
            inicializarCamposObligatorios();
            ventanaAnterior = v;
            us = user;
        }
        public AltaProveedor()
        {
            InitializeComponent();
            inicializarCamposObligatorios();
        }
        public AltaProveedor(Form v)
        {
            InitializeComponent();
            inicializarCamposObligatorios();
            ventanaAnterior = v;
        }
        public AltaProveedor(Form v,Proveedor p)
        {
            InitializeComponent();
            inicializarCamposObligatorios();
            ventanaAnterior = v;
            us.setNombreUsuario(p.Nombre_usuario);
        }
        
        protected override void inicializarCamposObligatorios()
        {
            camposObligatorios.Add(txtRs);
            camposObligatorios.Add(txtCuit);
            camposObligatorios.Add(txtRubro);
            camposObligatorios.Add(txtEmail);
            camposObligatorios.Add(txtTelefono);
            camposObligatorios.Add(txtCiudad);
            camposObligatorios.Add(txtDireccion);
            camposObligatorios.Add(txtCp);
            camposObligatorios.Add(txtContacto);
        }

        protected void btnCrear_Click(object sender, EventArgs e)
        {
             try
             {
                 Utilidades.GestorDeErrores.verificarCamposObligatoriosCompletos(camposObligatorios);
                 Utilidades.GestorDeErrores.verificarProveedoresDuplicados(txtCuit.Text);

                 SqlCommand cmd = new SqlCommand("INSERT INTO Proveedores (rs,email,telefono,ciudad,codigo_postal,cuit,rubro_id,nombre_contacto,direccion,piso,dpto,nombre_usuario) VALUES (@rs,@email,@telefono,@ciudad,@cuit,@rubro_id,@contacto,@direccion,@piso,@depto,@user)");
                 String SelectRol = "Select rol_id from Roles where rol_nombre='Proveedor'";
                 int rol_id = Convert.ToInt32(Utilidades.Utilidades.ejecutarConsulta(SelectRol).Tables[0].Rows[0]);

                 cargarCmd(cmd);
                 if (us.getNombreUsuario() != null) { cargarUsuario(us, rol_id); }
                 Utilidades.Utilidades.ejecutar(cmd);
                 MessageBox.Show("Proveedor guardado exitosamente!", "Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch(CamposObligatoriosIncompletosException error)
                {
                    error.mensaje();
                }
                catch (SqlException error)
                {
                    Utilidades.GestorDeErrores.mostrarErrorSegunTipo(error);
                }
        }

        protected void btnLimpiar_Click(object sender, EventArgs e)
        {
            camposObligatorios.ForEach(box => box.Clear());
            txtPiso.Clear();
            txtDepto.Clear();
        }
        protected void cargarCmd(SqlCommand cmd)
        {
            cmd.Parameters.Add("@rs", SqlDbType.NVarChar,100).Value=txtRs.Text;
            cmd.Parameters.Add("@email", SqlDbType.NVarChar, 255).Value = txtEmail.Text;
            cmd.Parameters.Add("@telefono", SqlDbType.NVarChar, 18).Value = txtTelefono.Text;
            cmd.Parameters.Add("@ciudad", SqlDbType.NVarChar, 255).Value = txtCiudad.Text;
            cmd.Parameters.Add("@codigo_postal", SqlDbType.NVarChar, 20).Value = txtCp;
            cmd.Parameters.Add("@cuit", SqlDbType.NVarChar, 20).Value = txtCuit.Text;
            cmd.Parameters.Add("@rubro_id", SqlDbType.SmallInt).Value=Convert.ToInt16(txtRubro.Text);
            cmd.Parameters.Add("@contacto", SqlDbType.NVarChar, 255).Value = txtContacto.Text; ;
            cmd.Parameters.Add("@direccion", SqlDbType.NVarChar,255).Value=txtDireccion.Text;
            cmd.Parameters.Add("@piso", SqlDbType.SmallInt).Value = txtPiso.Text;
            cmd.Parameters.Add("@depto", SqlDbType.Char).Value = txtDepto.Text;
            cmd.Parameters.Add("@user", SqlDbType.NVarChar,255).Value=us.getNombreUsuario();
        }
    }

}

