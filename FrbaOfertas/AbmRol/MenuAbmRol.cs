using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FrbaOfertas.AbmRol
{
    public partial class MenuAbmRol : Form
    {
        private Form menu;
        public MenuAbmRol()
        {
            InitializeComponent();
        }
        public MenuAbmRol(Form vent)
        {
            InitializeComponent();
            menu = vent;
        }

        private void btnCargar_Click(object sender, EventArgs e)
        {
            AltaRol ventana = new AltaRol(menu);
            ventana.Show();
            this.Close();
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            ModificacionRol ventana = new ModificacionRol(menu);
            ventana.Show();
            this.Close();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            BajaRol ventana = new BajaRol(menu);
            ventana.Show();
            this.Close();
        }

        private void MenuAbmRol_FormClosed(object sender, FormClosedEventArgs e)
        {
            menu.Show();
        }

    }
}
