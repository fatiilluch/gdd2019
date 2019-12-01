using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FrbaOfertas.Entidades;
using System.Data.SqlClient;
using FrbaOfertas.Conexion;
using FrbaOfertas.Utilidades;
using FrbaOfertas.GestorDeErrores;

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
        }
        
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
        protected void cargarUsuario(Usuario us,int rol_id)
        {
            if (us != null)
            {
                SqlCommand cmd1 = new SqlCommand("Insert into [RE_GDDIENTOS].Usuarios (nombre_usuario,password) values (@name,@pass)", Conexion.Conexion.getCon());
                cmd1.Parameters.AddWithValue("@name", us.getNombreUsuario());
                String hash = Utilidades.Utilidades.obtenerHash(us.getPass());
                cmd1.Parameters.AddWithValue("@pass", hash);

                SqlCommand cmd2 = new SqlCommand("Insert into [RE_GDDIENTOS].UsuarioPorRol (rol_id, nombre_usuario) values (@id,@name)", Conexion.Conexion.getCon());
                cmd2.Parameters.AddWithValue("@id", rol_id);
                cmd2.Parameters.AddWithValue("@name",us.getNombreUsuario());

                Conexion.Conexion.ejecutar(cmd1);
                Conexion.Conexion.ejecutar(cmd2);

            }
        }
        protected void btnAtras_Click(object sender, EventArgs e)
        {
            this.Hide();
            this.ventanaAnterior.Show();
        }
    }
}
