using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace FrbaOfertas.Entidades
{

    public class Funcionalidad
    {
        private int id;
        private String nombre;

        public Funcionalidad() { }

        public int getId() { return id; }
        public String getNombre() { return nombre; }
        public void setId(int i) { id = i; }
        public void setNombre(String n) { nombre = n; }
    }
}
