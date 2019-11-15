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
using FrbaOfertas.AbmCliente;
using FrbaOfertas.AbmProveedor;
using FrbaOfertas.Entidades;

namespace FrbaOfertas.Registro_de_usuario
{
    public partial class RegistrarUsuario : AltaForm
    {
        public RegistrarUsuario(Form ventana)
        {
            InitializeComponent();
            inicializarComboBox();
            inicializarCamposObligatorios();
            this.ventanaAnterior = ventana;
        }
        protected override void inicializarCamposObligatorios()
        {
            camposObligatorios.Add(txtUsuario);
            camposObligatorios.Add(txtPassword);
        }
        private void inicializarComboBox()
        {
            String query = "Select rol_nombre from Roles where habilitado = 1";
            DataSet ds = Utilidades.Utilidades.ejecutarConsulta(query);

            foreach (DataRow fila in ds.Tables[0].Rows)
            {
                cmbRol.Items.Add(fila["rol_nombre"].ToString());
            }
            cmbRol.Items.Remove("Administrador");
        }

        private void btnSeleccionar_Click(object sender, EventArgs e)
        {
            if (camposObligatoriosCompletados() && cmbRol.SelectedItem!=null)
            {
                Usuario user = new Usuario(txtUsuario.Text, txtPassword.Text);
                if(!nombreUsuarioEnUso(user.getNombreUsuario())){
                    
                    String seleccionado = cmbRol.SelectedItem.ToString();
                    switch (seleccionado)
                    {
                        case "Cliente":
                            this.Hide();
                            AltaCliente ventanaCliente = new AltaCliente(user, this);
                            ventanaCliente.Show();
                            break;
                        case "Proveedor":
                            this.Hide();
                            AltaProveedor ventanaProveedor = new AltaProveedor(user, this);
                            ventanaProveedor.Show();
                            break;
                    }
                }else
                {
                    MessageBox.Show("Nombre de usuario no disponible","Failed",MessageBoxButtons.OK,MessageBoxIcon.Error);
                }
            }
            

        }
        private Boolean nombreUsuarioEnUso(String nombre)
        {
            String cmd = String.Format("Select * from Usuarios where nombre_usuario= '{0}'", nombre.ToLower());

            int filasRetornadas = Utilidades.Utilidades.ejecutarConsulta(cmd).Tables[0].Rows.Count;
            if (filasRetornadas<=0) { 
                return false; 
            } else { return true; }
        }
        private void RegistrarUsuario_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.ventanaAnterior.Show();
        }
        
        
    }
}
