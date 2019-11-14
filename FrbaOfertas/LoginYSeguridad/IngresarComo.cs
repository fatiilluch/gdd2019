using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FrbaOfertas.LoginYSeguridad;
using Utilidades;
using FrbaOfertas.Registro_de_usuario;
using FrbaOfertas.MenuPrincipal;
namespace FrbaOfertas.LoginYSeguridad
{
    public partial class IngresarComo : Form
    {
        private Usuario usuario;
        
        public IngresarComo(Usuario us)
        {
            InitializeComponent();
            usuario=us;
            inicializarComboBox();

        }

        private void inicializarComboBox()
        {
            String query = String.Format("Select rol_nombre from UsuarioPorRol t1 join Roles t2 on (t1.rol_id=t2.rol_id) where nombre_usuario='{0}'", usuario.getNombreUsuario());
            DataSet ds = Utilidades.Utilidades.ejecutarConsulta(query);
            foreach (DataRow fila in ds.Tables[0].Rows)
            {
                Rol r = new Rol(fila["rol_nombre"].ToString());
                cmbRoles.Items.Add(r.ToString());
            }
        }

        private void btnIngresar_Click(object sender, EventArgs e)
        {
            if (cmbRoles.SelectedItem != null)
            {
                Rol r = new Rol(cmbRoles.SelectedItem.ToString());
                MenuPrincipal.MenuPrincipal menu = new MenuPrincipal.MenuPrincipal(usuario,r);
                menu.Show();
                this.Close();
            }
        }

        private void btnAtras_Click(object sender, EventArgs e)
        {
            this.Close();
            Login v = new Login();
            v.Show();
        }

            
    }
}
