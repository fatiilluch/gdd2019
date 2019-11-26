using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using FrbaOfertas.Entidades;

namespace FrbaOfertas.ComprarOferta
{
    public partial class ConfirmarCompra : Form
    {
        private Form menuPrincipal;
        private Form ventanaAnterior;
        private Oferta oferta;
        private Usuario usuario;
        public ConfirmarCompra()
        {
            InitializeComponent();
        }
        public ConfirmarCompra(Usuario us,Oferta ofertaComprada, Form atras, Form menu)
        {
            InitializeComponent();
            menuPrincipal = menu;
            ventanaAnterior = atras;
            oferta = ofertaComprada;
            cargarCampos();
            usuario = us;
        }
        private void cargarCampos()
        {
            //todo, cargar los textbox con la info de la compra realizada y hacer un 
            //Usted esta a punto de comprar:
            //                  tal costa, a tal precio blabla onda mercadolibre equisde matenme plz
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnConfirmar_Click(object sender, EventArgs e)
        {
            try
            {
                SqlCommand cmd = new SqlCommand("comprar_oferta");
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@user_name", SqlDbType.NVarChar, 255).Value = usuario.getNombreUsuario();
                cmd.Parameters.Add("@oferta_id", SqlDbType.NVarChar, 50).Value = oferta.Oferta_id;

                Utilidades.Utilidades.ejecutar(cmd);
                MessageBox.Show("Compra realizada con éxito!", "Ok", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
                menuPrincipal.Show();
            }
            catch (SqlException error)
            {
                MessageBox.Show(error.Message,"Failed",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
        }
    }
}
