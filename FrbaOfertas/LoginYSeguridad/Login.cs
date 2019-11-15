using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Utilidades;
using System.Data.SqlClient;
using System.Security.Cryptography;
using FrbaOfertas.Entidades;
using FrbaOfertas.MenuPrincipal;
using FrbaOfertas.Registro_de_usuario;

namespace FrbaOfertas.LoginYSeguridad
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void btnIngresar_Click(object sender, EventArgs e)
        {
            try{

                if (txtUsserName.Text != null && txtPassword.Text != null)
                {
                    String query = String.Format("Select * from Usuarios where nombre_usuario='{0}'", txtUsserName.Text.Trim());
                    DataSet ds = Utilidades.Utilidades.ejecutarConsulta(query);

                    Usuario usuario = new Usuario();
                    usuario.setNombreUsuario(ds.Tables[0].Rows[0]["nombre_usuario"].ToString().Trim());
                    usuario.setPass(ds.Tables[0].Rows[0]["password"].ToString().Trim());

                    if (usuario.getNombreUsuario() !=null)
                    {
                        String hash = Utilidades.Utilidades.obtenerHash(txtPassword.Text.Trim());

                        String query2 = "update Usuarios set intentos = @intentos where nombre_usuario=@usuario";
                        SqlCommand cmd = new SqlCommand(query2, Utilidades.Utilidades.getCon());
                        int intentos = Convert.ToInt32(ds.Tables[0].Rows[0]["intentos"].ToString());
                        Boolean habilitado = Convert.ToBoolean(ds.Tables[0].Rows[0]["habilitado"]);

                        if (habilitado == true)
                        {
                            if (usuario.getPass() == hash)
                            {
                                intentos = 0;
                                cmd.Parameters.AddWithValue("@intentos", intentos);
                                cmd.Parameters.AddWithValue("@usuario", usuario.getNombreUsuario());
                                Utilidades.Utilidades.ejecutar(cmd);

                                IngresarComo ingresarComo = new IngresarComo(usuario);
                                this.Hide();
                                ingresarComo.Show();
                            }
                            else
                            {
                                intentos += 1;
                                if (intentos == Utilidades.Utilidades.getCantidadDeIntentos())
                                {
                                    MessageBox.Show("Intentos agotados. Usuario bloqueado. Contactese con un administrador", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    Utilidades.Utilidades.ejecutar(String.Format("update Usuarios set habilitado = 0 where nombre_usuario ='{0}'", usuario));
                                }
                                else
                                {
                                    MessageBox.Show("Contraseña incorrecta. Intente nuevamente", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                }
                                cmd.Parameters.AddWithValue("@intentos", intentos);
                                cmd.Parameters.AddWithValue("@usuario", usuario.getNombreUsuario());
                                Utilidades.Utilidades.ejecutar(cmd);
                            }

                        }
                        else
                        {
                            MessageBox.Show("El usuario se encuentra bloqueado. Contactese con un administrador", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }else{MessageBox.Show("Usuario inexistente!","Failed",MessageBoxButtons.OK,MessageBoxIcon.None);}
                }
                else { MessageBox.Show("Complete los campos por favor", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Error); }
                    
            }catch(Exception error){
                    MessageBox.Show("Error: " + error, "Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    
            }
            

        }

        private void btnRegistrarse_Click(object sender, EventArgs e)
        {
            this.Hide();
            RegistrarUsuario ventana = new RegistrarUsuario(this);
            ventana.Show();
        }


    }
}
