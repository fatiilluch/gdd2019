using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FrbaOfertas.AbmCliente
{
    public partial class MenuAbmCliente : Form
    {

        private Form origen;
        public MenuAbmCliente(Form ventana)
        {
            InitializeComponent();
            origen = ventana;
        }
    }
}
