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
            String query = "Select rol_nombre from Roles";
            DataSet ds = Utilidades.Utilidades.ejecutarConsulta(query);
            List<String> listaDeRoles = new List<String>();

            foreach (DataRow fila in ds.Tables[0].Rows)
            {
                cmbRol.Items.Add(fila["rol_nombre"].ToString());
            }
        }

        private void btnSeleccionar_Click(object sender, EventArgs e)
        {
            Usuario us = new Usuario(txtUsuario.Text,txtPassword.Text);
            if (camposObligatoriosCompletados() && cmbRol.SelectedItem!=null)
            {
                String seleccionado = cmbRol.SelectedItem.ToString();
                switch (seleccionado)
                {
                    case "Cliente":
                        this.Hide();
                        AltaCliente ventanaCliente = new AltaCliente(us, this);
                        ventanaCliente.Show();
                        break;
                    case "Proveedor":
                        this.Hide();
                        AltaProveedor ventanaProveedor = new AltaProveedor(us, this);
                        ventanaProveedor.Show();
                        break;
                }
            }
            

            //aca hacer el switch case segun el rol, y que se abra un alta cliente o un alta proveedor segun el rol seleccionado
            //pasando por parametro al constructor del new alta un objeto dto Usuario con el nombre de usuario
            //La idea es que cuando haga crear en la siguiente ventana, primero se cree el usuario con la contraseña 
            //y despues el cliente/proveedor.
        }
        private void RegistrarUsuario_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.ventanaAnterior.Show();
        }
        
        
    }
    public class Usuario
    {
        private String nombreUsuario;
        private String pass;
        public Usuario(String nom,String pas)
        {
            this.nombreUsuario = nom;
            this.pass = pas;
        }
        public String getNombreUsuario() { return this.nombreUsuario; }
        public String getPass() { return this.pass; }
    }
}
