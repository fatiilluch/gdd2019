using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Utilidades;
using System.Data.SqlClient;
using System.Data;
namespace FrbaOfertas.Entidades
{
    public class Rol
    {
        protected String nombre;
        public Rol() { }
        public Rol(String n)
        {
            nombre = n;
        }
        public DataSet obtenerFuncionalidades()
        {
            int rol_id = Convert.ToInt16(Utilidades.Utilidades.ejecutarConsulta(String.Format("Select rol_id From Roles where rol_nombre='{0}'", nombre)));
            String query = String.Format("Select funcionalidad_nombre from FuncionalidadPorRol f1 join Funcionalidades f2 on (f1.funcionalidad_id=f2.funcionalidad_id) where rol_id={0}", rol_id);
            return Utilidades.Utilidades.ejecutarConsulta(query);

        }
        public String getNombre() { return nombre; }

        public override string ToString()
        {
            return nombre;
        }
    }
}
