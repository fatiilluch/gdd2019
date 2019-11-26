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
using Utilidades;

namespace FrbaOfertas.ComprarOferta
{
    public partial class ComprarOferta : Form
    {
        public Usuario us;
        public Form menu;
        public ComprarOferta()
        {
            InitializeComponent();
        }
        public ComprarOferta(Form v,Usuario u)
        {
            InitializeComponent();
            us = u;
            menu = v;
        }
        private void cargarDg()
        {
            SqlCommand cmd1 = new SqlCommand("select * from OfertasDisponiblesView");
            DataSet ds = Utilidades.Utilidades.ejecutarConsulta(cmd1);
            dgPublicaciones.DataSource = ds.Tables[0];
        }
        private void cargarSaldo()
        {
            SqlCommand cmd2 = new SqlCommand("saldo_disponible");
            cmd2.Parameters.Add("@user_name", SqlDbType.NVarChar, 255).Value = us.getNombreUsuario();
            cmd2.Parameters.Add("@returned", SqlDbType.Decimal).Direction = ParameterDirection.ReturnValue;

            Decimal saldo = (decimal)Utilidades.Utilidades.ejecutarProcedure(cmd2);
            txtSaldo.Text = saldo.ToString();
        }
        private void ComprarOferta_Load(object sender, EventArgs e)
        {
            try
            {
                cargarDg();
                cargarSaldo();
            }
            catch (SqlException error)
            {
                MessageBox.Show(error.Message, "Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ComprarOferta_FormClosed(object sender, FormClosedEventArgs e)
        {
            menu.Show();
        }

        private void btnComprar_Click(object sender, EventArgs e)
        {
            try
            {
                if(Convert.ToDecimal(txtSaldo.Text)<Convert.ToDecimal(dgPublicaciones.SelectedRows[0].Cells["precio_oferta"]))
                { throw new ClienteSinSaldoException(); }

                Oferta oferta = new Oferta(
                    dgPublicaciones.SelectedRows[0].Cells["oferta_id"].ToString(),
                    Convert.ToDateTime(dgPublicaciones.SelectedRows[0].Cells["fecha_publicacion"]),
                    Convert.ToDateTime(dgPublicaciones.SelectedRows[0].Cells["fecha_vto"]),
                    Convert.ToDecimal(dgPublicaciones.SelectedRows[0].Cells["precio_oferta"]),
                    Convert.ToDecimal(dgPublicaciones.SelectedRows[0].Cells["precio_viejo"]),
                    dgPublicaciones.SelectedRows[0].Cells["proveedor_cuit"].ToString(),
                    Convert.ToInt16(dgPublicaciones.SelectedRows[0].Cells["stock"]),
                    dgPublicaciones.SelectedRows[0].Cells["oferta_descripcion"].ToString(),
                    Convert.ToInt16(dgPublicaciones.SelectedRows[0].Cells["limite_compra_por_us"])
                );
                Form confirmacion = new ConfirmarCompra(us,oferta,this,menu);
                confirmacion.Show();
            }
            catch(ClienteSinSaldoException error)
            { error.mensaje(); }
        }
    }
}
