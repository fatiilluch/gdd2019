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
using FrbaOfertas.Entidades;

namespace FrbaOfertas.AbmRol
{
    public partial class BajaRol : Form
    {
        private Form menu;
        public BajaRol()
        {
            InitializeComponent();
        }
        public BajaRol(Form vent)
        {
            InitializeComponent();
            menu = vent;
        }
        
        private void BajaRol_Load(object sender, EventArgs e)
        {
            List<Rol> roles = RepoRol.getInstance().getRoles();
            cmbRoles.DataSource = roles;
            cmbRoles.DisplayMember = "Nombre";
        }
    }
}
