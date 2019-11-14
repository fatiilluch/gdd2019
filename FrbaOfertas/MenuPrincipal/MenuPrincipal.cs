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

namespace FrbaOfertas.MenuPrincipal
{
    public partial class MenuPrincipal : Form
    {
        Usuario usuario;
        Rol rol;
        public MenuPrincipal(Usuario us, Rol r)
        {
            InitializeComponent();
            usuario = us;
            rol=r;
            r.inicializarFuncionalidades(cmbFuncionalidades);
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void MenuPrincipal_Load(object sender, EventArgs e)
        {
            lblUsuario.Text = usuario.getNombreUsuario();
            lblR.Text = rol.ToString();
        }

        private void btnCambiarContraseña_Click(object sender, EventArgs e)
        {

        }

    }
    public class Rol
    {
        protected String nombre;
        public Rol() { }
        public Rol(String n)
        {
            nombre = n;
        }
        public void inicializarFuncionalidades(ComboBox cmb)
        {
            int rol_id = Convert.ToInt16(Utilidades.Utilidades.ejecutarConsulta(String.Format("Select rol_id From Roles where rol_nombre='{0}'", nombre)).Tables[0].Rows[0]["rol_id"]);
            String query = String.Format("Select funcionalidad_nombre from FuncionalidadPorRol f1 join Funcionalidades f2 on (f1.funcionalidad_id=f2.funcionalidad_id) where rol_id={0}", rol_id);
            DataSet ds = Utilidades.Utilidades.ejecutarConsulta(query);
            foreach (DataRow fila in ds.Tables[0].Rows )
            {
                cmb.Items.Add(fila["funcionalidad_nombre"]);
            }

        }
        public String getNombre() { return nombre; }

        public override string ToString()
        {
            return nombre;
        }
    }
    public class Cliente : Rol 
    {
        public Cliente(String n)
        {
            nombre=n;
        }
    }
    public class Proveedor : Rol
    {
        public Proveedor(String n)
        {
            nombre = n;
        }

    }
    public class Administrador : Rol
    {
        public Administrador(String n)
        {
            nombre=n;
        }
    }



}
