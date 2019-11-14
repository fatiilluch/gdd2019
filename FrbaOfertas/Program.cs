using FrbaOfertas.AbmCliente;
using FrbaOfertas.AbmProveedor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using FrbaOfertas.LoginYSeguridad;
using FrbaOfertas.MenuPrincipal;
namespace FrbaOfertas
{
    static class Program
    {
        /// <summary>
        /// Punto de entrada principal para la aplicación.
        /// </summary>
        [STAThread]
        static void Main()
        {
            //Registro_de_usuario.Usuario us = new Registro_de_usuario.Usuario("lele", "1234");
            //MenuPrincipal.Cliente rol = new MenuPrincipal.Cliente("Administrador");
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Login());
        }
    }
}
