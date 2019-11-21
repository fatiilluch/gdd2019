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
        public int Id { get; set; }
        public String Nombre { get; set; }
        public Rol() { }
        public Rol(String n)
        {
            Nombre = n;
        }
        public Rol(String name, int num)
        {
            Nombre = name;
            Id = num;
        }
        public DataSet obtenerFuncionalidades()
        {
            int rol_id = Convert.ToInt16(Utilidades.Utilidades.ejecutarConsulta(String.Format("Select rol_id From Roles where rol_nombre='{0}'", Nombre)));
            String query = String.Format("Select funcionalidad_nombre from FuncionalidadPorRol f1 join Funcionalidades f2 on (f1.funcionalidad_id=f2.funcionalidad_id) where rol_id={0}", rol_id);
            return Utilidades.Utilidades.ejecutarConsulta(query);
        }
        
    }
    public class RepoRol
    {
        private List<Rol> roles=new List<Rol>();
        public static RepoRol repo;
        public RepoRol()
        {
            DataSet ds = Utilidades.Utilidades.ejecutarConsulta("select rol_nombre,rol_id from roles where habilitado = 1");
            foreach (DataRow fila in ds.Tables[0].Rows)
            {
                Rol r = new Rol(fila["rol_nombre"].ToString(), Convert.ToInt16(fila["rol_id"]));
                roles.Add(r);
            }

        }
        public static RepoRol getInstance()
        {
            if (repo == null)
            {
                repo = new RepoRol();
            }
            return repo;
        }
        public List<Rol> getRoles() { return roles; }
        public Rol buscarRol(String nombre)
        {
            return roles.Find(rol => rol.Nombre == nombre);
        }
    }
}
