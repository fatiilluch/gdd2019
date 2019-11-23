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
            List<Funcionalidad> funcionalidades = new List<Funcionalidad>();
            foreach (DataRow fila in ds.Tables[0].Rows)
            {
                Funcionalidad f = new Funcionalidad(Convert.ToInt16(fila["funcionalidad_id"]), fila["funcionalidad_nombre"].ToString());
                funcionalidades.Add(f);
            }
            dgFuncionalidadesDisponibles.DataSource = funcionalidades;
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
            }
            catch (CamposObligatoriosIncompletosException error)
            {
                error.mensaje();
            }

        }
    }
}
