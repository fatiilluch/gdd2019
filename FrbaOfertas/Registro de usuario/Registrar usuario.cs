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

            foreach (DataRow fila in ds.Tables[0].Rows)
            {
                cmbRol.Items.Add(fila["rol_nombre"].ToString());
            }
            cmbRol.Items.Remove("Administrador");
        }

        private void btnSeleccionar_Click(object sender, EventArgs e)
        {
            Usuario us = new Usuario(txtUsuario.Text,txtPassword.Text);
            if (camposObligatoriosCompletados() && cmbRol.SelectedItem!=null)
            {
                if(nombreUsuarioDisponible(us.getNombreUsuario())){

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
                }else{
                    MessageBox.Show("Nombre de usuario no disponible","Failed",MessageBoxButtons.OK,MessageBoxIcon.Error);
                }
            }
            

        }
        private Boolean nombreUsuarioDisponible(String nombre)
        {
            SqlCommand cmd = new SqlCommand("Select nombre_usuario from Usuarios where nombre_usuario=@name", Utilidades.Utilidades.getCon());
            cmd.Parameters.AddWithValue("@name", nombre);
            int filasRetornadas = cmd.ExecuteNonQuery();
            if (filasRetornadas > 0) { return false; } else { return true; }
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
