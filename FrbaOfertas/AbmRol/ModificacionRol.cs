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
    public partial class ModificacionRol : Form
    {
        private Form menu;
        public ModificacionRol(Form vent)
        {
            menu = vent;
        }
        public ModificacionRol()
        {
            InitializeComponent();
        }

        private void ModificacionRol_Load(object sender, EventArgs e)
        {

        }
    }
}
