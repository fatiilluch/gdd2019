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
        public MenuAbmRol()
        {
            InitializeComponent();
        }

        private void btnCargar_Click(object sender, EventArgs e)
        {
            AltaRol ventana = new AltaRol();
            ventana.Show();
            this.Close();
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            ModificarRol ventana = new ModificarRol();
            ventana.Show();
            this.Close();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            BajaRol ventana = new BajaRol();
            ventana.Show();
            this.Close();
        }
    }
}
