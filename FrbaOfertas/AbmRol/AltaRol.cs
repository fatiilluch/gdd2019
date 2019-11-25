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
            funcionalidadesDisponibles = Funcionalidad.getFuncionalidades();
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


            try
            {
                Utilidades.GestorDeErrores.verificarCamposObligatoriosCompletos(camposObligatorios);
                Utilidades.GestorDeErrores.verificarRolExistente(txtRolNombre.Text.ToLower());

                SqlTransaction trans = Utilidades.Utilidades.beginTransaction();
                SqlCommand cmd = new SqlCommand();
                cmd.Transaction = trans;

                String query = String.Format("insert into roles (rol_nombre) values ('{0}');", txtRolNombre.Text.ToLower());
                cmd.CommandText = query;
                Utilidades.Utilidades.ejecutar(cmd);

                query = String.Format("select rol_id from roles where rol_nombre = '{0}'", txtRolNombre.Text.ToLower());
                cmd.CommandText = query;
                DataSet ds = Utilidades.Utilidades.ejecutarConsulta(cmd);
                Int16 rol_id = Convert.ToInt16(ds.Tables[0].Rows[0]["rol_id"]);

                foreach (DataGridViewRow fila in dgFuncionalidadesDisponibles.SelectedRows)
                {
                    Int16 f_id = Convert.ToInt16(fila.Cells[0].Value);
                    query = String.Format("insert into FuncionalidadPorRol (rol_id,funcionalidad_id) values ({0},{1});", rol_id, f_id);
                    cmd.CommandText = query;
                    Utilidades.Utilidades.ejecutar(cmd);
                }
              
                trans.Dispose();
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
                MessageBox.Show("Error inesperado, ups!" + error.Message.ToString(), "Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                Utilidades.Utilidades.getCon().Close();
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
