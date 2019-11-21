using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using FrbaOfertas.Registro_de_usuario;
using FrbaOfertas.AbmRol;
using FrbaOfertas.CrearOferta;
using FrbaOfertas.AbmCliente;
using FrbaOfertas.AbmProveedor;

namespace FrbaOfertas.Entidades
{

    public class Funcionalidad
    {
        public int Id { get; set; }
        public String Nombre { get; set; }

        public Funcionalidad() { }
        public Funcionalidad(int n,String name) {
            Id = n;
            Nombre = name;
        }
        public  Form getForm(Form menu){
            switch(Nombre.ToLower())
            {
                case "registrar usuario":
                    return new RegistrarUsuario(menu);
                case "abm de cliente":
                    return new MenuAbmCliente(menu);
                case "abm de proveedor":
                    return new MenuAbmProveedor(menu);
                case "crear oferta":
                    return new AltaOferta(menu);
                case "abm de rol":
                    return new MenuAbmRol(menu);
                default:
                    throw new Exception("Funcionalidad sin menu");
            }
        }

         
    }
}
