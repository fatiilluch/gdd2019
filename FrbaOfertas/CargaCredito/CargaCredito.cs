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
namespace FrbaOfertas.CragaCredito
{
    public partial class CargaCredito : Form
    {
        private Form origen;
        private Usuario us;
        private DateTime fecha;
        public CargaCredito(Form ventana, Usuario user)
        {
            origen = ventana;
            InitializeComponent();
            fecha = DateTime.Now; // sacarlo de un archivo de config duh
            us = user;
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            calendario.MinDate=DateTime.Now;

        }

        private void CargaCredito_Load(object sender, EventArgs e)
        {
            cmbTipoTarjeta.Items.Add("Débito");
            cmbTipoTarjeta.Items.Add("Crédito");
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
            origen.Show();
        }
        
    }
}
