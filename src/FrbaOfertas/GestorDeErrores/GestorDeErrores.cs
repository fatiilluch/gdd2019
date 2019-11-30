using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;
using FrbaOfertas.Conexion;
namespace FrbaOfertas.GestorDeErrores
{
    public class GestorDeErrores
    {
        
        public static void verificarClientesDuplicados(String dni)
        {
            SqlCommand cmd = new SqlCommand("cliente_existente");
            cmd.Parameters.Add("@dni", SqlDbType.NVarChar, 18).Value = dni;

            int i = Conexion.Conexion.ejecutarProcedure(cmd);
            if (i < 0) { throw new ClienteDuplicadoException(); }
        }
        public static void verificarProveedoresDuplicados(String cuit)
        {
            SqlCommand cmd = new SqlCommand("proveedor_existente");
            cmd.Parameters.Add("@cuit", SqlDbType.NVarChar, 20).Value = cuit;

            int i = Conexion.Conexion.ejecutarProcedure(cmd);
            if (i < 0) { throw new ProveedorDuplicadoException(); }
        }
        public static void verificarUsuarioPorRolExistente(int rol_id, String username)
        {
            SqlCommand cmd = new SqlCommand("usuario_con_rol_existente");
            cmd.Parameters.Add("@rol_id", SqlDbType.SmallInt).Value = rol_id;
            cmd.Parameters.Add("@username", SqlDbType.NVarChar).Value = username;

            int i = Conexion.Conexion.ejecutarProcedure(cmd);
            if (i > 0) { throw new UsuarioConRolExistenteException(); }
        }

        public static void verificarExistenciaDeUsuario(String nombre)
        {
            SqlCommand cmd = new SqlCommand("usuario_existente");
            cmd.Parameters.Add("@name", SqlDbType.NVarChar).Value = nombre;

            int valorDeVerdad = Conexion.Conexion.ejecutarProcedure(cmd);
            if (valorDeVerdad < 0)
            {
                throw new UsuarioInexistenteException();
            }
        }
        public static void verificarUsuarioDuplicado(String nombre)
        {
            SqlCommand cmd = new SqlCommand("usuario_duplicado");
            cmd.Parameters.Add("@name", SqlDbType.NVarChar).Value = nombre;

            int valorDeVerdad = Conexion.Conexion.ejecutarProcedure(cmd);
            if (valorDeVerdad > 0)
            {
                throw new UsuarioDuplicadoException();
            }
        }
        public static void verificarCamposObligatoriosCompletos(List<TextBox> campos)
        {
            if (campos.Exists(campo => campo.Text == string.Empty))
            {
                throw new CamposObligatoriosIncompletosException(campos);
            }
        }
        public static void verificarRolExistente(String nombre)
        {
            String query = String.Format("select * from roles where rol_nombre='{0}'", nombre);
            DataSet ds = Conexion.Conexion.ejecutarConsulta(query);

            if (ds.Tables[0].Rows.Count > 0) { throw new RolExistenteException(); }
        }
        public static void verificarRolHabilitado(int id)
        {
            SqlCommand cmd = new SqlCommand("rol_habilitado");
            cmd.Parameters.Add("@id", SqlDbType.SmallInt).Value = id;

            int i = Conexion.Conexion.ejecutarProcedure(cmd);
            if (i < 0) { throw new RolInhabilitadoException(); }
        }
        public static void verificarClienteHabilitado(String dni)
        {
            String query = String.Format("select habilitado from Clientes where dni='{0}'", dni);
            DataSet ds = Conexion.Conexion.ejecutarConsulta(query);
            Boolean habilitado = Convert.ToBoolean(ds.Tables[0].Rows[0]["habilitado"]);
            if (!habilitado) { throw new ClienteDeshabilitadoException(); }
        }
        public static void verificarProveedorHabilitado(String cuit)
        {
            String query = String.Format("select habilitado from Proveedores where cuit='{0}'", cuit);
            DataSet ds = Conexion.Conexion.ejecutarConsulta(query);
            Boolean habilitado = Convert.ToBoolean(ds.Tables[0].Rows[0]["habilitado"]);
            if (!habilitado) { throw new ProveedorDeshabilitadoException(); }
        }
    }

    public class RolExistenteException : Exception
    {
        public void mensaje()
        {
            MessageBox.Show("Ya existe un rol con ese nombre!", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
    public class ClienteDuplicadoException : Exception
    {
        public ClienteDuplicadoException() { }
        public void mensaje()
        {
            MessageBox.Show("Ya existe un cliente con ese DNI!", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

    }
    public class UsuarioConRolExistenteException : Exception
    {
        public UsuarioConRolExistenteException() { }
        public void mensaje()
        {
            MessageBox.Show("Ya existe un usuario con ese rol!", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

    }
    public class UsuarioInexistenteException : Exception
    {
        public void mensaje()
        {
            MessageBox.Show("Usuario inexistente!", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
    public class CamposObligatoriosIncompletosException : Exception
    {
        private List<TextBox> camposObligatorios = new List<TextBox>();
        public CamposObligatoriosIncompletosException(List<TextBox> l)
        {
            camposObligatorios = l;
        }
        public void mensaje()
        {
            List<TextBox> camposSinLlenar = camposObligatorios.Where(campo => campo.Text == string.Empty).ToList();
            MessageBox.Show("Falta llenar campos: " + camposSinLlenar.Aggregate("", (s, next) => s + next.Name.TrimStart('t', 'x', 't') + " , ").TrimEnd(',', ' '), "Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
    public class RolInhabilitadoException : Exception
    {
        public void mensaje()
        {
            MessageBox.Show("El rol se encuentra inhabilitado!", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
    public class ClienteDeshabilitadoException : Exception
    {
        public void mensaje()
        {
            MessageBox.Show("El Cliente ya estaba dado de baja!", "Ok", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
    public class ProveedorDeshabilitadoException : Exception
    {
        public void mensaje()
        {
            MessageBox.Show("El proveedor ya estaba dado de baja!", "Ok", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
    public class ProveedorDuplicadoException : Exception
    {
        public void mensaje()
        {
            MessageBox.Show("Ya existe un proveedor con ese Cuit!", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
    public class ClienteSinSaldoException : Exception
    {
        public void mensaje()
        {
            MessageBox.Show("No posee saldo suficiente", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);

        }
    }
    public class UsuarioDuplicadoException : Exception
    {
        public void mensaje()
        {
            MessageBox.Show("Ya existe alguien con ese nombre de usuario", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);

        }
    }
}
