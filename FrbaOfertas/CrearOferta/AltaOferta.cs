using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FrbaOfertas.Listado;

namespace FrbaOfertas.CrearOferta
{
    public partial class AltaOferta : AltaForm
    {
        private String proveedorCuit;
        public AltaOferta(Form vent)
        {
            InitializeComponent();
            ventanaAnterior = vent;
        }
        public AltaOferta(Form vent,String cuit)
        {
            InitializeComponent();
            ventanaAnterior = vent;
            proveedorCuit = cuit;
            txtCuit.Text = cuit;
            txtCuit.Enabled = false;
            btnBuscar.BackColor = Color.DarkGray;
            btnBuscar.Enabled = false;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
            ventanaAnterior.Show();
        }

        private void btnPublicar_Click(object sender, EventArgs e)
        {
            //aca hacer el insert
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            Form ventana = new ListadoDeProveedores(txtCuit);
            ventana.Show();
        }
    }
}
