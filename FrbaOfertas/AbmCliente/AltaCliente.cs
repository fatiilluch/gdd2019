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
using Utilidades;
using FrbaOfertas.Entidades;

namespace FrbaOfertas.AbmCliente
{
    public partial class AltaCliente : AltaForm
    {
        private Usuario us;
        public AltaCliente(Usuario user,Form v)
        {
            InitializeComponent();
            inicializarCamposObligatorios();
            ventanaAnterior = v;
            us = user;
            txtUsuario.Text = us.getNombreUsuario();
            txtUsuario.Enabled = false;
            txtUsuario.BackColor = Color.DarkGray;
        }
        public AltaCliente(Form v)
        {
            InitializeComponent();
            inicializarCamposObligatorios();
            ventanaAnterior = v;
        }
        public AltaCliente(Cliente cl, Form v)
        {
            InitializeComponent();
            inicializarCamposObligatorios();
            ventanaAnterior = v;
            cargarCampos(cl);
            txtUsuario.Text = cl.Nombre_usuario;
            txtUsuario.Enabled = false;
            txtUsuario.BackColor = Color.DarkGray;

        }
        protected override void inicializarCamposObligatorios(){
            camposObligatorios.Add(txtApellido);
            camposObligatorios.Add(txtNombre);
            camposObligatorios.Add(txtDni);
            camposObligatorios.Add(txtEmail);
            camposObligatorios.Add(txtCiudad);
            camposObligatorios.Add(txtDireccion);
            camposObligatorios.Add(txtCp);
            camposObligatorios.Add(txtUsuario);
        }
        private void AltaCliente_Load(object sender, EventArgs e)
        {

        }        

        private void btnCrear_Click(object sender, EventArgs e)
        {
            
                try
                {
                    Utilidades.GestorDeErrores.verificarCamposObligatoriosCompletos(camposObligatorios);

                    Utilidades.GestorDeErrores.verificarClientesDuplicados(txtDni.Text.ToString());
                    Utilidades.GestorDeErrores.verificarUsuarioPorRolExistente(RepoRol.getInstance().buscarRol("Cliente").Id, txtUsuario.Text.ToString());

                    SqlCommand cmd2 = new SqlCommand();
                    if (us != null)//vengo de la pantalla RegistrarUsuario, en dicho caso haria el insert.
                    {
                        cmd2 = new SqlCommand("INSERT INTO Clientes VALUES (@dni,@nom,@ap,@fecha,@ciudad,@cp,@tel,@email,@direccion,@piso,@depto,@user)", Utilidades.Utilidades.getCon());
                    }
                    else
                    {
                        cmd2 = new SqlCommand("update Clientes set dni=@dni,cliente_nombre=@nom,cliente_apellido=@ap,fecha_nacimiento=@fecha,ciudad=@ciudad,codigo_postal=@cp,telefono=@tel,email=@email,direccion=@direccion,piso=@piso,depto=@depto where nombre_usuario=@user)", Utilidades.Utilidades.getCon());

                    }
                    
                    int rol_id = RepoRol.getInstance().buscarRol("cliente").Id;

                    cmd2.Parameters.Add("@dni", SqlDbType.NVarChar,18).Value=txtDni.Text;
                    cmd2.Parameters.Add("@nom", SqlDbType.NVarChar,255).Value=txtNombre.Text;
                    cmd2.Parameters.Add("@ap", SqlDbType.NVarChar, 255).Value = txtApellido.Text;
                    cmd2.Parameters.Add("@fecha", SqlDbType.DateTime).Value = fechaNacimiento.Value;
                    cmd2.Parameters.Add("@ciudad", SqlDbType.NVarChar, 255).Value = txtCiudad.Text;
                    cmd2.Parameters.Add("@cp", SqlDbType.NVarChar, 20).Value = txtCp.Text;
                    cmd2.Parameters.Add("@tel", SqlDbType.NVarChar, 18).Value = txtTelefono.Text;
                    cmd2.Parameters.Add("@email", SqlDbType.NVarChar, 255).Value = txtEmail.Text;
                    cmd2.Parameters.Add("@direccion", SqlDbType.NVarChar, 255).Value = txtDireccion.Text;
                    cmd2.Parameters.Add("@piso", SqlDbType.SmallInt).Value = txtPiso.Text;
                    cmd2.Parameters.Add("@depto", SqlDbType.Char).Value = txtDepto.Text;
                    cmd2.Parameters.Add("@user", SqlDbType.NVarChar, 255).Value = txtUsuario.Text;
                    if (us != null)
                    {
                        cargarUsuario(us, rol_id);
                    }
                    Utilidades.Utilidades.ejecutar(cmd2);
                    MessageBox.Show("Cliente guardado exitosamente!", "Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ventanaAnterior.Show();
                    this.Close();


                }
                catch (CamposObligatoriosIncompletosException error)
                {
                    error.mensaje();
                }
                catch (Utilidades.ClienteDuplicadoException c)
                {
                    c.mensaje();
                }
                catch (Utilidades.UsuarioConRolExistenteException c)
                {
                    c.mensaje();
                }
        }

        private void AltaCliente_FormClosed(object sender, FormClosedEventArgs e)
        {
            ventanaAnterior.Show();
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            camposObligatorios.ForEach(box => box.Clear());
            txtPiso.Clear();
            txtDepto.Clear();
        }
        private void cargarCampos(Cliente cliente)
        {
            txtNombre.Text = cliente.Cliente_nombre;
            txtApellido.Text = cliente.Cliente_apellido;
            txtDireccion.Text = cliente.Direccion;
            txtCp.Text = cliente.Cp;
            txtDni.Text = cliente.Dni;
            txtEmail.Text = cliente.Email;
            txtTelefono.Text = cliente.Telefono;
            txtCiudad.Text = cliente.Ciudad;
            txtPiso.Text = cliente.Piso.ToString();
            txtDepto.Text = cliente.Dpto.ToString();

        }

    }
}
