using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrbaOfertas.Entidades
{

    public class Usuario
    {
        private String nombreUsuario;
        private String pass;
        public Usuario() { }
        public Usuario(String nom, String pas)
        {
            this.nombreUsuario = nom;
            this.pass = pas;
        }
        public String getNombreUsuario() { return this.nombreUsuario; }
        public String getPass() { return this.pass; }
        public void setNombreUsuario(String n) { this.nombreUsuario = n; }
        public void setPass(String p) { this.pass = p; }
    }
}
