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
using FrbaOfertas.CambiarPassword;

namespace FrbaOfertas.MenuPrincipal
{
    public partial class MenuPrincipal : Form
    {
        Usuario usuario;
        Rol rol;
        public MenuPrincipal(Usuario us, Rol r)
        {
            InitializeComponent();
            usuario = us;
            rol=r;
            inicializarFuncionalidades();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void MenuPrincipal_Load(object sender, EventArgs e)
        {
            lblUsuario.Text = usuario.getNombreUsuario();
            lblR.Text = rol.ToString();
        }
        private void inicializarFuncionalidades()
        {
            
        }

        private void btnCambiarContraseña_Click(object sender, EventArgs e)
        {
            CambiarPassword.CambiarPassword ventana=new CambiarPassword.CambiarPassword(usuario);
            ventana.Show();
        }

    }

}
