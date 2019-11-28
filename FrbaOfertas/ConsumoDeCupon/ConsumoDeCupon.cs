﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FrbaOfertas.Listado;
using FrbaOfertas.Entidades;
using System.Data.SqlClient;
using FrbaOfertas.GestorDeErrores;
namespace FrbaOfertas.ConsumoDeCupon
{
    public partial class ConsumoDeCupon : Form
    {
        private Usuario usuario;
        private Form menuPrincipal;
        private List<TextBox> camposObligatorios = new List<TextBox>();
        public ConsumoDeCupon()
        {
            InitializeComponent();
        }
        public ConsumoDeCupon(Form menu)
        {
            InitializeComponent();
            menuPrincipal = menu;
            cargarCamposObligatorios();
        }
        public ConsumoDeCupon(Usuario us,Form menu)
        {
            InitializeComponent();
            usuario = us;
            menuPrincipal = menu;
            cargartxtCuit();
            cargarCamposObligatorios();
            btnBuscar.Enabled = false;
            btnBuscar.BackColor = SystemColors.ControlDarkDark;
        }
        private void cargarCamposObligatorios()
        {
            camposObligatorios.Add(txtCuit);
            camposObligatorios.Add(txtCuponId);
            camposObligatorios.Add(txtDni);
            dateFechaConsumo.Enabled = false;
            dateFechaConsumo.Value = DateTime.Now;
        }
        private void cargartxtCuit()
        {
            String query= String.Format("select cuit from proveedores where nombre_usuario='{0}'",usuario.getNombreUsuario());
            DataSet ds = Conexion.Conexion.ejecutarConsulta(query);
            txtCuit.Text = ds.Tables[0].Rows[0]["cuit"].ToString();
            txtCuit.Enabled = false;
            txtCuit.ReadOnly = true;
        }
        private void btnBuscar_Click(object sender, EventArgs e)
        {
            Form v = new ListadoDeProveedores(txtCuit);
            v.Show();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Hide();
            menuPrincipal.Show();
        }

        private void btnConfirmar_Click(object sender, EventArgs e)
        {
            try
            {
                GestorDeErrores.GestorDeErrores.verificarCamposObligatoriosCompletos(camposObligatorios);
                SqlCommand cmd = new SqlCommand("cargar_consumo_de_cupon");
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@cupon_id", SqlDbType.Int).Value = Convert.ToInt32(txtCuponId.Text);
                cmd.Parameters.Add("@dni", SqlDbType.NVarChar, 18).Value = txtDni.Text;
                cmd.Parameters.Add("@fecha_consumo", SqlDbType.DateTime).Value = dateFechaConsumo.Value;
                cmd.Parameters.Add("@cuit", SqlDbType.NVarChar, 20).Value = txtCuit.Text;

                Conexion.Conexion.ejecutar(cmd);
                MessageBox.Show("Cupon consumido con exito!", "Ok", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            catch (CamposObligatoriosIncompletosException error)
            {
                error.mensaje();
            }
            catch(SqlException error)
            {
                MessageBox.Show(error.Number+" :"+error.Message, "Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                Conexion.Conexion.getCon().Close();
            }
        }
    }
}
