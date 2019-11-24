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

namespace FrbaOfertas.AbmRol
{
    public partial class ModificacionRol : Form
    {
        private Form menu;
        public ModificacionRol(Form vent)
        {
            menu = vent;
            InitializeComponent();

            iniciarComboBox();
        }
        public ModificacionRol()
        {
            InitializeComponent();
            iniciarComboBox();
        }
        private void iniciarComboBox()
        {
            List<Rol> roles = new List<Rol>();
            roles = RepoRol.getInstance().getRoles();
            cmbRoles.DataSource = roles;
            cmbRoles.DisplayMember = "Nombre";
        }
        
        private void ModificacionRol_Load(object sender, EventArgs e)
        {
            iniciarComboBox();
        }

        private void bloquearBoton(Button btn)
        {
            btn.Enabled = false;
            btn.BackColor = SystemColors.ControlDarkDark;
        }
        private void desbloquearBoton(Button btn)
        {
            btn.Enabled = true;
            btn.BackColor = SystemColors.Control;
        }

        private void btnSeleccionar_Click(object sender, EventArgs e)
        {
            bloquearBoton(btnHabilitar);
            bloquearBoton(btnDeshabilitar);
            
            Rol r = cmbRoles.SelectedItem as Rol;
            SqlCommand cmd = new SqlCommand("rol_habilitado");
            cmd.Parameters.Add("@id",SqlDbType.SmallInt).Value=r.Id;
            int i = Utilidades.Utilidades.ejecutarProcedure(cmd);
            
            if (i>0) { desbloquearBoton(btnDeshabilitar); }
            else { desbloquearBoton(btnHabilitar); }
        }

        private void btnHabilitar_Click(object sender, EventArgs e)
        {
            cambiarEstadoRol(true);
            MessageBox.Show("Rol habilitado con éxito!","Ok",MessageBoxButtons.OK,MessageBoxIcon.Information);
            bloquearBoton(btnHabilitar);
            desbloquearBoton(btnDeshabilitar);
        }

        private void btnDeshabilitar_Click(object sender, EventArgs e)
        {
            cambiarEstadoRol(false);
            MessageBox.Show("Rol deshabilitado con éxito!", "Ok", MessageBoxButtons.OK, MessageBoxIcon.Information);
            bloquearBoton(btnDeshabilitar);
            desbloquearBoton(btnHabilitar);
        }
        private void cambiarEstadoRol(Boolean bit)
        {
            SqlCommand cmd = new SqlCommand("update Roles set habilitado = @bit where rol_id=@id");
            Rol r = cmbRoles.SelectedItem as Rol;
            cmd.Parameters.Add("@id", SqlDbType.SmallInt).Value = r.Id;
            cmd.Parameters.Add("@bit", SqlDbType.Bit).Value = bit;

            Utilidades.Utilidades.ejecutar(cmd);
        }
    }
}
