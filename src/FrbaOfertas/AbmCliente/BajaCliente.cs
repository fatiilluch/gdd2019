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
using System.Data.SqlClient;
using FrbaOfertas.Conexion;
using FrbaOfertas.Utilidades;
using FrbaOfertas.GestorDeErrores;

namespace FrbaOfertas.AbmCliente
{
    public partial class BajaCliente : Form
    {
        private Form menuPrincipal;
        public BajaCliente(Form vent)
        {
            InitializeComponent();
            menuPrincipal = vent;
        }

        private void BajaCliente_FormClosed(object sender, FormClosedEventArgs e)
        {
            menuPrincipal.Show();
            
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            Form v = new ListadoCliente(txtDni);
            v.Show();
        }

        private void txtUsuario_TextChanged(object sender, EventArgs e)
        {
            btnBaja.Enabled = true;
            btnBaja.BackColor = SystemColors.Control;
        }

        private void btnBaja_Click(object sender, EventArgs e)
        {
            try
            {
                GestorDeErrores.GestorDeErrores.verificarClienteHabilitado(txtDni.Text);
                String query = String.Format("update Clientes set habilitado = 0 where dni ='{0}'", txtDni.Text);
                Conexion.Conexion.ejecutar(query);
                MessageBox.Show("Cliente dado de baja con éxito!", "Ok", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch(GestorDeErrores.ClienteDeshabilitadoException error)
            {
                error.mensaje();
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}
