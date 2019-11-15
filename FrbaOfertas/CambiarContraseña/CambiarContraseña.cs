using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FrbaOfertas.Registro_de_usuario;
namespace FrbaOfertas.CambiarContraseña
{
    public partial class CambiarContraseña : Form
    {
        private Usuario usuario;
        public CambiarContraseña(Usuario us)
        {
            InitializeComponent();
            usuario = us;
        }

    }
}
