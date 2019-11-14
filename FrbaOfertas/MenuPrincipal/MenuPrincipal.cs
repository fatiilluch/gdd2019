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
        ´public Proveedor(String n)
        {
            nombre=n
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
