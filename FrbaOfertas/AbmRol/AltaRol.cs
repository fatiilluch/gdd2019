using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Utilidades;
using FrbaOfertas.Entidades;
using System.Data.SqlClient;

namespace FrbaOfertas.AbmRol
{
    public partial class AltaRol : AltaForm
    {
        private Form origen;
        List<Funcionalidad> funcionalidadesDisponibles = new List<Funcionalidad>();

        public AltaRol()
        {
            InitializeComponent();
            inicializarCamposObligatorios();
            inicializarDataGridView();

        }
        public AltaRol(Form menu)
        {
            InitializeComponent();
            inicializarCamposObligatorios();
            inicializarDataGridView();
            origen = menu;
        }

        protected override void inicializarCamposObligatorios()
        {
            camposObligatorios.Add(txtRolNombre);
        }
        private void inicializarDataGridView()
        {
            String query = "Select funcionalidad_id,funcionalidad_nombre From Funcionalidades";
            DataSet ds = Utilidades.Utilidades.ejecutarConsulta(query);
            foreach (DataRow fila in ds.Tables[0].Rows)
            {
                Funcionalidad f = new Funcionalidad(Convert.ToInt16(fila["funcionalidad_id"]), fila["funcionalidad_nombre"].ToString());
                funcionalidadesDisponibles.Add(f);
            }
            dgFuncionalidadesDisponibles.DataSource = funcionalidadesDisponibles;
            dgFuncionalidadesDisponibles.AutoGenerateColumns = true;

            

        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
            origen.Show();
        }

        private void btnCrear_Click(object sender, EventArgs e)
        {
            Utilidades.Utilidades.getCon().Close();

            SqlTransaction trans = Utilidades.Utilidades.beginTransaction();
            
            try
            {
                Utilidades.GestorDeErrores.verificarCamposObligatoriosCompletos(camposObligatorios);
                Utilidades.GestorDeErrores.verificarRolExistente(txtRolNombre.Text.ToLower());

                String query = String.Format("insert into roles (rol_nombre) values ('{0}');", txtRolNombre.Text.ToLower());
                Utilidades.Utilidades.ejecutar(query);

                query = String.Format("select rol_id from roles where rol_nombre = '{0}'", txtRolNombre.Text.ToLower());
                DataSet ds = Utilidades.Utilidades.ejecutarConsulta(query);
                Int16 rol_id = Convert.ToInt16(ds.Tables[0].Rows[0]["rol_id"]);

                foreach (DataGridViewRow fila in dgFuncionalidadesDisponibles.SelectedRows)
                {
                    Int16 f_id = Convert.ToInt16(fila.Cells[0].Value);
                    query = String.Format("insert into FuncionalidadPorRol (rol_id,funcionalidad_id) values ({0},{1});", rol_id, f_id);
                    Utilidades.Utilidades.ejecutar(query);
                }
                Utilidades.Utilidades.commit(trans);
                MessageBox.Show("Rol creado con éxito!", "Ok", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (CamposObligatoriosIncompletosException error)
            {
                error.mensaje();
            }
            catch (RolExistenteException error)
            {
                error.mensaje();
            }
            catch (Exception error)
            {
                Utilidades.Utilidades.rollback(trans);
                MessageBox.Show("Error inesperado, ups!"+error.Message.ToString(), "Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void bloquearBoton(Button btn)
        {
            btn.Enabled = false;
            btn.BackColor = SystemColors.ControlDarkDark;
        }
        private void desbloquearBoton(Button btn)
        {
            btn.Enabled = true;
            btn.BackColor = SystemColors.Control;
        }
    }
}
