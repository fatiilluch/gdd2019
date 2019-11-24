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

namespace FrbaOfertas.AbmRol
{
    public partial class AltaRol : AltaForm
    {
        private Form origen;
        List<Funcionalidad> funcionalidadesDisponibles = new List<Funcionalidad>();
        List<Funcionalidad> funcionalidadesAgregadas = new List<Funcionalidad>();

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
            dgAgregados.DataSource = funcionalidadesAgregadas;
            dgAgregados.AutoGenerateColumns = true;
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

                //TO DO

                MessageBox.Show("Rol creado con éxito!","Ok",MessageBoxButtons.OK,MessageBoxIcon.Information);
            }
            catch (CamposObligatoriosIncompletosException error)
            {
                error.mensaje();
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

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            if (dgFuncionalidadesDisponibles.SelectedRows != null)
            {
                Funcionalidad f = new Funcionalidad();
                f.Id = Convert.ToInt16(dgFuncionalidadesDisponibles.SelectedRows[0].Cells[0].Value);
                f.Nombre = Convert.ToString(dgFuncionalidadesDisponibles.SelectedRows[0].Cells[1].Value);

                funcionalidadesAgregadas.Add(f);
                funcionalidadesDisponibles.Remove(funcionalidadesDisponibles.Find(o => o.Id == f.Id));
                dgAgregados.Refresh();
                dgFuncionalidadesDisponibles.Refresh();
                
            }
        }
        private void btnQuitar_Click(object sender, EventArgs e)
        {
            if (dgAgregados.SelectedRows != null)
            {
                Funcionalidad f = new Funcionalidad();
                f.Id = Convert.ToInt16(dgFuncionalidadesDisponibles.SelectedRows[0].Cells[0].Value);
                f.Nombre = Convert.ToString(dgFuncionalidadesDisponibles.SelectedRows[0].Cells[1].Value);

                funcionalidadesDisponibles.Add(f);
                funcionalidadesAgregadas.Remove(funcionalidadesAgregadas.Find(func => func.Id == f.Id));

                dgAgregados.DataSource = funcionalidadesAgregadas;
                dgFuncionalidadesDisponibles.DataSource = funcionalidadesDisponibles;
                dgFuncionalidadesDisponibles.Refresh();
                dgAgregados.Refresh();
            }
        }
        private void dgAgregados_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            dgAgregados.Refresh();
        }

        private void dgAgregados_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            dgAgregados.Refresh();
        }

        private void dgFuncionalidadesDisponibles_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            dgFuncionalidadesDisponibles.Refresh();
        }

        private void dgFuncionalidadesDisponibles_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            dgFuncionalidadesDisponibles.Refresh();
        }

        private void dgFuncionalidadesDisponibles_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            desbloquearBoton(btnAgregar);
            bloquearBoton(btnQuitar);
        }

        private void dgAgregados_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            desbloquearBoton(btnQuitar);
            bloquearBoton(btnAgregar);
        }
    }
}
