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
        public Boolean Habilitado { get; set; }
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
        
        
    }
    public class RepoRol
    {
        private List<Rol> roles=new List<Rol>();
        public static RepoRol repo;
        public RepoRol()
        {
            DataSet ds = Utilidades.Utilidades.ejecutarConsulta("select rol_nombre,rol_id,habilitado from roles");
            foreach (DataRow fila in ds.Tables[0].Rows)
            {
                Rol r = new Rol(fila["rol_nombre"].ToString(), Convert.ToInt16(fila["rol_id"]));
                r.Habilitado = Convert.ToBoolean(fila["habilitado"]);
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
        public List<Rol> getRolesHabilitados() { return roles.Where(rol => rol.Habilitado).ToList(); }
        public Rol buscarRol(String nombre)
        {
            return roles.Find(rol => rol.Nombre == nombre);
        }

        public static List<Funcionalidad> obtenerFuncionalidadesDelRol(int rol_id)
        {
            String query = String.Format("Select f1.funcionalidad_id,funcionalidad_nombre from FuncionalidadPorRol f1 join Funcionalidades f2 on (f1.funcionalidad_id=f2.funcionalidad_id and f1.rol_id={0})", Convert.ToInt16(rol_id));
            DataSet ds = Utilidades.Utilidades.ejecutarConsulta(query);
            List<Funcionalidad> funcionalidades = new List<Funcionalidad>();

            foreach (DataRow fila in ds.Tables[0].Rows)
            {
                Funcionalidad f = new Funcionalidad(Convert.ToInt16(fila["funcionalidad_id"]),fila["funcionalidad_nombre"].ToString());
            }
            return funcionalidades;
        }
    }
}
