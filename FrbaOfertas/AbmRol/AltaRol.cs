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

namespace FrbaOfertas.AbmRol
{
    public partial class AltaRol : AltaForm
    {
        
        public AltaRol()
        {
            InitializeComponent();
            inicializarCamposObligatorios();
            inicializarCheckBox();
        }

        protected override void inicializarCamposObligatorios()
        {
            camposObligatorios.Add(txtRolNombre);
        }
        private void inicializarCheckBox()
        {
            String query = "Select funcionalidad_nombre From Funcionalidades";
            DataSet ds = Utilidades.Utilidades.ejecutarConsulta(query);
            foreach (DataRow fila in ds.Tables[0].Rows)
            {
                chkListaDeRoles.Items.Add(fila["funcionalidad_nombre"].ToString());
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnCrear_Click(object sender, EventArgs e)
        {
            if (camposObligatoriosCompletados())
            {
                for (int i = 0; i < chkListaDeRoles.Items.Count; i++)
                {
                    //TODO
                }

            }
        }
    }
}
