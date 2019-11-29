﻿using System;
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
using FrbaOfertas.Conexion;
using FrbaOfertas.Utilidades;
using FrbaOfertas.GestorDeErrores;
namespace FrbaOfertas.ComprarOferta
{
    public partial class ComprarOferta : Form
    {
        private Usuario us;
        private Form menu;
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
            SqlCommand cmd1 = new SqlCommand("select * from Ofertas");//aca sería select * from OfertasDisponiblesView, que retorna las ofertas disponibles segun la fecha

            DataSet ds = Conexion.Conexion.ejecutarConsulta(cmd1);
            dgPublicaciones.DataSource = ds.Tables[0];
        }
        private void cargarSaldo()
        {
            SqlCommand cmd2 = new SqlCommand("saldo_disponible");
            cmd2.Parameters.Add("@user_name", SqlDbType.NVarChar, 255).Value = us.getNombreUsuario();
            cmd2.Parameters.Add("@returned", SqlDbType.Decimal).Direction = ParameterDirection.ReturnValue;

            Decimal saldo = (decimal)Conexion.Conexion.ejecutarProcedure(cmd2);
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
            Oferta oferta = new Oferta(
            dgPublicaciones.SelectedRows[0].Cells["oferta_id"].Value.ToString(),
            Convert.ToDateTime(dgPublicaciones.SelectedRows[0].Cells["fecha_publicacion"].Value),
            Convert.ToDateTime(dgPublicaciones.SelectedRows[0].Cells["fecha_vto"].Value),
            Convert.ToDecimal(dgPublicaciones.SelectedRows[0].Cells["precio_oferta"].Value),
            Convert.ToDecimal(dgPublicaciones.SelectedRows[0].Cells["precio_viejo"].Value),
            dgPublicaciones.SelectedRows[0].Cells["proveedor_cuit"].Value.ToString(),
            Convert.ToInt16(dgPublicaciones.SelectedRows[0].Cells["stock"].Value),
            dgPublicaciones.SelectedRows[0].Cells["oferta_descripcion"].Value.ToString(),
            Convert.ToInt16(dgPublicaciones.SelectedRows[0].Cells["limite_compra_por_us"].Value)
            );
            Form confirmacion = new ConfirmarCompra(us,oferta,this,menu);
            confirmacion.Show();
        }
    }
}