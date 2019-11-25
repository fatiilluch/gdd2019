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
using Utilidades;
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
            List<Rol> roles = RepoRol.getInstance().getRoles().Where(rol=>rol.Nombre!="Administrador General").ToList<Rol>();
            cmbRol.DisplayMember = "Nombre";
            cmbRol.DataSource = roles;

        }

        private void btnSeleccionar_Click(object sender, EventArgs e)
        {
            try
            {
                if (cmbRol.SelectedItem != null)
                {
                    Usuario user = new Usuario(txtUsuario.Text, txtPassword.Text);
                    Utilidades.GestorDeErrores.verificarExistenciaDeUsuario(user.getNombreUsuario());

                    Rol seleccionado = cmbRol.SelectedItem as Rol;
                    Utilidades.GestorDeErrores.verificarUsuarioPorRolExistente(seleccionado.Id, user.getNombreUsuario());

                    switch (seleccionado.Nombre)
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
                }
            }
            catch (CamposObligatoriosIncompletosException error)
            {
                error.mensaje();
            }
            catch (UsuarioInexistenteException error)
            { error.mensaje(); }
            catch (UsuarioConRolExistenteException error)
            { error.mensaje(); }
            
            

        }
        
        private void RegistrarUsuario_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.ventanaAnterior.Show();
        }
        
        
    }
}
