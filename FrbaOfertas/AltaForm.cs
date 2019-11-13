using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FrbaOfertas.Registro_de_usuario;
using System.Data.SqlClient;

namespace FrbaOfertas
{
    public partial class AltaForm : Form
    {
        protected List<TextBox> camposObligatorios = new List<TextBox>();
        protected Form ventanaAnterior;

        public AltaForm()
        {
            InitializeComponent();
        }
        public AltaForm(Form v)
        {
            InitializeComponent();
            ventanaAnterior = v;
            inicializarCamposObligatorios();
        }

        protected virtual void inicializarCamposObligatorios() { }
        
        protected bool camposObligatoriosCompletados()
        {
            bool flag = true;
            if (camposObligatorios.Exists(campo => campo.Text == string.Empty))
            {
                flag = false;
                List<TextBox> camposSinLlenar = camposObligatorios.Where(campo => campo.Text == string.Empty).ToList();
                MessageBox.Show("Falta llenar campos: " + camposSinLlenar.Aggregate("", (s, next) => s + next.Name.TrimStart('t', 'x', 't') + " , ").TrimEnd(',', ' '), "Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return flag;
        }
        protected void cargarUsuario(Usuario us)
        {
            if (us != null)
            {
                SqlCommand cmd1 = new SqlCommand("Insert into Usuarios (nombre_usuario,password) values (@name,@pass)", Utilidades.Utilidades.getCon());
                cmd1.Parameters.AddWithValue("@name", us.getNombreUsuario());
                String hash = Utilidades.Utilidades.obtenerHash(us.getPass());
                cmd1.Parameters.AddWithValue("@pass", hash);

                Utilidades.Utilidades.ejecutar(cmd1);

            }
        }
        protected void btnAtras_Click(object sender, EventArgs e)
        {
            this.Close();
            this.ventanaAnterior.Show();
        }
    }
}
