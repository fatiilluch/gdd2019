using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Collections;
using FrbaOfertas.Conexion;
using FrbaOfertas.Utilidades;
using FrbaOfertas.GestorDeErrores;
using FrbaOfertas.Entidades;

namespace FrbaOfertas.AbmCliente
{
    public partial class AltaCliente : AltaForm
    {
        protected Usuario us = new Usuario();
        public AltaCliente(Usuario user,Form v)
        {
            InitializeComponent();
            inicializarCamposObligatorios();
            ventanaAnterior = v;
            us = user;
        }
        public AltaCliente()
        {
            InitializeComponent();
        }
        public AltaCliente(Form v)
        {
            InitializeComponent();
            inicializarCamposObligatorios();
            ventanaAnterior = v;
        }
        protected override void inicializarCamposObligatorios(){
            camposObligatorios.Add(txtApellido);
            camposObligatorios.Add(txtNombre);
            camposObligatorios.Add(txtDni);
            camposObligatorios.Add(txtEmail);
            camposObligatorios.Add(txtCiudad);
            camposObligatorios.Add(txtDireccion);
            camposObligatorios.Add(txtCp);
        }
        virtual protected void btnCrear_Click(object sender, EventArgs e)
        {
            
                try
                {
                    GestorDeErrores.GestorDeErrores.verificarCamposObligatoriosCompletos(camposObligatorios);
                    GestorDeErrores.GestorDeErrores.verificarClientesDuplicados(txtDni.Text.ToString());

                    SqlCommand cmd = new SqlCommand();
                    cmd = new SqlCommand("INSERT INTO Clientes (dni,cliente_nombre,cliente_apellido,fecha_nacimiento,ciudad,codigo_postal,telefono,email,direccion,piso,dpto,nombre_usuario) VALUES (@dni,@nom,@ap,@fecha,@ciudad,@cp,@tel,@email,@direccion,@piso,@depto,@user)");

                    int rol_id = RepoRol.getInstance().buscarRol("Cliente").Id;
                    cargarCmd(cmd);

                    if (us.getNombreUsuario() != null) { cargarUsuario(us, rol_id); }
                    Conexion.Conexion.ejecutar(cmd);
                    MessageBox.Show("Cliente guardado exitosamente!", "Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ventanaAnterior.Show();
                    this.Close();
                }
                catch (CamposObligatoriosIncompletosException error)
                {
                    error.mensaje();
                }
                catch (GestorDeErrores.ClienteDuplicadoException c)
                {
                    c.mensaje();
                }
                catch (GestorDeErrores.UsuarioConRolExistenteException c)
                {
                    c.mensaje();
                }
        }

        protected void AltaCliente_FormClosed(object sender, FormClosedEventArgs e)
        {
            ventanaAnterior.Show();
        }

        protected void btnLimpiar_Click(object sender, EventArgs e)
        {
            camposObligatorios.ForEach(box => box.Clear());
            txtPiso.Clear();
            txtDepto.Clear();
        }
        
        protected void cargarCmd(SqlCommand cmd)
        {
            cmd.Parameters.Add("@dni", SqlDbType.NVarChar, 18).Value = txtDni.Text;
            cmd.Parameters.Add("@nom", SqlDbType.NVarChar, 255).Value = txtNombre.Text;
            cmd.Parameters.Add("@ap", SqlDbType.NVarChar, 255).Value = txtApellido.Text;
            cmd.Parameters.Add("@fecha", SqlDbType.DateTime).Value = fechaNacimiento.Value;
            cmd.Parameters.Add("@ciudad", SqlDbType.NVarChar, 255).Value = txtCiudad.Text;
            cmd.Parameters.Add("@cp", SqlDbType.NVarChar, 20).Value = txtCp.Text;
            cmd.Parameters.Add("@tel", SqlDbType.NVarChar, 18).Value = txtTelefono.Text;
            cmd.Parameters.Add("@email", SqlDbType.NVarChar, 255).Value = txtEmail.Text;
            cmd.Parameters.Add("@direccion", SqlDbType.NVarChar, 255).Value = txtDireccion.Text;
            cmd.Parameters.Add("@piso", SqlDbType.SmallInt).Value = txtPiso.Text;
            cmd.Parameters.Add("@depto", SqlDbType.Char).Value = txtDepto.Text;
            cmd.Parameters.Add("@user", SqlDbType.NVarChar, 255).Value = us.getNombreUsuario();
        }

        protected void btnAtras_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}
